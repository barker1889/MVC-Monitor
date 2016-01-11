using System.Reflection;
using log4net;

namespace MvcMonitor
{
    public static class Logger
    {
        public static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    }
}