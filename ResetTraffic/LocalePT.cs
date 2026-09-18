namespace ResetTraffic
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// AI-generated Options strings from the English meaning. Keys match <see cref="LocaleEN"/>.
    /// </summary>
    public class LocalePT : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocalePT(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Reset Traffic (Beta)" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetVehicles)), "Redefinir selecionados" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetVehicles)), "Uma vez: remove os tipos marcados que existem agora. O tráfego recém-gerado não é mexido. Feche Opções e defina a velocidade para 1." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetVehicles)), "Redefinir os veículos e pedestres marcados que existem agora? O tráfego recém-gerado não será removido. Feche Opções e defina a velocidade para 1." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProgressText)), "Status" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ProgressText)), "Inativo ou em andamento, mais restantes / removidos / instantâneo. Reabra Opções se a linha não atualizar durante um reset." },
                { m_Setting.GetOptionGroupLocaleID(Setting.kActionGroup), "Reset" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDefaultsGroup), "Padrões" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kMovingGroup), "Veículos e pedestres em movimento" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kParkedGroup), "Estacionados" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kPaceGroup), "Ritmo" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kKeybindingGroup), "Atalho" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingCars)), "Carros" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingCars)), "Carros particulares em circulação." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingBicycles)), "Bicicletas" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingBicycles)), "Bicicletas em movimento." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingTrains)), "Trens" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingTrains)), "Trens e metrô em movimento." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingPublicTransport)), "Transporte público" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingPublicTransport)), "Ônibus, táxis e outro transporte público em movimento (não trens)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingTrucks)), "Caminhões e serviços" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingTrucks)), "Caminhões de entrega, lixo, polícia, bombeiros, correio, ambulâncias e similares." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingOther)), "Aeronaves e embarcações" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingOther)), "Aviões, helicópteros e barcos em movimento." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemovePedestrians)), "Pedestres" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemovePedestrians)), "Cims a pé. Desligado por padrão. Quem já está em veículos não é alvo." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedCars)), "Carros estacionados" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedCars)), "Carros em estacionamentos, na guia e em garagens de prédios (incluindo veículos de serviço e de depósito). Ligado por padrão." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedBicycles)), "Bicicletas estacionadas" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedBicycles)), "Bicicletas paradas. Ligado por padrão." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedTrains)), "Trens estacionados" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedTrains)), "Trens em depósitos ou pátios." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedOther)), "Outros estacionados" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedOther)), "Qualquer outro veículo estacionado (barcos em docas, aviões em portões e similares)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VehiclesPerFrame)), "Entidades por quadro" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VehiclesPerFrame)), "Quantas entidades remover em cada lote (1–64)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FrameInterval)), "Quadros extras entre lotes" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FrameInterval)), "Esperar tantos quadros de tela extras após cada lote. 0 = todo quadro, 4 ≈ quatro vezes mais lento." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetHotkey)), "Atalho de reset" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetHotkey)), "Tecla para enfileirar um reset sem abrir Opções. Padrão F9. Clique a tecla e pressione outra para reatribuir." },
                { m_Setting.GetBindingKeyLocaleID(nameof(Setting.ResetHotkey)), "Redefinir selecionados" },
                { m_Setting.GetBindingMapLocaleID(), "Reset Traffic" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetBindings)), "Redefinir atalhos" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetBindings)), "Restaura o atalho de reset para F9." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableDebugging)), "Logs detalhados de reset em Mods_ResetTraffic.log. Deixa o jogo mais lento enquanto ligado. Desligue para velocidade normal." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetModSettings)), "Restaurar padrões" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetModSettings)), "Restaura filtros de tipo, controles de ritmo e debugging aos valores originais. Não altera o atalho nem remove tráfego." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetModSettings)), "Restaurar filtros de tipo, controles de ritmo e debugging aos valores padrão? Isso não altera o atalho nem remove tráfego." },
                { ResetTrafficSystem.FinishDialogTitleId, "Reset Traffic" },
                { ResetTrafficSystem.FinishDialogOkId, "OK" },
                { ResetTrafficSystem.FinishDialogCountsId, "Restantes {REMAINING}  ·  Removidos {REMOVED}  ·  Instantâneo {SNAPSHOT}" },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
