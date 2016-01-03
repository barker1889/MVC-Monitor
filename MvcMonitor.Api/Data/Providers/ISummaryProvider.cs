using System.Collections.Generic;
using MvcMonitor.Api.Models;

namespace MvcMonitor.Api.Data.Providers
{
    public interface ISummaryProvider
    {
        IEnumerable<string> GetErrorLocationsForApplication(string applications);

        ErrorModel GetLatestError();
        ErrorModel GetLatestErrorForApplication(string application);

        int GetTotalErrorCount();
        int GetTotalErrorCountForApplication(string application);
    }
}