using System.Collections.Generic;
using MvcMonitor.Api.Models;

namespace MvcMonitor.Api.ErrorHandling
{
    public interface IErrorDataFactory
    {
        List<ErrorLocationModel> GetErrorLocations();
    }
}