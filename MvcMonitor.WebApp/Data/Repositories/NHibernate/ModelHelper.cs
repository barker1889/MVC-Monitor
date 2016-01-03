using System;
using MvcMonitor.Models;

namespace MvcMonitor.Data.Repositories.NHibernate
{
    public class ModelHelper
    {
        public static void Truncate(ErrorModel model)
        {
            model.Application = Truncate(model.Application, 200);
            model.Username = Truncate(model.Username, 200);
            model.Host = Truncate(model.Host, 200);
            model.Url = Truncate(model.Url, 2083);
            model.RequestMethod = Truncate(model.RequestMethod, 100);
            model.UserAgent = Truncate(model.UserAgent, 600);
            model.ExceptionType = Truncate(model.ExceptionType, 300);
            model.ExceptionMessage = Truncate(model.ExceptionMessage, 1000);
            model.ExceptionSource = Truncate(model.ExceptionSource, 1000);
            model.ServerName = Truncate(model.ServerName, 200);
            model.ServerPortSecure = Truncate(model.ServerPortSecure, 200);
            model.ServerApplicationPath = Truncate(model.ServerApplicationPath, 1000);
            model.ServerApplicationPathTranslated = Truncate(model.ServerApplicationPathTranslated, 1000);
            model.QueryString = Truncate(model.QueryString, 2083);
        }

        private static string Truncate(string input, int maxLength)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, Math.Min(input.Length, maxLength));
        }
    }
}