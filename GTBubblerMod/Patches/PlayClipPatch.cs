using GTBubblerMod.Behaviours;
using GTBubblerMod.Models;
using HarmonyLib;
using UnityEngine;

namespace GTBubblerMod.Patches
{
    [HarmonyPatch(typeof(AudioSource), nameof(AudioSource.PlayClipAtPoint), typeof(AudioClip), typeof(Vector3))]
    internal class PlayClipPatch
    {
        public static bool Prefix(AudioClip clip, Vector3 position)
        {
            if (clip.name.StartsWith(Constants.Name))
            {
                string itemName = clip.name.Replace(Constants.Name, "");

                BubblerData bubblerData = Main.Instance.GetBubbler(itemName);

                if (bubblerData != null)
                {
                    AudioSource.PlayClipAtPoint(clip, position, bubblerData.Config.AudioPopVolume.Value);
                }

                return false;
            }
            return true;
        }
    }
}
