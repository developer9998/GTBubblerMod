using HarmonyLib;

namespace GTBubblerMod.Patches
{
    [HarmonyPatch(typeof(GorillaTagger), nameof(GorillaTagger.StartVibration))]
    internal class VibrationPatch
    {
        public static bool Prefix(float duration)
        {
            return duration >= 0f;
        }
    }
}
