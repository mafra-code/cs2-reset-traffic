namespace ResetTraffic
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// AI-generated Options strings from the English meaning. Keys match <see cref="LocaleEN"/>.
    /// </summary>
    public class LocaleRU : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleRU(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Reset Traffic (Beta)" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetVehicles)), "Сбросить выбранное" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetVehicles)), "Один раз: удаляет отмеченные типы, которые существуют сейчас. Только что появившийся транспорт не трогается. Закройте «Параметры», затем поставьте скорость 1." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetVehicles)), "Сбросить отмеченные транспорт и пешеходов, которые существуют сейчас? Только что появившийся транспорт не будет удалён. Закройте «Параметры», затем поставьте скорость 1." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProgressText)), "Статус" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ProgressText)), "Ожидание или выполнение, плюс осталось / удалено / снимок. Откройте «Параметры» заново, если строка не обновляется во время сброса." },
                { m_Setting.GetOptionGroupLocaleID(Setting.kActionGroup), "Reset" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDefaultsGroup), "По умолчанию" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kMovingGroup), "Движущийся транспорт и пешеходы" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kParkedGroup), "Припаркованные" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kPaceGroup), "Темп" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kKeybindingGroup), "Горячая клавиша" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingCars)), "Легковые" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingCars)), "Личные автомобили, которые сейчас едут." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingBicycles)), "Велосипеды" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingBicycles)), "Велосипеды, которые сейчас движутся." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingTrains)), "Поезда" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingTrains)), "Поезда и метро, которые сейчас движутся." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingPublicTransport)), "Общественный транспорт" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingPublicTransport)), "Автобусы, такси и другой движущийся общественный транспорт (не поезда)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingTrucks)), "Грузовики и службы" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingTrucks)), "Грузовики доставки, мусор, полиция, пожарные, почта, скорая и подобное." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingOther)), "Самолёты и суда" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingOther)), "Самолёты, вертолёты и лодки, которые сейчас движутся." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemovePedestrians)), "Пешеходы" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemovePedestrians)), "Идущие Cims. По умолчанию выкл. Люди уже в транспорте не затрагиваются." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedCars)), "Припаркованные легковые" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedCars)), "Автомобили на стоянках, у бордюра и в гаражах зданий (включая служебный и деповский транспорт). По умолчанию вкл." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedBicycles)), "Припаркованные велосипеды" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedBicycles)), "Стоящие велосипеды. По умолчанию вкл." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedTrains)), "Припаркованные поезда" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedTrains)), "Поезда в депо или на отстойных путях." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedOther)), "Прочие припаркованные" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedOther)), "Любой другой припаркованный транспорт (лодки у причалов, самолёты у гейтов и подобное)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VehiclesPerFrame)), "Объекты за кадр" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VehiclesPerFrame)), "Сколько объектов удалять в каждой партии (1–64)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FrameInterval)), "Доп. кадры между партиями" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FrameInterval)), "Сколько дополнительных кадров отображения ждать после каждой партии. 0 = каждый кадр, 4 ≈ в четыре раза медленнее." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetHotkey)), "Горячая клавиша сброса" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetHotkey)), "Клавиша ставит сброс в очередь без открытия «Параметров». По умолчанию F9. Нажмите клавишу, затем новую, чтобы переназначить." },
                { m_Setting.GetBindingKeyLocaleID(nameof(Setting.ResetHotkey)), "Сбросить выбранное" },
                { m_Setting.GetBindingMapLocaleID(), "Reset Traffic" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetBindings)), "Сбросить привязки клавиш" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetBindings)), "Возвращает горячую клавишу сброса на F9." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableDebugging)), "Подробные журналы сброса в Mods_ResetTraffic.log. Замедляет игру, пока включено. Выключите для обычной скорости." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetModSettings)), "Сбросить к умолчаниям" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetModSettings)), "Восстанавливает фильтры типов, ползунки темпа и отладку к исходным значениям. Не меняет горячую клавишу и не удаляет транспорт." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetModSettings)), "Восстановить фильтры типов, ползунки темпа и отладку к значениям по умолчанию? Это не меняет горячую клавишу и не удаляет транспорт." },
                { ResetTrafficSystem.FinishDialogTitleId, "Reset Traffic" },
                { ResetTrafficSystem.FinishDialogOkId, "OK" },
                { ResetTrafficSystem.FinishDialogCountsId, "Осталось {REMAINING}  ·  Удалено {REMOVED}  ·  Снимок {SNAPSHOT}" },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
