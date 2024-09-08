using BepInEx;
using GTBubblerMod.Behaviours;
using GTBubblerMod.Tools;
using HarmonyLib;
using System;
using UnityEngine;

namespace GTBubblerMod
{
    [BepInPlugin(Constants.GUID, Constants.Name, Constants.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public void Awake()
        {
            Configuration.Initialize(Config);
            Logging.Initialize(Logger);

            GorillaTagger.OnPlayerSpawned(Initialize);

            Harmony.CreateAndPatchAll(typeof(Plugin).Assembly, Constants.GUID);

            Logging.Info("Plugin Awake");
        }

        public void Initialize()
        {
            try
            {
                new GameObject(typeof(Main).FullName).AddComponent<Main>();
            }
            catch(Exception ex)
            {
                Logging.Error($"Plugin could not be initialized: {ex}");
            }
        }
    }
}
