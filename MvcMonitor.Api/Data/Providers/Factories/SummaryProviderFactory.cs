using MvcMonitor.Api.Data.Repositories;
using MvcMonitor.Api.StackTrace;
using MvcMonitor.Api.Utilities;

namespace MvcMonitor.Api.Data.Providers.Factories
{
    public class SummaryProviderFactory : ISummaryProviderFactory
    {
        public ISummaryProvider Create()
        {
            return new SummaryProvider(new ErrorRepositoryFactory().GetRepository(), new DateTimeProvider(), new StackTraceProcessor());
        }
    }
}