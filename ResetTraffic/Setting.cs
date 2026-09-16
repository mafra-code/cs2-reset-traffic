namespace ResetTraffic
{
    using Colossal.IO.AssetDatabase;
    using Game;
    using Game.Input;
    using Game.Modding;
    using Game.Settings;
    using Game.Tools;
    using Unity.Entities;

    // Saved as Mods_ResetTraffic.coc under the game's ModsSettings folder.
    [FileLocation("Mods_ResetTraffic")]
    [SettingsUIPageWarning(typeof(Setting), nameof(IsRunning))]
    [SettingsUIGroupOrder(kActionGroup, kMovingGroup, kParkedGroup, kPaceGroup, kKeybindingGroup, kDebugGroup)]
    [SettingsUIShowGroupName(kActionGroup, kMovingGroup, kParkedGroup, kPaceGroup, kKeybindingGroup, kDebugGroup)]
    public class Setting : ModSetting
    {
        public const string kSection = "Main";
        public const string kActionGroup = "Actions";
        public const string kMovingGroup = "Moving";
        public const string kParkedGroup = "Parked";
        public const string kPaceGroup = "Pace";
        public const string kKeybindingGroup = "KeyBinding";
        public const string kDebugGroup = "Debug";

        public const int DefaultVehiclesPerFrame = 16;
        public const int DefaultFrameInterval = 0;
        public const int MinVehiclesPerFrame = 1;
        public const int MaxVehiclesPerFrame = 64;
        public const int MinFrameInterval = 0;
        public const int MaxFrameInterval = 30;

        public Setting(IMod mod)
            : base(mod)
        {
        }

        [SettingsUISection(kSection, kActionGroup)]
        [SettingsUIButton]
        [SettingsUIConfirmation]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(DisableResetButton))]
        public bool ResetVehicles
        {
            set
            {
                ResetTrafficSystem.RequestReset();
            }
        }

        // Dummy rows: AlwaysDisabled makes them read-only. ValueVersion + BumpUi
        // forces Options to redraw Idle/Running/counts. HideByCondition swaps Idle vs Running.
        [SettingsUISection(kSection, kActionGroup)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(IsRunning))]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(AlwaysDisabled))]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetUiVersion))]
        public bool IdleIndicator
        {
            get { return true; }
            set { }
        }

        [SettingsUISection(kSection, kActionGroup)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(IsIdle))]
        [SettingsUIWarning(typeof(Setting), nameof(IsRunning))]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(AlwaysDisabled))]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetUiVersion))]
        public bool RunningIndicator
        {
            get { return true; }
            set { }
        }

        [SettingsUISection(kSection, kActionGroup)]
        [SettingsUIMultilineText]
        [SettingsUIWarning(typeof(Setting), nameof(IsRunning))]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(AlwaysDisabled))]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetUiVersion))]
        public string ProgressText
        {
            get { return ResetTrafficSystem.ProgressText; }
            set { }
        }

        [SettingsUISection(kSection, kActionGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(AlwaysDisabled))]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetUiVersion))]
        public int RemainingCount
        {
            get { return ResetTrafficSystem.RemainingCount; }
            set { }
        }

        [SettingsUISection(kSection, kActionGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(AlwaysDisabled))]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetUiVersion))]
        public int RemovedCount
        {
            get { return ResetTrafficSystem.RemovedCount; }
            set { }
        }

        [SettingsUISection(kSection, kActionGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(AlwaysDisabled))]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetUiVersion))]
        public int SnapshotTotal
        {
            get { return ResetTrafficSystem.SnapshotTotal; }
            set { }
        }

        [SettingsUISection(kSection, kMovingGroup)]
        public bool RemoveMovingCars { get; set; }

        [SettingsUISection(kSection, kMovingGroup)]
        public bool RemoveMovingBicycles { get; set; }

        [SettingsUISection(kSection, kMovingGroup)]
        public bool RemoveMovingTrains { get; set; }

        [SettingsUISection(kSection, kMovingGroup)]
        public bool RemoveMovingPublicTransport { get; set; }

        [SettingsUISection(kSection, kMovingGroup)]
        public bool RemoveMovingTrucks { get; set; }

        [SettingsUISection(kSection, kMovingGroup)]
        public bool RemoveMovingOther { get; set; }

        [SettingsUISection(kSection, kMovingGroup)]
        public bool RemovePedestrians { get; set; }

        [SettingsUISection(kSection, kParkedGroup)]
        public bool RemoveParkedCars { get; set; }

        [SettingsUISection(kSection, kParkedGroup)]
        public bool RemoveParkedBicycles { get; set; }

        [SettingsUISection(kSection, kParkedGroup)]
        public bool RemoveParkedTrains { get; set; }

        [SettingsUISection(kSection, kParkedGroup)]
        public bool RemoveParkedOther { get; set; }

        [SettingsUISection(kSection, kPaceGroup)]
        [SettingsUISlider(min = MinVehiclesPerFrame, max = MaxVehiclesPerFrame, step = 1, scalarMultiplier = 1)]
        public int VehiclesPerFrame { get; set; }

        [SettingsUISection(kSection, kPaceGroup)]
        [SettingsUISlider(min = MinFrameInterval, max = MaxFrameInterval, step = 1, scalarMultiplier = 1)]
        public int FrameInterval { get; set; }

        [SettingsUISection(kSection, kKeybindingGroup)]
        // A real default key is required; BindingKeyboard.None never registers an InputManager action.
        [SettingsUIKeyboardBinding(BindingKeyboard.F9, nameof(ResetHotkey), alt: false, ctrl: false, shift: false)]
        public ProxyBinding ResetHotkey { get; set; }

        [SettingsUISection(kSection, kKeybindingGroup)]
        [SettingsUIButton]
        public bool ResetBindings
        {
            set
            {
                ResetKeyBindings();
            }
        }

        [SettingsUISection(kSection, kDebugGroup)]
        [SettingsUISetter(typeof(Setting), nameof(OnDebuggingChanged))]
        public bool EnableDebugging { get; set; }

        public bool IsNotInGame => !IsInGame();

        public bool IsRunning => ResetTrafficSystem.IsActive;

        public bool IsIdle => !ResetTrafficSystem.IsActive;

        public bool DisableResetButton => IsNotInGame || ResetTrafficSystem.IsActive;

        public bool AlwaysDisabled => true;

        public int GetUiVersion()
        {
            return ResetTrafficSystem.UiVersion;
        }

        public override void SetDefaults()
        {
            VehiclesPerFrame = DefaultVehiclesPerFrame;
            FrameInterval = DefaultFrameInterval;
            RemoveMovingCars = true;
            RemoveMovingBicycles = true;
            RemoveMovingTrains = true;
            RemoveMovingPublicTransport = true;
            RemoveMovingTrucks = true;
            RemoveMovingOther = true;
            // Pedestrians respawn continuously; parked cars include depot/service fleets.
            RemovePedestrians = false;
            RemoveParkedCars = false;
            RemoveParkedBicycles = false;
            RemoveParkedTrains = false;
            RemoveParkedOther = false;
            EnableDebugging = false;
        }

        public void OnDebuggingChanged(bool value)
        {
            Mod.Instance?.Logger?.Info(value
                ? "Debugging ON. Verbose reset logs are enabled and will slow the game. See Mods_ResetTraffic.log."
                : "Debugging OFF. Reset logs back to normal.");
        }

        internal bool HasAnythingSelected()
        {
            return RemoveMovingCars
                || RemoveMovingBicycles
                || RemoveMovingTrains
                || RemoveMovingPublicTransport
                || RemoveMovingTrucks
                || RemoveMovingOther
                || RemovePedestrians
                || RemoveParkedCars
                || RemoveParkedBicycles
                || RemoveParkedTrains
                || RemoveParkedOther;
        }

        internal int ClampedVehiclesPerFrame()
        {
            int value = VehiclesPerFrame;
            if (value < MinVehiclesPerFrame)
            {
                return MinVehiclesPerFrame;
            }

            if (value > MaxVehiclesPerFrame)
            {
                return MaxVehiclesPerFrame;
            }

            return value;
        }

        internal int ClampedFrameInterval()
        {
            int value = FrameInterval;
            if (value < MinFrameInterval)
            {
                return MinFrameInterval;
            }

            if (value > MaxFrameInterval)
            {
                return MaxFrameInterval;
            }

            return value;
        }

        internal static bool IsInGame()
        {
            World world = World.DefaultGameObjectInjectionWorld;
            if (world == null || !world.IsCreated)
            {
                return false;
            }

            // False on the main menu and while Options is open (actionMode is not Game).
            ToolSystem toolSystem = world.GetExistingSystemManaged<ToolSystem>();
            return toolSystem != null && toolSystem.actionMode.IsGame();
        }
    }
}
