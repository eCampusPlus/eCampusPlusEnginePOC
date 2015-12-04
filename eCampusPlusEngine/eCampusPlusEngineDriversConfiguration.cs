using System.Configuration;
using eCampusPlus.Engine.Configuration.Drivers;

namespace eCampusPlus.Engine.Configuration
{
    /// <summary>
    ///     The Automated Testing Framework configuration
    /// </summary>
    public static class eCampusPlusEngineDriversConfiguration
    {
        /// <summary>
        ///     Gets the drivers path
        /// </summary>
        public static string DriversPath
        {
            get
            {
                if (ConfigurationManager.AppSettings["Drivers"] != null)
                    return ConfigurationManager.AppSettings["Drivers"];
                return "";
            }
        }

        

        /// <summary>
        ///     Gets the ICampusPlusEngine browser
        /// </summary>
        public static string eCampusPlusEngine_Browser
        {
            get
            {
                if (ConfigurationManager.AppSettings["eCampusPlusEngine_Browser"] != null)
                    return ConfigurationManager.AppSettings["eCampusPlusEngine_Browser"];
                return "";
            }
        }

        /// <summary>
        ///     Gets the ICampusPlusEngine environment
        /// </summary>
        public static string eCampusPlusEngine_Environement
        {
            get
            {
                if (ConfigurationManager.AppSettings["eCampusPlusEngine_Environement"] != null)
                    return ConfigurationManager.AppSettings["eCampusPlusEngine_Environement"];
                return "";
            }
        }

        /// <summary>
        ///     Gets the Chrome driver port
        /// </summary>
        public static string ChromeDriverPort
        {
            get
            {
                if (ConfigurationManager.AppSettings["ChromeDriverPort"] != null)
                    return ConfigurationManager.AppSettings["ChromeDriverPort"];
                return "";
            }
        }

        /// <summary>
        ///     Gets the IE driver port
        /// </summary>
        public static string IeDriverPort
        {
            get
            {
                if (ConfigurationManager.AppSettings["IeDriverPort"] != null)
                    return ConfigurationManager.AppSettings["IeDriverPort"];
                return "";
            }
        }

    }
}