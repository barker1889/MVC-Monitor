using System;

namespace MvcMonitor.Api.Utilities
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow();
    }
}