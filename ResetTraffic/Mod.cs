namespace ResetTraffic
{
    using Colossal.IO.AssetDatabase;
    using Colossal.Logging;
    using Game;
    using Game.Modding;
    using Game.SceneFlow;

    /// <summary>
    /// Official CS2 <see cref="IMod"/> entry (no Harmony). Wires Options, locales, persisted
    /// settings, and <see cref="ResetTrafficSystem"/> into ToolUpdate so Deleted tags share
    /// that frame's tool ECB.
    /// </summary>
    public class Mod : IMod
    {
        public const string Id = "ResetTraffic";

        /// <summary>
        /// Live mod instance. Options and the system reach logger/settings through this;
        /// cleared in <see cref="OnDispose"/> so a leftover reference cannot outlive unload.
        /// </summary>
        public static Mod Instance { get; private set; }

        /// <summary>Writes <c>Mods_ResetTraffic.log</c> under the game's Logs folder.</summary>
        internal ILog Logger { get; private set; }

        internal Setting Settings { get; private set; }

        public void OnLoad(UpdateSystem updateSystem)
        {
            Instance = this;
            // Keep errors in the log only; flashing them in the HUD during a mass despawn is noisy.
            Logger = LogManager.GetLogger("Mods_ResetTraffic").SetShowsErrorsInUI(false);
            Logger.Info(nameof(OnLoad));

            Settings = new Setting(this);
            Settings.RegisterInOptionsUI();
            // Locale sources must be added before LoadSettings so the binding default (F9) is labeled.
            GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN(Settings));
            GameManager.instance.localizationManager.AddSource("de-DE", new LocaleDE(Settings));
            GameManager.instance.localizationManager.AddSource("es-ES", new LocaleES(Settings));
            GameManager.instance.localizationManager.AddSource("fr-FR", new LocaleFR(Settings));
            GameManager.instance.localizationManager.AddSource("it-IT", new LocaleIT(Settings));
            GameManager.instance.localizationManager.AddSource("ja-JP", new LocaleJA(Settings));
            GameManager.instance.localizationManager.AddSource("ko-KR", new LocaleKO(Settings));
            GameManager.instance.localizationManager.AddSource("pl-PL", new LocalePL(Settings));
            GameManager.instance.localizationManager.AddSource("pt-BR", new LocalePT(Settings));
            GameManager.instance.localizationManager.AddSource("ru-RU", new LocaleRU(Settings));
            GameManager.instance.localizationManager.AddSource("zh-HANS", new LocaleZHHans(Settings));
            GameManager.instance.localizationManager.AddSource("zh-HANT", new LocaleZHHant(Settings));
            AssetDatabase.global.LoadSettings(nameof(ResetTraffic), Settings, new Setting(this));

            // ToolUpdate: same phase as other tool deletes, paired with ToolOutputBarrier in the system.
            updateSystem.UpdateAt<ResetTrafficSystem>(SystemUpdatePhase.ToolUpdate);
            Logger.Info($"{nameof(OnLoad)} complete.");
        }

        public void OnDispose()
        {
            Logger?.Info("Disposing.");
            if (Settings != null)
            {
                Settings.UnregisterInOptionsUI();
                Settings = null;
            }

            Instance = null;
        }
    }
}
