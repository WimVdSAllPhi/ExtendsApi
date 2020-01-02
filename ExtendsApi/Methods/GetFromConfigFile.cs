using System;
using System.Configuration;

namespace ExtendsApi.Methods
{
    public class GetFromConfigFile
    {
        public static TType TryGetConfigValue<TType>(string appSettings, TType defaultValue)
        {
            if (string.IsNullOrEmpty(appSettings))
                return defaultValue;

            TType tmp;
            try
            {
                string configurationValue = ConfigurationManager.AppSettings[appSettings];
                if (configurationValue != null)
                {
                    tmp = (TType)Convert.ChangeType(configurationValue, typeof(TType));
                    if (tmp == null)
                    {
                        tmp = defaultValue;
                    }
                }
                else
                {
                    tmp = defaultValue;
                }
            }
            catch
            {
                tmp = defaultValue;
            }

            return tmp;
        }
    }
}
