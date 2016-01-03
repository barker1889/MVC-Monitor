using MvcMonitor.Api.Broadcaster;
using MvcMonitor.Api.Data.Repositories;
using MvcMonitor.Api.Models;
using MvcMonitor.Api.Models.Factories;

namespace MvcMonitor.Api.ErrorHandling
{
    public class ErrorProcessor : IErrorProcessor
    {
        private readonly IErrorModelFactory _errorModelFactory;
        private readonly ISignalrBroadcasterFactory _signalrBroadcasterFactory;
        private readonly IErrorRepositoryFactory _errorRepositoryFactory;

        public ErrorProcessor()
            : this(new ErrorModelFactory(), new SignalrBroadcasterFactory(), new ErrorRepositoryFactory())
        {
        }

        public ErrorProcessor(IErrorModelFactory errorModelFactory, ISignalrBroadcasterFactory signalrBroadcasterFactory, IErrorRepositoryFactory errorRepositoryFactory)
        {
            _errorModelFactory = errorModelFactory;
            _signalrBroadcasterFactory = signalrBroadcasterFactory;
            _errorRepositoryFactory = errorRepositoryFactory;
        }

        public void ProcessElmahError(ElmahErrorRequest elmahErrorDetailRequest)
        {
            var error = _errorModelFactory.Create(elmahErrorDetailRequest);
            
            var repository = _errorRepositoryFactory.GetRepository();
            repository.Add(error);

            PublishErrorReceivedCallback(error);
        }

        private void PublishErrorReceivedCallback(ErrorModel error)
        {
            var signalrBroadcaster = _signalrBroadcasterFactory.Create();
            signalrBroadcaster.ErrorReceived(error);
        }
    }
}