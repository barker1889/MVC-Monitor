using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;

namespace MvcMonitor
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteTable.Routes.MapHubs(new HubConfiguration()
                                      {
                                          EnableCrossDomain = MonitorConfiguration.EnableSignalrCrossDomain
                                      });
        }
    }
}