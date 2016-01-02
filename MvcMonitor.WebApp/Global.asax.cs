using System;
using System.Web.Mvc;
using System.Web.Routing;
using log4net.Config;

namespace MvcMonitor
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            XmlConfigurator.Configure();

            try
            {
                AreaRegistration.RegisterAllAreas();
                RouteTable.Routes.MapHubs();
            }
            catch (Exception exc)
            {
                Logger.Log.Error("There was an error starting the application", exc);
            }

            Logger.Log.Info("Application started");
        }
    }
}