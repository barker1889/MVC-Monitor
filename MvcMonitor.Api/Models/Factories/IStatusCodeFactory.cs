using System.Net;

namespace MvcMonitor.Api.Models.Factories
{
    public interface IStatusCodeFactory
    {
        HttpStatusCode Create(string httpStatusCode);
    }
}