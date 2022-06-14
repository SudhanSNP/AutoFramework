using System.Configuration;
using System.Reflection;

namespace Helpers.Configuration
{
    public static class ConfigurationSetting
    {
        public static string AssemblyPath;

        public static string Get(string key)
        {
            return ConfigurationManager.OpenExeConfiguration(AssemblyPath)
                .AppSettings.Settings[key].Value;
        }
    }
}
