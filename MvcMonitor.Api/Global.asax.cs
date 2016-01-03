using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using log4net.Config;

namespace MvcMonitor.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //XmlConfigurator.Configure();

            //try
            //{
            //    GlobalConfiguration.Configure(WebApiConfig.Register);
            //    RouteTable.Routes.MapHubs();
            //}
            //catch (Exception exc)
            //{
            //    Logger.Log.Error("There was an error starting the application", exc);
            //}

            //Logger.Log.Info("Application started");
        }
    }
}
