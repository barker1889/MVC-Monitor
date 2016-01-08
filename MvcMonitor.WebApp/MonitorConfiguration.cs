using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace MvcMonitor
{
    public class MonitorConfiguration
    {
        static MonitorConfiguration()
        {
            Logger.Log.Debug("Loading configuration");

            try
            {
                ApplicationStartTime = DateTime.Now;
                Applications = GetConfiguredApplicationIds();

                ErrorRepository = ConfigurationManager.AppSettings["ErrorRepository"];
                EnableSignalrCrossDomain = bool.Parse(ConfigurationManager.AppSettings["EnableSignalrCrossDomain"]);
            }
            catch (Exception exc)
            {
                Logger.Log.Error("Unable to complete configuration", exc);
            }
        }

        private static List<string> GetConfiguredApplicationIds()
        {
            var appsToMonitor = ConfigurationManager.AppSettings["Applications"];
            var applications = appsToMonitor.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (applications.Count == 0)
            {
                Logger.Log.Warn("Didn't read any application ids to receive errors from. Add them as comma seperated list of strings to the 'Applications' key in app settings");
            }

            return applications;
        }

        public static DateTime ApplicationStartTime { get; private set; }

        public static List<string> Applications { get; private set; }

        public static string ErrorRepository { get; private set; }

        public static bool EnableSignalrCrossDomain { get; set; }
    }
}