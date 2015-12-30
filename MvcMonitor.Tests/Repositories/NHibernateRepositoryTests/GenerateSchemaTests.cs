using MvcMonitor.Models;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace MvcMonitor.Tests.Repositories.NHibernateRepositoryTests
{
    [TestFixture]
    [Category("NHibernateRepository")]
    public class GenerateSchemaTests
    {
        [Test]
        public void CanGenerateSchema()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(ErrorModel).Assembly);

            new SchemaExport(cfg).Execute(false, true, false);
        }
    }
}
