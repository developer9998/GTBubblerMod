using BepInEx.Configuration;
using GTBubblerMod.Tools;
using GorillaNetworking;
using GTBubblerMod.Extensions;

namespace GTBubblerMod.Models
{
    public class BubblerConfig
    {
        public CosmeticsController.CosmeticItem Item;

        public ConfigEntry<string> AudioLoopPath;

        public ConfigEntry<float> AudioLoopVolume;

        public ConfigEntry<bool> RetainLoopTime;

        public ConfigEntry<string> AudioPopPath;

        public ConfigEntry<float> AudioPopVolume;

        public ConfigEntry<bool> UseVibrations;

        // public ConfigEntry<bool> LoopAudio;

        public BubblerConfig(CosmeticsController.CosmeticItem item)
        {
            Item = item;
            string configSection = $"{CosmeticsController.instance.GetItemDisplayName(Item).ToLower().ToTitleCase()} ({item.itemName})";
            AudioLoopPath = Configuration.BindEntry(new ConfigDefinition(configSection, "Audio Loop Path"), "", new ConfigDescription("Audio path for the looped bubbler sound"));
            AudioLoopVolume = Configuration.BindEntry(new ConfigDefinition(configSection, "Audio Loop Volume"), 1f, new ConfigDescription("Audio volume for the looped bubbler sound", new AcceptableValueRange<float>(0f, 1.5f)));
            RetainLoopTime = Configuration.BindEntry(new ConfigDefinition(configSection, "Retain Loop Time"), true, new ConfigDescription("Whether the looped bubbler sound will resume after being stopped"));
            AudioPopPath = Configuration.BindEntry(new ConfigDefinition(configSection, "Audio Pop Path"), "", new ConfigDescription("Audio path for the bubbler pop sound"));
            AudioPopVolume = Configuration.BindEntry(new ConfigDefinition(configSection, "Audio Pop Volume"), 1f, new ConfigDescription("Audio volume for the bubbler pop sound", new AcceptableValueRange<float>(0f, 1.5f)));
            UseVibrations = Configuration.BindEntry(new ConfigDefinition(configSection, "Use Vibrations"), true, new ConfigDescription("Whether the bubbler will vibrate the controller when active"));
            // LoopAudio = Configuration.BindEntry(new ConfigDefinition(configSection, "Loop Audio"), true, new ConfigDescription("Whether the looped bubbler sound is looped"));
        }
    }
}
