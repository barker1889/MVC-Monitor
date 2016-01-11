using System;

namespace MvcMonitor.Data.Repositories
{
    public class ErrorRepositoryFactory : IErrorRepositoryFactory
    {
        private readonly string _repositoryType;
        private IErrorRepository _currentRepository;

        public ErrorRepositoryFactory()
            : this(MonitorConfiguration.ErrorRepository)
        {
        }

        public ErrorRepositoryFactory(string repositoryType)
        {
            _repositoryType = repositoryType;
        }

        public IErrorRepository GetRepository()
        {
            if (_currentRepository == null)
            {
                try
                {
                    Logger.Log.Debug(string.Format("Creating instance of {0}", MonitorConfiguration.ErrorRepository));

                    var configuredRepository = Activator.CreateInstance(Type.GetType(_repositoryType));
                    _currentRepository = (IErrorRepository)configuredRepository;
                }
                catch (Exception exc)
                {
                    Logger.Log.Error(
                        string.Format("Unable to create an instance of [{0}]. Ensure that the full name of the class is set in the 'ErrorRepository' app setting, that it has a default constructor and implements IErrorRepository", _repositoryType), 
                        exc);
                    throw;
                }
            }

            return _currentRepository;
        }
    }
}