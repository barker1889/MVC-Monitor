using MvcMonitor.Api.Models;
using NHibernate;

namespace MvcMonitor.Api.Data.Repositories.NHibernate
{
    public class SessionHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = new global::NHibernate.Cfg.Configuration();
                    configuration.Configure();
                    configuration.AddAssembly(typeof(ErrorModel).Assembly);
                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}