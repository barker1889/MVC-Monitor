﻿using System;
using System.Net;
using MvcMonitor.Data.Repositories;
using MvcMonitor.Data.Repositories.NHibernate;
using MvcMonitor.Models;
using NHibernate;
using NHibernate.Cfg;
using NUnit.Framework;

namespace MvcMonitor.Tests.Repositories.NHibernateRepositoryTests
{
    [TestFixture]
    [Category("NHibernateRepository")]
    public class AddTests
    {
        private ISessionFactory _sessionFactory;
        private Configuration _monitorConfiguration;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _monitorConfiguration = new Configuration();
            _monitorConfiguration.Configure();
            _monitorConfiguration.AddAssembly(typeof(ErrorModel).Assembly);
            _sessionFactory = _monitorConfiguration.BuildSessionFactory();
        }

        [Test]
        public void ThenWeCanAddAnError()
        {
            var error = new ErrorModel()
            {
                Application = "Test",
                ErrorId = Guid.NewGuid(),
                ExceptionMessage = "TestMessage",
                ExceptionSource = "Test Source",
                ExceptionStackTrace = "Test Stacktrace",
                ExceptionType = "Test Type",
                Host = "Test Host",
                RequestMethod = "Test Method",
                ServerApplicationPath = "Test Path",
                ServerApplicationPathTranslated = "Test Path Translated",
                ServerName = "Test Server",
                ServerPort = 0,
                ServerPortSecure = "Test Port Secure",
                StatusCode = HttpStatusCode.OK,
                Time = DateTime.Now,
                Url = "Test Url",
                Username = "Test User",
                UserAgent = "Test User Agent"
            };

            var repository = new NHibernateRepository();
            repository.Add(error);

            using (var session = _sessionFactory.OpenSession())
            {
                var fromDb = session.Get<ErrorModel>(error.Id);
                
                Assert.That(fromDb, Is.Not.Null);
                Assert.AreNotSame(error, fromDb);

                Assert.That(fromDb.Application, Is.EqualTo(error.Application));
                Assert.That(fromDb.ErrorId, Is.EqualTo(error.ErrorId));
                Assert.That(fromDb.ExceptionMessage, Is.EqualTo(error.ExceptionMessage));
                Assert.That(fromDb.ExceptionSource, Is.EqualTo(error.ExceptionSource));
                Assert.That(fromDb.ExceptionStackTrace, Is.EqualTo(error.ExceptionStackTrace));
                Assert.That(fromDb.ExceptionType, Is.EqualTo(error.ExceptionType));
                Assert.That(fromDb.Host, Is.EqualTo(error.Host));
                Assert.That(fromDb.RequestMethod, Is.EqualTo(error.RequestMethod));
                Assert.That(fromDb.ServerApplicationPath, Is.EqualTo(error.ServerApplicationPath));
                Assert.That(fromDb.ServerApplicationPathTranslated, Is.EqualTo(error.ServerApplicationPathTranslated));
                Assert.That(fromDb.ServerName, Is.EqualTo(error.ServerName));
                Assert.That(fromDb.ServerPort, Is.EqualTo(error.ServerPort));
                Assert.That(fromDb.ServerPortSecure, Is.EqualTo(error.ServerPortSecure));
                Assert.That(fromDb.StatusCode, Is.EqualTo(error.StatusCode));
                Assert.That(fromDb.Time.ToString("yyyy-MM-dd HH:mm"), Is.EqualTo(error.Time.ToString("yyyy-MM-dd HH:mm")));
                Assert.That(fromDb.Url, Is.EqualTo(error.Url));
                Assert.That(fromDb.Username, Is.EqualTo(error.Username));
                Assert.That(fromDb.UserAgent, Is.EqualTo(error.UserAgent));

                session.Delete(fromDb);
            }
        }
    }

    [TestFixture]
    [Category("NHibernateRepository")]
    public class AddAndTruncateLongValuesTests
    {
        private ISessionFactory _sessionFactory;
        private Configuration _monitorConfiguration;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _monitorConfiguration = new Configuration();
            _monitorConfiguration.Configure();
            _monitorConfiguration.AddAssembly(typeof(ErrorModel).Assembly);
            _sessionFactory = _monitorConfiguration.BuildSessionFactory();
        }

        [Test]
        public void ThenWeCanAddAnErrorThatHasLongFields()
        {
            var error = new ErrorModel()
            {
                Application = new string('a', 201),
                ErrorId = Guid.NewGuid(),
                ExceptionMessage = new string('b', 1001),
                ExceptionSource = new string('c', 1001),
                ExceptionStackTrace = "Test Stacktrace",
                ExceptionType = new string('a', 301),
                Host = new string('b', 201),
                RequestMethod = new string('b', 101),
                ServerApplicationPath = new string('b', 1001),
                ServerApplicationPathTranslated = new string('b', 1001),
                ServerName = new string('b', 201),
                ServerPort = 0,
                ServerPortSecure = new string('b', 201),
                StatusCode = HttpStatusCode.OK,
                Time = DateTime.Now,
                Url = new string('b', 2084),
                Username = new string('b', 200),
                UserAgent = new string('b', 600)
            };

            var repository = new NHibernateRepository();
            repository.Add(error);

            using (var session = _sessionFactory.OpenSession())
            {
                var fromDb = session.Get<ErrorModel>(error.Id);

                Assert.That(fromDb, Is.Not.Null);
                Assert.AreNotSame(error, fromDb);

                Assert.That(fromDb.Application, Is.EqualTo(error.Application.Substring(0, 200)));
                Assert.That(fromDb.ErrorId, Is.EqualTo(error.ErrorId));
                Assert.That(fromDb.ExceptionMessage, Is.EqualTo(error.ExceptionMessage.Substring(0, 1000)));
                Assert.That(fromDb.ExceptionSource, Is.EqualTo(error.ExceptionSource.Substring(0, 1000)));
                Assert.That(fromDb.ExceptionStackTrace, Is.EqualTo(error.ExceptionStackTrace));
                Assert.That(fromDb.ExceptionType, Is.EqualTo(error.ExceptionType.Substring(0, 300)));
                Assert.That(fromDb.Host, Is.EqualTo(error.Host.Substring(0, 200)));
                Assert.That(fromDb.RequestMethod, Is.EqualTo(error.RequestMethod.Substring(0, 100)));
                Assert.That(fromDb.ServerApplicationPath, Is.EqualTo(error.ServerApplicationPath.Substring(0, 1000)));
                Assert.That(fromDb.ServerApplicationPathTranslated, Is.EqualTo(error.ServerApplicationPathTranslated.Substring(0, 1000)));
                Assert.That(fromDb.ServerName, Is.EqualTo(error.ServerName.Substring(0, 200)));
                Assert.That(fromDb.ServerPort, Is.EqualTo(error.ServerPort));
                Assert.That(fromDb.ServerPortSecure, Is.EqualTo(error.ServerPortSecure.Substring(0, 200)));
                Assert.That(fromDb.StatusCode, Is.EqualTo(error.StatusCode));
                Assert.That(fromDb.Time.ToString("yyyy-MM-dd HH:mm"), Is.EqualTo(error.Time.ToString("yyyy-MM-dd HH:mm")));
                Assert.That(fromDb.Url, Is.EqualTo(error.Url.Substring(0, 2083)));
                Assert.That(fromDb.Username, Is.EqualTo(error.Username.Substring(0, 200)));
                Assert.That(fromDb.UserAgent, Is.EqualTo(error.UserAgent.Substring(0, 600)));

                session.Delete(fromDb);
            }
        }
    }

    [TestFixture]
    [Category("NHibernateRepository")]
    public class HandleLongStackTraces
    {
        private ISessionFactory _sessionFactory;
        private Configuration _monitorConfiguration;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _monitorConfiguration = new Configuration();
            _monitorConfiguration.Configure();
            _monitorConfiguration.AddAssembly(typeof(ErrorModel).Assembly);
            _sessionFactory = _monitorConfiguration.BuildSessionFactory();
        }

        [Test]
        public void ThenWeCanStoreBigStackTraces()
        {
            var error = new ErrorModel()
            {
                Application = "Test",
                ErrorId = Guid.NewGuid(),
                ExceptionMessage = "TestMessage",
                ExceptionSource = "Test Source",
                ExceptionStackTrace = new string('f', 15000),
                ExceptionType = "Test Type",
                Host = "Test Host",
                RequestMethod = "Test Method",
                ServerApplicationPath = "Test Path",
                ServerApplicationPathTranslated = "Test Path Translated",
                ServerName = "Test Server",
                ServerPort = 0,
                ServerPortSecure = "Test Port Secure",
                StatusCode = HttpStatusCode.OK,
                Time = DateTime.Now,
                Url = "Test Url",
                Username = "Test User",
                UserAgent = "Test User Agent"
            };

            var repository = new NHibernateRepository();
            repository.Add(error);

            using (var session = _sessionFactory.OpenSession())
            {
                var fromDb = session.Get<ErrorModel>(error.Id);

                Assert.That(fromDb, Is.Not.Null);
                Assert.AreNotSame(error, fromDb);

                Assert.That(fromDb.Application, Is.EqualTo(error.Application));
                Assert.That(fromDb.ErrorId, Is.EqualTo(error.ErrorId));
                Assert.That(fromDb.ExceptionMessage, Is.EqualTo(error.ExceptionMessage));
                Assert.That(fromDb.ExceptionSource, Is.EqualTo(error.ExceptionSource));
                Assert.That(fromDb.ExceptionStackTrace, Is.EqualTo(error.ExceptionStackTrace));
                Assert.That(fromDb.ExceptionType, Is.EqualTo(error.ExceptionType));
                Assert.That(fromDb.Host, Is.EqualTo(error.Host));
                Assert.That(fromDb.RequestMethod, Is.EqualTo(error.RequestMethod));
                Assert.That(fromDb.ServerApplicationPath, Is.EqualTo(error.ServerApplicationPath));
                Assert.That(fromDb.ServerApplicationPathTranslated, Is.EqualTo(error.ServerApplicationPathTranslated));
                Assert.That(fromDb.ServerName, Is.EqualTo(error.ServerName));
                Assert.That(fromDb.ServerPort, Is.EqualTo(error.ServerPort));
                Assert.That(fromDb.ServerPortSecure, Is.EqualTo(error.ServerPortSecure));
                Assert.That(fromDb.StatusCode, Is.EqualTo(error.StatusCode));
                Assert.That(fromDb.Time.ToString("yyyy-MM-dd HH:mm"), Is.EqualTo(error.Time.ToString("yyyy-MM-dd HH:mm")));
                Assert.That(fromDb.Url, Is.EqualTo(error.Url));
                Assert.That(fromDb.Username, Is.EqualTo(error.Username));
                Assert.That(fromDb.UserAgent, Is.EqualTo(error.UserAgent));

                session.Delete(fromDb);
            }
        }
    }
}
