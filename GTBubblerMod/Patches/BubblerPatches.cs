using GTBubblerMod.Behaviours;
using GTBubblerMod.Tools;
using HarmonyLib;

namespace GTBubblerMod.Patches
{
    [HarmonyPatch(typeof(Bubbler))]
    internal class BubblerPatches
    {
        // the spawn patch is used for getting all the unique bubbler cosmetics, a property in the main class then lists them
        [HarmonyPatch("OnSpawn", 0), HarmonyPostfix, HarmonyWrapSafe]
        public static void SpawnPatch(Bubbler __instance)
        {
            // Main.Instance.BubblerSpawned(__instance);
        }

        [HarmonyPatch("OnEnable", 0), HarmonyPostfix, HarmonyWrapSafe]
        public static void EnablePatch(Bubbler __instance)
        {
            Logging.Info($"{__instance.name} enabled (activeSelf: {__instance.gameObject.activeSelf})");
            Main.Instance.BubblerEnabled(__instance);
        }
    }
}
