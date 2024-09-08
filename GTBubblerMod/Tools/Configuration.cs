using BepInEx.Configuration;

namespace GTBubblerMod.Tools
{
    internal class Configuration
    {
        private static ConfigFile File;

        public static void Initialize(ConfigFile configFile)
        {
            File = configFile;
        }

        public static ConfigEntry<T> BindEntry<T>(ConfigDefinition configDefinition, T defaultValue, ConfigDescription configDescription)
        {
            return File.Bind(configDefinition, defaultValue, configDescription);
        }
    }
}
