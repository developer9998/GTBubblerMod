using GTBubblerMod.Tools;
using System.Collections.Generic;
using UnityEngine;
using GorillaNetworking;
using GTBubblerMod.Models;
using System.IO;
using GTBubblerMod.Extensions;
using System.Linq;

namespace GTBubblerMod.Behaviours
{
    public class Main : MonoBehaviour
    {
        public static Main Instance;

        private string directoryName;

        private readonly List<Bubbler> bubblerTotalList = [];

        public string BubblerList
        {
            get
            {
                List<string> bubblerNames = bubblerTotalList.Select(bubbler => bubbler.name).Distinct().ToList();

                for(int i = 0; i < bubblerNames.Count; i++)
                {
                    var bubbler = bubblerNames[i];

                    CosmeticsController.CosmeticItem item = CosmeticsController.instance.GetItemFromDict(bubbler);

                    if (item.isNullItem || item.Equals(default))
                    {
                        continue;
                    }

                    bubblerNames[i] = $"{CosmeticsController.instance.GetItemDisplayName(item).ToLower().ToTitleCase()} ({item.itemName})";
                }

                return string.Join("\n", bubblerNames);
            }
        }

        private readonly Dictionary<CosmeticsController.CosmeticItem, BubblerData> bubblerDataList = [];

        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }

            directoryName = Path.GetDirectoryName(typeof(Plugin).Assembly.Location);

            Logging.Info("Main Awake");
        }

        public BubblerData GetBubbler(string itemName)
        {
            CosmeticsController.CosmeticItem item = CosmeticsController.instance.GetItemFromDict(itemName);

            if (item.isNullItem || item.Equals(default))
            {
                Logging.Error($"{itemName} could not be found in cosmetic dictionary");
                return null;
            }

            return GetBubbler(item);
        }

        public BubblerData GetBubbler(CosmeticsController.CosmeticItem item)
        {
            if (bubblerDataList.TryGetValue(item, out var bubbler))
            {
                return bubbler;
            }
            return null;
        }

        public void BubblerSpawned(Bubbler bubbler)
        {
            if (!bubblerTotalList.Contains(bubbler))
            {
                bubblerTotalList.Add(bubbler);
            }
        }

        public void BubblerEnabled(Bubbler bubbler)
        {
            CosmeticsController.CosmeticItem item = CosmeticsController.instance.GetItemFromDict(bubbler.name);

            if (item.isNullItem || item.Equals(default))
            {
                Logging.Error($"{bubbler.name} could not be found in cosmetic dictionary");
                return;
            }

            if (bubblerDataList.TryGetValue(item, out BubblerData data))
            {
                if (data.LoopAudio)
                {
                    bubbler.bubblerAudio.clip = data.LoopAudio;

                    if (data.Config.AudioLoopVolume.Value > 1f)
                    {
                        bubbler.bubblerAudio.volume = 1f;
                        bubbler.AddComponent<AudioDistortionFilter>().distortionLevel = data.Config.AudioLoopVolume.Value - 1f;
                    }
                    else
                    {
                        bubbler.bubblerAudio.volume = data.Config.AudioLoopVolume.Value;
                    }

                    if (data.Config.RetainLoopTime.Value)
                    {
                        bubbler.AddComponent<BubblerTimeHelper>();
                    }
                }
                if (data.PopAudio)
                {
                    bubbler.popBubbleAudio.clip = data.PopAudio;

                    if (data.Config.AudioPopVolume.Value > 1f)
                    {
                        bubbler.popBubbleAudio.volume = 1f;
                        bubbler.AddComponent<AudioDistortionFilter>().distortionLevel = data.Config.AudioPopVolume.Value - 1f;
                    }
                    else
                    {
                        bubbler.popBubbleAudio.volume = data.Config.AudioPopVolume.Value;
                    }
                }
                return;
            }

            Logging.Info($"Registering bubbler {item.itemName}");

            bool hasLoopAudio = bubbler.bubblerAudio;

            bool hasPopAudio = bubbler.popBubbleAudio;

            data = new(item);

            if (hasLoopAudio)
            {
                data.LoadAudio(directoryName, data.Config.AudioLoopPath, (AudioClip loopAudio) =>
                {
                    data.LoopAudio = loopAudio;
                    bubbler.bubblerAudio.clip = loopAudio;

                    if (data.Config.AudioLoopVolume.Value > 1f)
                    {
                        bubbler.bubblerAudio.volume = 1f;
                        bubbler.AddComponent<AudioDistortionFilter>().distortionLevel = data.Config.AudioLoopVolume.Value - 1f;
                    }
                    else
                    {
                        bubbler.bubblerAudio.volume = data.Config.AudioLoopVolume.Value;
                    }

                    if (data.Config.RetainLoopTime.Value)
                    {
                        bubbler.AddComponent<BubblerTimeHelper>();
                    }

                    Logging.Info("Added LoopAudio clip");
                });
            }

            if (hasPopAudio)
            {
                data.LoadAudio(directoryName, data.Config.AudioPopPath, (AudioClip popAudio) =>
                {
                    popAudio.name = string.Concat(Constants.Name, item.itemName);
                    data.PopAudio = popAudio;
                    bubbler.popBubbleAudio.clip = popAudio;

                    if (data.Config.AudioPopVolume.Value > 1f)
                    {
                        bubbler.popBubbleAudio.volume = 1f;
                        bubbler.AddComponent<AudioDistortionFilter>().distortionLevel = data.Config.AudioPopVolume.Value - 1f;
                    }
                    else
                    {
                        bubbler.popBubbleAudio.volume = data.Config.AudioPopVolume.Value;
                    }

                    Logging.Info("Added PopAudio clip");
                });
            }

            bubblerDataList[item] = data;

            Logging.Info("Registered");
        }
    }
}