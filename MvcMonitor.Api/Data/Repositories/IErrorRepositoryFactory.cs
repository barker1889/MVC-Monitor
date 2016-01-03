namespace MvcMonitor.Api.Data.Repositories
{
    public interface IErrorRepositoryFactory
    {
        IErrorRepository GetRepository();
    }
}