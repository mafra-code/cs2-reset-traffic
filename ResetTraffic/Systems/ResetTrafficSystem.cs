namespace ResetTraffic
{
    using Game;
    using Game.Common;
    using Game.Creatures;
    using Game.Input;
    using Game.Objects;
    using Game.Rendering;
    using Game.Simulation;
    using Game.Tools;
    using Game.Vehicles;
    using Unity.Collections;
    using Unity.Entities;

    // Run just before ToolOutputBarrier so Deleted tags land in that frame's tool ECB.
    [UpdateBefore(typeof(ToolOutputBarrier))]
    public partial class ResetTrafficSystem : GameSystemBase
    {
        // One-shot reset: snapshot matching entities once, then walk that list.
        // Newly spawned traffic is ignored. Extra clicks while running are ignored.

        private const int LogEvery = 256;

        private EntityQuery m_MovingCars;
        private EntityQuery m_MovingBicycles;
        private EntityQuery m_MovingTrains;
        private EntityQuery m_MovingPublicTransport;
        private EntityQuery m_MovingTrucks;
        private EntityQuery m_MovingOther;
        private EntityQuery m_Pedestrians;
        private EntityQuery m_ParkedCars;
        private EntityQuery m_ParkedBicycles;
        private EntityQuery m_ParkedTrains;
        private EntityQuery m_ParkedOther;
        private ToolOutputBarrier m_Barrier;
        private NativeList<Entity> m_Snapshot;
        private int m_SnapshotIndex;
        private bool m_SnapshotReady;
        private bool m_Requested;
        private bool m_LoggedWait;
        private int m_SessionCount;
        private int m_LastLoggedCount;
        private int m_LastProcessedFrame = -1;
        private int m_LastWaitLogFrame = -1;
        private bool m_LoggedNullHotkey;
        private int m_DebugSkipNull;
        private int m_DebugSkipMissing;
        private int m_DebugSkipDeleted;

        internal static bool IsActive { get; private set; }

        // Options reads this via SettingsUIValueVersion so Idle/Running/counts refresh.
        internal static int UiVersion { get; private set; }

        internal static string ProgressText { get; private set; } = "No reset yet this session.";

        internal static int RemainingCount { get; private set; }

        internal static int SnapshotTotal { get; private set; }

        internal static int RemovedCount { get; private set; }

        public static void RequestReset()
        {
            World world = World.DefaultGameObjectInjectionWorld;
            if (world == null || !world.IsCreated)
            {
                Mod.Instance?.Logger?.Warn("Reset requested but the game world is not ready.");
                return;
            }

            if (!Setting.IsInGame())
            {
                Mod.Instance?.Logger?.Warn("Reset requested outside an active city.");
                return;
            }

            Setting settings = Mod.Instance?.Settings;
            if (settings != null && !settings.HasAnythingSelected())
            {
                Mod.Instance?.Logger?.Warn("Reset requested but no vehicle or pedestrian types are enabled.");
                return;
            }

            ResetTrafficSystem system = world.GetOrCreateSystemManaged<ResetTrafficSystem>();
            if (system.m_Requested)
            {
                // Do not restart or expand the snapshot while a run is in progress.
                DebugLog($"RequestReset ignored: already running (index={system.m_SnapshotIndex}/{system.SnapshotLength}, tagged={system.m_SessionCount}, snapshotReady={system.m_SnapshotReady}).");
                return;
            }

            system.m_Requested = true;
            system.m_SnapshotReady = false;
            system.m_SnapshotIndex = 0;
            system.m_LoggedWait = false;
            system.m_SessionCount = 0;
            system.m_LastLoggedCount = 0;
            system.m_LastProcessedFrame = -1;
            if (system.m_Snapshot.IsCreated)
            {
                system.m_Snapshot.Clear();
            }

            IsActive = true;
            PublishState("Queued. Close Options, then set speed to 1.", 0, 0, 0);
            Mod.Instance?.Logger?.Info("Reset queued. Close Options, then set game speed to 1.");
            DebugLog($"RequestReset accepted. types={DescribeTypes(settings)} perFrame={settings?.ClampedVehiclesPerFrame()} interval={settings?.ClampedFrameInterval()}");
        }

        private int SnapshotLength => m_Snapshot.IsCreated ? m_Snapshot.Length : 0;

        protected override void OnCreate()
        {
            base.OnCreate();
            m_Barrier = World.GetOrCreateSystemManaged<ToolOutputBarrier>();
            m_Snapshot = new NativeList<Entity>(4096, Allocator.Persistent);
            // Deleted = already going away. Temp = preview/ghost. Unspawned = spawn-pending
            // (tagging those keeps them in a bounce loop). InterpolatedTransform ≈ currently moving.
            ComponentType deleted = ComponentType.ReadOnly<Deleted>();
            ComponentType temp = ComponentType.ReadOnly<Temp>();
            ComponentType unspawned = ComponentType.ReadOnly<Unspawned>();
            ComponentType interpolated = ComponentType.ReadOnly<InterpolatedTransform>();

            m_MovingCars = GetEntityQuery(new EntityQueryDesc
            {
                All = new[] { ComponentType.ReadOnly<PersonalCar>(), interpolated },
                None = new[] { deleted, temp, unspawned, ComponentType.ReadOnly<ParkedCar>() },
            });
            m_MovingBicycles = GetEntityQuery(new EntityQueryDesc
            {
                All = new[] { ComponentType.ReadOnly<Bicycle>(), interpolated },
                None = new[] { deleted, temp, unspawned },
            });
            m_MovingTrains = GetEntityQuery(new EntityQueryDesc
            {
                All = new[] { ComponentType.ReadOnly<Train>(), interpolated },
                None = new[] { deleted, temp, unspawned, ComponentType.ReadOnly<ParkedTrain>() },
            });
            // Trains have their own toggle; exclude them here so PT does not double-count.
            m_MovingPublicTransport = GetEntityQuery(new EntityQueryDesc
            {
                All = new[] { interpolated },
                Any = new[] { ComponentType.ReadOnly<PublicTransport>(), ComponentType.ReadOnly<Taxi>(), ComponentType.ReadOnly<PassengerTransport>() },
                None = new[] { deleted, temp, unspawned, ComponentType.ReadOnly<Train>() },
            });
            m_MovingTrucks = GetEntityQuery(new EntityQueryDesc
            {
                All = new[] { interpolated },
                Any = new[]
                {
                    ComponentType.ReadOnly<DeliveryTruck>(),
                    ComponentType.ReadOnly<GarbageTruck>(),
                    ComponentType.ReadOnly<FireEngine>(),
                    ComponentType.ReadOnly<PoliceCar>(),
                    ComponentType.ReadOnly<PostVan>(),
                    ComponentType.ReadOnly<Ambulance>(),
                    ComponentType.ReadOnly<Hearse>(),
                    ComponentType.ReadOnly<MaintenanceVehicle>(),
                    ComponentType.ReadOnly<CargoTransport>(),
                },
                None = new[] { deleted, temp, unspawned },
            });
            m_MovingOther = GetEntityQuery(new EntityQueryDesc
            {
                All = new[] { interpolated },
                Any = new[]
                {
                    ComponentType.ReadOnly<Aircraft>(),
                    ComponentType.ReadOnly<Watercraft>(),
                    ComponentType.ReadOnly<Helicopter>(),
                },
                None = new[] { deleted, temp, unspawned },
            });
            // Skip cims already seated in a vehicle; those follow the vehicle entity.
            m_Pedestrians = GetEntityQuery(new EntityQueryDesc
            {
                All = new[] { ComponentType.ReadOnly<Human>(), interpolated },
                None = new[] { deleted, temp, unspawned, ComponentType.ReadOnly<CurrentVehicle>() },
            });
            // Includes curb, garage, and depot/service fleets — not street parking only.
            m_ParkedCars = GetEntityQuery(new EntityQueryDesc
            {
                All = new[] { ComponentType.ReadOnly<ParkedCar>() },
                None = new[] { deleted, temp, unspawned },
            });
            // Parked bikes have no InterpolatedTransform (moving bikes do).
            m_ParkedBicycles = GetEntityQuery(new EntityQueryDesc
            {
                All = new[] { ComponentType.ReadOnly<Bicycle>() },
                None = new[] { deleted, temp, unspawned, interpolated },
            });
            m_ParkedTrains = GetEntityQuery(new EntityQueryDesc
            {
                All = new[] { ComponentType.ReadOnly<ParkedTrain>() },
                None = new[] { deleted, temp, unspawned },
            });
            // Stationary vehicles that are not parked cars/trains/bikes (boats at docks, planes at gates, …).
            m_ParkedOther = GetEntityQuery(new EntityQueryDesc
            {
                All = new[] { ComponentType.ReadOnly<Vehicle>() },
                None = new[]
                {
                    deleted,
                    temp,
                    unspawned,
                    interpolated,
                    ComponentType.ReadOnly<ParkedCar>(),
                    ComponentType.ReadOnly<ParkedTrain>(),
                    ComponentType.ReadOnly<Bicycle>(),
                },
            });
        }

        protected override void OnDestroy()
        {
            // Persistent NativeList must be disposed with the system.
            if (m_Snapshot.IsCreated)
            {
                m_Snapshot.Dispose();
            }

            IsActive = false;
            BumpUi();
            base.OnDestroy();
        }

        protected override void OnUpdate()
        {
            PollHotkey();

            if (!m_Requested)
            {
                return;
            }

            // IsGame() is false in Options and on the main menu. Pause; do not Finish.
            // Leaving the city still clears via OnDestroy when the world is disposed.
            if (!Setting.IsInGame())
            {
                DebugLogThrottled("OnUpdate wait: menu/Options open; in-flight reset paused (not cancelled).");
                return;
            }

            SimulationSystem simulation = World.GetExistingSystemManaged<SimulationSystem>();
            float speed = simulation != null ? simulation.selectedSpeed : -1f;
            // selectedSpeed 0 = paused. Deleting while paused is unsafe; wait for speed > 0.
            if (simulation == null || speed <= 0f)
            {
                if (!m_LoggedWait)
                {
                    m_LoggedWait = true;
                    PublishState("Waiting for speed 1.", RemainingCount, SnapshotTotal, RemovedCount);
                    Mod.Instance?.Logger?.Info("Waiting for game speed > 0. Close Options and unpause to start.");
                }

                DebugLogThrottled($"OnUpdate wait: selectedSpeed={speed} requested={m_Requested} snapshotReady={m_SnapshotReady} index={m_SnapshotIndex}/{SnapshotLength} IsActive={IsActive}");
                return;
            }

            Setting settings = Mod.Instance?.Settings;
            if (settings == null || !settings.HasAnythingSelected())
            {
                DebugLog("OnUpdate abort: no types enabled.");
                Finish("Skipped vehicle reset: no types enabled.", warn: true);
                return;
            }

            if (!m_SnapshotReady)
            {
                // Wait for in-flight jobs so ToEntityArray is a consistent view.
                EntityManager.CompleteAllTrackedJobs();
                BuildSnapshot(settings);
                m_SnapshotReady = true;
                if (m_Snapshot.Length == 0)
                {
                    DebugLog("Snapshot empty after BuildSnapshot.");
                    Finish("Reset complete: nothing matched the checked types.");
                    return;
                }

                PublishState($"Snapshot {m_Snapshot.Length}. Removing listed entities only.", m_Snapshot.Length, m_Snapshot.Length, 0);
                Mod.Instance?.Logger?.Info($"Snapshot {m_Snapshot.Length} entities. Vehicles that spawn after this are left alone.");
                DebugLog($"Snapshot ready length={m_Snapshot.Length} IsActive={IsActive} UiVersion={UiVersion}");
            }

            int perFrame = settings.ClampedVehiclesPerFrame();
            int interval = settings.ClampedFrameInterval();
            // Unity render frames, not simulation ticks (those stall at speed 0).
            int frame = UnityEngine.Time.frameCount;
            if (m_LastProcessedFrame >= 0 && frame < m_LastProcessedFrame + 1 + interval)
            {
                DebugLogThrottled($"OnUpdate skip interval: frame={frame} last={m_LastProcessedFrame} interval={interval} index={m_SnapshotIndex}/{SnapshotLength}");
                return;
            }

            m_LastProcessedFrame = frame;
            EntityManager.CompleteAllTrackedJobs();

            m_DebugSkipNull = 0;
            m_DebugSkipMissing = 0;
            m_DebugSkipDeleted = 0;
            EntityCommandBuffer commandBuffer = m_Barrier.CreateCommandBuffer();
            int tagged = TagSnapshotBatch(commandBuffer, perFrame, settings.EnableDebugging);
            m_SessionCount += tagged;
            int stillLeft = m_Snapshot.Length - m_SnapshotIndex;
            PublishState($"Running: {m_SessionCount} removed, {stillLeft} left in snapshot.", stillLeft, m_Snapshot.Length, m_SessionCount);
            DebugLog($"batch frame={frame} speed={speed} tagged={tagged} session={m_SessionCount} index={m_SnapshotIndex}/{m_Snapshot.Length} left={stillLeft} skipNull={m_DebugSkipNull} skipMissing={m_DebugSkipMissing} skipDeleted={m_DebugSkipDeleted} IsActive={IsActive} UiVersion={UiVersion}");

            if (stillLeft <= 0)
            {
                DebugLog($"Finish condition met. taggedThisSession={m_SessionCount} snapshotLength={m_Snapshot.Length}");
                Finish($"Reset complete: {m_SessionCount} entities.");
                return;
            }

            if (m_SessionCount == tagged || m_SessionCount - m_LastLoggedCount >= LogEvery)
            {
                m_LastLoggedCount = m_SessionCount;
                Mod.Instance?.Logger?.Info($"Reset progress: {m_SessionCount} entities tagged, {stillLeft} remaining in snapshot.");
            }
        }

        private void BuildSnapshot(Setting settings)
        {
            m_Snapshot.Clear();
            m_SnapshotIndex = 0;
            // Queries overlap (e.g. a bus is PT and a truck-like vehicle). Keep each entity once.
            NativeHashSet<Entity> seen = new NativeHashSet<Entity>(4096, Allocator.Temp);
            try
            {
                AppendQuery("MovingCars", settings.RemoveMovingCars, m_MovingCars, seen);
                AppendQuery("MovingBicycles", settings.RemoveMovingBicycles, m_MovingBicycles, seen);
                AppendQuery("MovingTrains", settings.RemoveMovingTrains, m_MovingTrains, seen);
                AppendQuery("MovingPublicTransport", settings.RemoveMovingPublicTransport, m_MovingPublicTransport, seen);
                AppendQuery("MovingTrucks", settings.RemoveMovingTrucks, m_MovingTrucks, seen);
                AppendQuery("MovingOther", settings.RemoveMovingOther, m_MovingOther, seen);
                AppendQuery("Pedestrians", settings.RemovePedestrians, m_Pedestrians, seen);
                AppendQuery("ParkedCars", settings.RemoveParkedCars, m_ParkedCars, seen);
                AppendQuery("ParkedBicycles", settings.RemoveParkedBicycles, m_ParkedBicycles, seen);
                AppendQuery("ParkedTrains", settings.RemoveParkedTrains, m_ParkedTrains, seen);
                AppendQuery("ParkedOther", settings.RemoveParkedOther, m_ParkedOther, seen);
            }
            finally
            {
                seen.Dispose();
            }

            DebugLog($"BuildSnapshot total={m_Snapshot.Length}");
        }

        private void AppendQuery(string name, bool enabled, EntityQuery query, NativeHashSet<Entity> seen)
        {
            if (!enabled)
            {
                DebugLog($"query {name} skipped (unchecked)");
                return;
            }

            NativeArray<Entity> entities = query.ToEntityArray(Allocator.Temp);
            int added = 0;
            int dupes = 0;
            try
            {
                for (int i = 0; i < entities.Length; i++)
                {
                    Entity entity = entities[i];
                    if (entity == Entity.Null || !seen.Add(entity))
                    {
                        dupes++;
                        continue;
                    }

                    m_Snapshot.Add(entity);
                    added++;
                }
            }
            finally
            {
                entities.Dispose();
            }

            DebugLog($"query {name} live={query.CalculateEntityCount()} added={added} dupesOrNull={dupes}");
        }

        private int TagSnapshotBatch(EntityCommandBuffer commandBuffer, int budget, bool debugging)
        {
            int tagged = 0;
            while (m_SnapshotIndex < m_Snapshot.Length && tagged < budget)
            {
                int index = m_SnapshotIndex;
                // Advance even when skipping so Remaining can reach 0 (gone/already Deleted).
                Entity entity = m_Snapshot[m_SnapshotIndex++];
                if (entity == Entity.Null)
                {
                    m_DebugSkipNull++;
                    if (debugging)
                    {
                        DebugLog($"skip[{index}] Entity.Null");
                    }

                    continue;
                }

                if (!EntityManager.Exists(entity))
                {
                    m_DebugSkipMissing++;
                    if (debugging)
                    {
                        DebugLog($"skip[{index}] missing {FormatEntity(entity)}");
                    }

                    continue;
                }

                if (EntityManager.HasComponent<Deleted>(entity))
                {
                    m_DebugSkipDeleted++;
                    if (debugging)
                    {
                        DebugLog($"skip[{index}] already Deleted {FormatEntity(entity)}");
                    }

                    continue;
                }

                TagDeleted(commandBuffer, entity, debugging);
                tagged++;
                if (debugging)
                {
                    DebugLog($"tag[{index}] {FormatEntity(entity)} taggedThisBatch={tagged}/{budget}");
                }
            }

            return tagged;
        }

        private void Finish(string message, bool warn = false)
        {
            DebugLog($"Finish begin: '{message}' requested={m_Requested} snapshotReady={m_SnapshotReady} index={m_SnapshotIndex}/{SnapshotLength} session={m_SessionCount} IsActive={IsActive}");
            if (warn)
            {
                Mod.Instance?.Logger?.Warn(message);
            }
            else
            {
                Mod.Instance?.Logger?.Info(message);
            }

            int removed = m_SessionCount;
            int snapshot = SnapshotLength;
            m_Requested = false;
            m_SnapshotReady = false;
            m_SnapshotIndex = 0;
            m_SessionCount = 0;
            m_LastLoggedCount = 0;
            if (m_Snapshot.IsCreated)
            {
                m_Snapshot.Clear();
            }

            IsActive = false;
            PublishState(message, 0, snapshot, removed);
            DebugLog($"Finish end: IsActive={IsActive} UiVersion={UiVersion} ProgressText='{ProgressText}'");
        }

        private static void PublishState(string text, int remaining, int snapshot, int removed)
        {
            ProgressText = text;
            RemainingCount = remaining;
            SnapshotTotal = snapshot;
            RemovedCount = removed;
            BumpUi();
        }

        private static void BumpUi()
        {
            UiVersion++;
        }

        private void PollHotkey()
        {
            Setting settings = Mod.Instance?.Settings;
            if (settings == null)
            {
                return;
            }

            ProxyAction action = settings.GetAction(nameof(Setting.ResetHotkey));
            if (action == null)
            {
                // Binding is not registered with InputManager, so the hotkey cannot fire.
                if (settings.EnableDebugging && !m_LoggedNullHotkey)
                {
                    m_LoggedNullHotkey = true;
                    DebugLog("GetAction(ResetHotkey) returned null. Hotkey will not fire.");
                }

                return;
            }

            action.shouldBeEnabled = Setting.IsInGame();
            bool performed = action.WasPerformedThisFrame();
            if (settings.EnableDebugging && performed)
            {
                DebugLog($"hotkey performed shouldBeEnabled={action.shouldBeEnabled} inGame={Setting.IsInGame()} alreadyRunning={IsActive}");
            }

            if (performed && Setting.IsInGame())
            {
                RequestReset();
            }
        }

        private void TagDeleted(EntityCommandBuffer commandBuffer, Entity entity, bool debugging)
        {
            if (entity == Entity.Null || !EntityManager.Exists(entity) || EntityManager.HasComponent<Deleted>(entity))
            {
                return;
            }

            // Deferred Deleted via the tool barrier — not EntityManager.AddComponent this frame.
            commandBuffer.AddComponent<Deleted>(entity);

            if (!EntityManager.HasBuffer<LayoutElement>(entity))
            {
                return;
            }

            // Extra slots on the same vehicle (articulated buses, train cars, trailers).

            DynamicBuffer<LayoutElement> layout = EntityManager.GetBuffer<LayoutElement>(entity, true);
            int extras = 0;
            for (int i = 0; i < layout.Length; i++)
            {
                Entity extra = layout[i].m_Vehicle;
                if (extra == Entity.Null || extra == entity || !EntityManager.Exists(extra) || EntityManager.HasComponent<Deleted>(extra))
                {
                    continue;
                }

                commandBuffer.AddComponent<Deleted>(extra);
                extras++;
                if (debugging)
                {
                    DebugLog($"  layout extra {FormatEntity(extra)} of {FormatEntity(entity)}");
                }
            }

            if (debugging && extras > 0)
            {
                DebugLog($"  layout extras tagged={extras} for {FormatEntity(entity)}");
            }
        }

        private static string FormatEntity(Entity entity)
        {
            return $"Index={entity.Index} Version={entity.Version}";
        }

        private static string DescribeTypes(Setting settings)
        {
            if (settings == null)
            {
                return "settings=null";
            }

            return "cars=" + settings.RemoveMovingCars
                + " bikes=" + settings.RemoveMovingBicycles
                + " trains=" + settings.RemoveMovingTrains
                + " pt=" + settings.RemoveMovingPublicTransport
                + " trucks=" + settings.RemoveMovingTrucks
                + " other=" + settings.RemoveMovingOther
                + " peds=" + settings.RemovePedestrians
                + " parkedCars=" + settings.RemoveParkedCars
                + " parkedBikes=" + settings.RemoveParkedBicycles
                + " parkedTrains=" + settings.RemoveParkedTrains
                + " parkedOther=" + settings.RemoveParkedOther;
        }

        private static void DebugLog(string message)
        {
            Setting settings = Mod.Instance?.Settings;
            if (settings == null || !settings.EnableDebugging)
            {
                return;
            }

            Mod.Instance.Logger?.Info("[DEBUG] " + message);
        }

        private void DebugLogThrottled(string message)
        {
            // Wait loops run every frame; cap debug spam at about once per second.
            int frame = UnityEngine.Time.frameCount;
            if (m_LastWaitLogFrame >= 0 && frame - m_LastWaitLogFrame < 60)
            {
                return;
            }

            m_LastWaitLogFrame = frame;
            DebugLog(message);
        }
    }
}
