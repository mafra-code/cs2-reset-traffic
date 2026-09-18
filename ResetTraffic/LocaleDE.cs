namespace ResetTraffic
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// German Options strings. Keys match <see cref="LocaleEN"/> so both languages bind to the
    /// same <see cref="Setting"/> properties.
    /// </summary>
    public class LocaleDE : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleDE(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Reset Traffic (Alpha)" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetVehicles)), "Auswahl zurücksetzen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetVehicles)), "Einmalig: entfernt die angehakten Typen, die jetzt existieren. Neu gespawnter Verkehr bleibt. Optionen schließen, dann Geschwindigkeit auf 1." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetVehicles)), "Angehakte Fahrzeuge und Fußgänger, die jetzt existieren, zurücksetzen? Neu gespawnter Verkehr wird nicht entfernt. Optionen schließen, dann Geschwindigkeit auf 1." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.IdleIndicator)), "Inaktiv" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.IdleIndicator)), "Kein Reset läuft. Extra-Klicks werden ignoriert, solange einer aktiv ist." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RunningIndicator)), "Läuft" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RunningIndicator)), "Ein Reset ist aktiv. Es werden nur die Objekte aus der Startliste entfernt." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProgressText)), "Fortschritt" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ProgressText)), "Größe der Startliste und wie viele davon schon entfernt wurden." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemainingCount)), "Übrig" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemainingCount)), "Wie viele Objekte aus der Startliste noch entfernt werden." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemovedCount)), "Entfernt" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemovedCount)), "Wie viele Objekte in diesem Lauf markiert wurden." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SnapshotTotal)), "Startliste" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SnapshotTotal)), "Wie viele Objekte beim Start des Resets auf der Liste standen." },
                { m_Setting.GetOptionGroupLocaleID(Setting.kActionGroup), "Reset" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kMovingGroup), "Fahrende Fahrzeuge und Fußgänger" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kParkedGroup), "Geparkt" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kPaceGroup), "Tempo" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kKeybindingGroup), "Tastenkürzel" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "Debug" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDefaultsGroup), "Standardwerte" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingCars)), "Autos" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingCars)), "Private Autos, die gerade fahren." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingBicycles)), "Fahrräder" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingBicycles)), "Fahrräder, die gerade unterwegs sind." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingTrains)), "Züge" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingTrains)), "Züge und Metro, die gerade fahren." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingPublicTransport)), "ÖPNV" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingPublicTransport)), "Busse, Taxis und anderer fahrender ÖPNV (keine Züge)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingTrucks)), "LKW und Dienste" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingTrucks)), "Lieferwagen, Müll, Polizei, Feuerwehr, Post, Krankenwagen und ähnliches." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingOther)), "Flugzeuge und Schiffe" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingOther)), "Flugzeuge, Hubschrauber und Boote, die gerade unterwegs sind." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemovePedestrians)), "Fußgänger" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemovePedestrians)), "Laufende Cims. Standard aus. Personen in Fahrzeugen werden nicht gezielt." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedCars)), "Geparkte Autos" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedCars)), "Autos auf Parkplätzen, am Straßenrand und in Gebäudegaragen (inkl. Dienst- und Depotfahrzeuge)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedBicycles)), "Geparkte Fahrräder" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedBicycles)), "Stillstehende Fahrräder." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedTrains)), "Geparkte Züge" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedTrains)), "Züge in Depots oder Abstellanlagen." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedOther)), "Sonstiges geparkt" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedOther)), "Alle anderen geparkten Fahrzeuge (Boote am Kai, Flugzeuge am Gate und ähnliches)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VehiclesPerFrame)), "Objekte pro Frame" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VehiclesPerFrame)), "Wie viele Objekte pro Stapel entfernt werden (1–64)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FrameInterval)), "Extra-Frames zwischen Stapeln" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FrameInterval)), "Soviele zusätzliche Anzeige-Frames nach jedem Stapel warten. 0 = jeden Frame, 4 ≈ viermal langsamer." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetHotkey)), "Tastenkürzel für Reset" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetHotkey)), "Taste, um einen Reset ohne Optionsmenü zu starten. Standard: F9. Taste anklicken, dann eine neue drücken." },
                { m_Setting.GetBindingKeyLocaleID(nameof(Setting.ResetHotkey)), "Auswahl zurücksetzen" },
                { m_Setting.GetBindingMapLocaleID(), "Reset Traffic" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetBindings)), "Tastenkürzel zurücksetzen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetBindings)), "Setzt das Tastenkürzel wieder auf F9." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableDebugging)), "Ausführliche Reset-Logs in Mods_ResetTraffic.log. Bremst das Spiel, solange an. Für normale Geschwindigkeit aus." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetModSettings)), "Auf Standardwerte zurücksetzen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetModSettings)), "Setzt Typfilter, Tempo-Slider und Debugging auf die Originalwerte. Ändert das Tastenkürzel nicht und entfernt keinen Verkehr." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetModSettings)), "Typfilter, Tempo-Slider und Debugging auf die Standardwerte zurücksetzen? Das Tastenkürzel bleibt, es wird kein Verkehr entfernt." },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
