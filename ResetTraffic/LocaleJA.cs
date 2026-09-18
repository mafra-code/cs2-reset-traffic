namespace ResetTraffic
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// AI-generated Options strings from the English meaning. Keys match <see cref="LocaleEN"/>.
    /// </summary>
    public class LocaleJA : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleJA(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Reset Traffic (Beta)" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetVehicles)), "選択をリセット" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetVehicles)), "一度きり：今存在するチェック済みの種類を削除します。新たに出現した交通はそのままです。オプションを閉じ、速度を1にしてください。" },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetVehicles)), "今存在するチェック済みの車両と歩行者をリセットしますか？新たに出現した交通は削除されません。オプションを閉じ、速度を1にしてください。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProgressText)), "状態" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ProgressText)), "待機中または実行中、残り / 削除済み / スナップショット。リセット中に行が更新されない場合はオプションを開き直してください。" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kActionGroup), "Reset" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDefaultsGroup), "デフォルト" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kMovingGroup), "走行中の車両と歩行者" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kParkedGroup), "停車中" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kPaceGroup), "ペース" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kKeybindingGroup), "ホットキー" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingCars)), "車" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingCars)), "走行中の自家用車。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingBicycles)), "自転車" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingBicycles)), "移動中の自転車。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingTrains)), "列車" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingTrains)), "走行中の列車と地下鉄。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingPublicTransport)), "公共交通" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingPublicTransport)), "走行中のバス、タクシー、その他の公共交通（列車以外）。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingTrucks)), "トラックと業務車両" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingTrucks)), "配送トラック、ごみ収集、警察、消防、郵便、救急車など。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingOther)), "航空機と船舶" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingOther)), "移動中の飛行機、ヘリコプター、船。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemovePedestrians)), "歩行者" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemovePedestrians)), "歩いているCims。既定はオフ。すでに車両に乗っている人は対象外です。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedCars)), "駐車中の車" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedCars)), "駐車場、路肩、建物のガレージの車（業務・車庫の車両を含む）。既定はオン。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedBicycles)), "駐輪中の自転車" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedBicycles)), "止まっている自転車。既定はオン。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedTrains)), "停車中の列車" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedTrains)), "車庫や留置線にいる列車。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedOther)), "その他の停車" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedOther)), "その他の停車中の車両（岸壁の船、ゲートの飛行機など）。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VehiclesPerFrame)), "フレームあたりのエンティティ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VehiclesPerFrame)), "各バッチで削除するエンティティ数（1–64）。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FrameInterval)), "バッチ間の追加フレーム" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FrameInterval)), "各バッチ後に待つ追加の表示フレーム数。0 = 毎フレーム、4 ≈ 約4倍遅い。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetHotkey)), "リセットのホットキー" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetHotkey)), "オプションを開かずにリセットを予約するキー。既定はF9。キーをクリックし、新しいキーを押して変更します。" },
                { m_Setting.GetBindingKeyLocaleID(nameof(Setting.ResetHotkey)), "選択をリセット" },
                { m_Setting.GetBindingMapLocaleID(), "Reset Traffic" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetBindings)), "キー割り当てをリセット" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetBindings)), "リセットのホットキーをF9に戻します。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableDebugging)), "Mods_ResetTraffic.logに詳細なリセットログを書き込みます。オンの間はゲームが遅くなります。通常速度にするにはオフにしてください。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetModSettings)), "デフォルトに戻す" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetModSettings)), "種類フィルター、ペーススライダー、デバッグを元の値に戻します。ホットキーは変えず、交通も削除しません。" },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetModSettings)), "種類フィルター、ペーススライダー、デバッグをデフォルトに戻しますか？ホットキーは変わらず、交通も削除されません。" },
                { ResetTrafficSystem.FinishDialogTitleId, "Reset Traffic" },
                { ResetTrafficSystem.FinishDialogOkId, "OK" },
                { ResetTrafficSystem.FinishDialogCountsId, "残り {REMAINING}  ·  削除済み {REMOVED}  ·  スナップショット {SNAPSHOT}" },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
