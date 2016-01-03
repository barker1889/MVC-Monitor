using MvcMonitor.Api.Models;

namespace MvcMonitor.Api.Broadcaster
{
    public interface ISignalrBroadcaster
    {
        void ErrorReceived(ErrorModel error);
    }
}