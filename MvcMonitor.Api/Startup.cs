using System;
using System.Web.Http;
using log4net.Config;
using Owin;

namespace MvcMonitor.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            XmlConfigurator.Configure();

            try
            {
                GlobalConfiguration.Configure(WebApiConfig.Register);
                app.MapSignalR();
            }
            catch (Exception exc)
            {
                Logger.Log.Error("There was an error starting the application", exc);
            }

            Logger.Log.Info("Application started");
        }
    }
}