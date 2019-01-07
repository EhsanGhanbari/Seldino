using System.Configuration;

namespace Seldino.Infrastructure.Helpers
{
    public class ConfigurationHelper
    {
        public static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
