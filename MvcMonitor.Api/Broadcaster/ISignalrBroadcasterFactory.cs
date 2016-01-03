namespace MvcMonitor.Api.Broadcaster
{
    public interface ISignalrBroadcasterFactory
    {
        ISignalrBroadcaster Create();
    }
}