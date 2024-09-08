using BepInEx.Configuration;
using GorillaNetworking;
using GTBubblerMod.Tools;
using System;
using System.IO;
using UnityEngine;

namespace GTBubblerMod.Models
{
    public class BubblerData(CosmeticsController.CosmeticItem item)
    {
        public CosmeticsController.CosmeticItem Item = item;

        public BubblerConfig Config = new(item);

        public AudioClip LoopAudio;

        public AudioClip PopAudio;

        public async void LoadAudio(string directoryName, ConfigEntry<string> configEntry, Action<AudioClip> onAudioLoaded)
        {
            if (string.IsNullOrEmpty(configEntry.Value) || string.IsNullOrWhiteSpace(configEntry.Value)) return;

            string path = Path.Combine(directoryName, configEntry.Value);

            if (!File.Exists(path))
            {
                Logging.Warning($"Path of {configEntry.Definition.Key} for {configEntry.Definition.Section} does not exist");
                configEntry.Value = "";
                return;
            }

            AudioClip audio = await SoundLoader.LoadClip(path);

            if (audio == null)
            {
                Logging.Warning($"Audio loaded from {configEntry.Definition.Key} for {configEntry.Definition.Section} is null");
                configEntry.Value = "";
            }

            onAudioLoaded?.Invoke(audio);
        }
    }
}
