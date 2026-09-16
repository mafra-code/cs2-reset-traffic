namespace ResetTraffic
{
    using Colossal.IO.AssetDatabase;
    using Colossal.Logging;
    using Game;
    using Game.Modding;
    using Game.SceneFlow;

    public class Mod : IMod
    {
        public const string Id = "ResetTraffic";

        public static Mod Instance { get; private set; }

        internal ILog Logger { get; private set; }

        internal Setting Settings { get; private set; }

        public void OnLoad(UpdateSystem updateSystem)
        {
            Instance = this;
            Logger = LogManager.GetLogger("Mods_ResetTraffic").SetShowsErrorsInUI(false);
            Logger.Info(nameof(OnLoad));

            Settings = new Setting(this);
            Settings.RegisterInOptionsUI();
            // Locale sources must be added before LoadSettings so the binding default (F9) is labeled.
            GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN(Settings));
            GameManager.instance.localizationManager.AddSource("de-DE", new LocaleDE(Settings));
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
