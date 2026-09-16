namespace ResetTraffic
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// English Options strings. Keys are built from <see cref="Setting"/> locale IDs so labels
    /// stay bound if a property is renamed.
    /// </summary>
    public class LocaleEN : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleEN(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Reset Traffic (Alpha)" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetVehicles)), "Reset selected" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetVehicles)), "One-shot: remove the checked types that exist right now. Newly spawned traffic is left alone. Close Options, then set speed to 1." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetVehicles)), "Reset the checked vehicles and pedestrians that exist right now? Newly spawned traffic will not be removed. Close Options, then set speed to 1." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.IdleIndicator)), "Idle" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.IdleIndicator)), "No reset is running. Extra button presses are ignored while one is active." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RunningIndicator)), "Running" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RunningIndicator)), "A reset is in progress. Only the snapshot taken at start is being removed." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProgressText)), "Progress" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ProgressText)), "Snapshot size and how many of those entities have been removed." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemainingCount)), "Remaining" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemainingCount)), "How many snapshot entities are still waiting to be removed." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemovedCount)), "Removed" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemovedCount)), "How many snapshot entities have been tagged this run." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SnapshotTotal)), "Snapshot" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SnapshotTotal)), "How many entities were listed when the reset started." },
                { m_Setting.GetOptionGroupLocaleID(Setting.kActionGroup), "Reset" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kMovingGroup), "Moving vehicles and pedestrians" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kParkedGroup), "Parked" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kPaceGroup), "Pace" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kKeybindingGroup), "Hotkey" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingCars)), "Cars" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingCars)), "Personal cars currently driving." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingBicycles)), "Bicycles" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingBicycles)), "Bicycles currently moving." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingTrains)), "Trains" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingTrains)), "Trains and metro currently moving." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingPublicTransport)), "Public transport" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingPublicTransport)), "Buses, taxis, and other moving public transport (not trains)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingTrucks)), "Trucks and service" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingTrucks)), "Delivery trucks, garbage, police, fire, post, ambulances, and similar." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingOther)), "Aircraft and watercraft" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingOther)), "Planes, helicopters, and boats that are currently moving." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemovePedestrians)), "Pedestrians" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemovePedestrians)), "Walking cims. Off by default. People already in vehicles are not targeted." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedCars)), "Parked cars" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedCars)), "Cars at lots, curbs, and building garages (including service and depot vehicles)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedBicycles)), "Parked bicycles" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedBicycles)), "Stationary bicycles." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedTrains)), "Parked trains" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedTrains)), "Trains sitting in depots or yards." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedOther)), "Other parked" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedOther)), "Any other parked vehicles (boats at docks, planes at gates, and similar)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VehiclesPerFrame)), "Entities per frame" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VehiclesPerFrame)), "How many entities to remove each batch (1–64)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FrameInterval)), "Extra frames between batches" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FrameInterval)), "Wait this many extra display frames after each batch. 0 = every frame, 4 ≈ four times slower." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetHotkey)), "Reset hotkey" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetHotkey)), "Key to queue a reset without opening Options. Default F9. Click the key, then press a new one to rebind." },
                { m_Setting.GetBindingKeyLocaleID(nameof(Setting.ResetHotkey)), "Reset selected" },
                { m_Setting.GetBindingMapLocaleID(), "Reset Traffic" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetBindings)), "Reset key bindings" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetBindings)), "Restore the reset hotkey to F9." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableDebugging)), "Verbose reset logs in Mods_ResetTraffic.log. Slows the game while on. Turn off for normal speed." },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
