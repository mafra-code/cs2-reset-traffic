namespace ResetTraffic
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// AI-generated Options strings from the English meaning. Keys match <see cref="LocaleEN"/>.
    /// </summary>
    public class LocaleES : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleES(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Reset Traffic (Alpha)" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetVehicles)), "Restablecer selección" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetVehicles)), "Una vez: elimina los tipos marcados que existen ahora. El tráfico recién generado no se toca. Cierra Opciones y pon la velocidad en 1." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetVehicles)), "¿Restablecer los vehículos y peatones marcados que existen ahora? El tráfico recién generado no se eliminará. Cierra Opciones y pon la velocidad en 1." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProgressText)), "Estado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ProgressText)), "Inactivo o en curso, más restantes / eliminados / instantánea. Vuelve a abrir Opciones si la línea no se actualiza durante un reset." },
                { m_Setting.GetOptionGroupLocaleID(Setting.kActionGroup), "Reset" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDefaultsGroup), "Valores predeterminados" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kMovingGroup), "Vehículos y peatones en movimiento" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kParkedGroup), "Aparcados" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kPaceGroup), "Ritmo" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kKeybindingGroup), "Atajo" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingCars)), "Coches" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingCars)), "Coches particulares que circulan ahora." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingBicycles)), "Bicicletas" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingBicycles)), "Bicicletas en movimiento ahora." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingTrains)), "Trenes" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingTrains)), "Trenes y metro en movimiento ahora." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingPublicTransport)), "Transporte público" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingPublicTransport)), "Autobuses, taxis y otro transporte público en movimiento (no trenes)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingTrucks)), "Camiones y servicios" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingTrucks)), "Camiones de entrega, basura, policía, bomberos, correo, ambulancias y similares." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingOther)), "Aeronaves y embarcaciones" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingOther)), "Aviones, helicópteros y barcos en movimiento ahora." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemovePedestrians)), "Peatones" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemovePedestrians)), "Cims a pie. Desactivado por defecto. Quienes ya van en un vehículo no se incluyen." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedCars)), "Coches aparcados" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedCars)), "Coches en aparcamientos, en el bordillo y en garajes de edificios (incluidos vehículos de servicio y de depósito). Activado por defecto." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedBicycles)), "Bicicletas aparcadas" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedBicycles)), "Bicicletas paradas. Activado por defecto." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedTrains)), "Trenes aparcados" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedTrains)), "Trenes en depósitos o playas de vías." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedOther)), "Otros aparcados" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedOther)), "Cualquier otro vehículo aparcado (barcos en muelles, aviones en puertas y similares)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VehiclesPerFrame)), "Entidades por fotograma" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VehiclesPerFrame)), "Cuántas entidades quitar en cada lote (1–64)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FrameInterval)), "Fotogramas extra entre lotes" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FrameInterval)), "Esperar tantos fotogramas de pantalla extra tras cada lote. 0 = cada fotograma, 4 ≈ cuatro veces más lento." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetHotkey)), "Atajo de reset" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetHotkey)), "Tecla para poner un reset en cola sin abrir Opciones. Predeterminado F9. Pulsa la tecla y luego otra para reasignar." },
                { m_Setting.GetBindingKeyLocaleID(nameof(Setting.ResetHotkey)), "Restablecer selección" },
                { m_Setting.GetBindingMapLocaleID(), "Reset Traffic" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetBindings)), "Restablecer atajos" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetBindings)), "Restaura el atajo de reset a F9." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableDebugging)), "Registros detallados de reset en Mods_ResetTraffic.log. Ralentiza el juego mientras está activo. Apágalo para velocidad normal." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetModSettings)), "Restablecer valores predeterminados" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetModSettings)), "Restaura filtros de tipo, deslizadores de ritmo y debugging a sus valores originales. No cambia el atajo ni elimina tráfico." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetModSettings)), "¿Restaurar filtros de tipo, deslizadores de ritmo y debugging a los valores predeterminados? Esto no cambia el atajo ni elimina tráfico." },
                { ResetTrafficSystem.FinishDialogTitleId, "Reset Traffic" },
                { ResetTrafficSystem.FinishDialogOkId, "OK" },
                { ResetTrafficSystem.FinishDialogCountsId, "Restantes {REMAINING}  ·  Eliminados {REMOVED}  ·  Instantánea {SNAPSHOT}" },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
