using MvcMonitor.Api.Models;

namespace MvcMonitor.Api.ErrorHandling
{
    public interface IErrorProcessor
    {
        void ProcessElmahError(ElmahErrorRequest elmahErrorDetailRequest);
    }
}