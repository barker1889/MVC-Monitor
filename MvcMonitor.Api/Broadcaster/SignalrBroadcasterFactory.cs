using Microsoft.AspNet.SignalR;
using MvcMonitor.Api.ErrorHandling;

namespace MvcMonitor.Api.Broadcaster
{
    public class SignalrBroadcasterFactory : ISignalrBroadcasterFactory
    {
        public ISignalrBroadcaster Create()
        {
            return new SignalrBroadcaster(GlobalHost.ConnectionManager.GetHubContext<ErrorHub>().Clients);
        }
    }
}