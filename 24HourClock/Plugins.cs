using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using _24HourClock.Patches;

namespace _24HourClock
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class PluginBase : BaseUnityPlugin
    {
        private const string modGUID = "zoomstv.24HourClock";
        private const string modName = "24HourClock";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        public static PluginBase Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("24HourClock has awakened");

            harmony.PatchAll(typeof(PluginBase));
            harmony.PatchAll(typeof(HUDManagerPatch));
        }
    }
}
