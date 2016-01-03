using System;
using MvcMonitor.Api.Models;

namespace MvcMonitor.Api.Data.Providers
{
    public interface IIndexProvider
    {
        PagedList<ErrorModel> GetErrors(int pageNumber, int pageSize, DateTime? filterFrom, DateTime? filterTo,
                                        string filterUser, string filterApplication, string filterLocation);
    }
}