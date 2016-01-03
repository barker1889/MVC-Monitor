using Microsoft.AspNet.SignalR.Hubs;
using MvcMonitor.Api.Models;

namespace MvcMonitor.Api.Broadcaster
{
    public class SignalrBroadcaster : ISignalrBroadcaster
    {
        private readonly IHubConnectionContext<dynamic> _context;

        public SignalrBroadcaster(IHubConnectionContext<dynamic> context)
        {
            _context = context;
        }

        public void ErrorReceived(ErrorModel error)
        {
            _context.All.errorReceived(error);
        }
    }
}