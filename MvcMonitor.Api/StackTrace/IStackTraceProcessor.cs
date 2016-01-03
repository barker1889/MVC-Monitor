using MvcMonitor.Api.Models;

namespace MvcMonitor.Api.StackTrace
{
    public interface IStackTraceProcessor
    {
        StackTraceLocationResult GetLocalLocations(string stackTrace);
    }
}