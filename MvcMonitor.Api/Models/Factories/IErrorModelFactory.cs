namespace MvcMonitor.Api.Models.Factories
{
    public interface IErrorModelFactory
    {
        ErrorModel Create(ElmahErrorRequest elmahErrorRequest);
    }
}