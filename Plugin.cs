using BepInEx;
using HarmonyLib;


namespace TreysBladeHealthText
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        public const string pluginGuid = "aoq.treysbladehealthtext";
        public const string pluginName = "Treys Blade Health Text";
        public const string pluginVersion = "1.0.0";
        internal static BepInEx.Logging.ManualLogSource PluginLogger;

        public void Awake()
        {
            PluginLogger = Logger;
            
            Logger.LogInfo("Plugin TreysBladeHealthText is loaded!");
            
            Harmony harmony = new Harmony("TreysHealthText");
            harmony.PatchAll();

            Logger.LogInfo("Harmony patches applied.");
        }
    }
}
