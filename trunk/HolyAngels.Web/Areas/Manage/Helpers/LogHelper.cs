using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace HolyAngels.Web.Areas.Manage.Helpers
{
    public static class LogHelper
    {
        private static log4net.ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public static void LogWarning(string message)
        {
            _log.Warn(message);            
        }

        public static void LogWarning(string format, params object[] args)
        {
            LogWarning(string.Format(format, args));
        }

        public static void LogWarning(string message, Exception exception)
        {
            _log.Warn(message, exception);
        }

        public static void LogDebugging(string message)
        {
            _log.Debug(message);
        }

        public static void LogDebugging(string format, params object[] args)
        {
            LogDebugging(string.Format(format, args));
        }

        public static void LogDebugging(string message, Exception exception)
        {
            _log.Debug(message, exception);
        }

        public static void LogFatalError(string message)
        {
            _log.Fatal(message);
        }

        public static void LogFatalError(string format, params object[] args)
        {
            LogFatalError(string.Format(format, args));
        }

        public static void LogFatalError(string message, Exception exception)
        {
            _log.Fatal(message, exception);
        }
        public static void LogInformation(string message)
        {
            _log.Info(message);
        }

        public static void LogInformation(string format, params object[] args)
        {
            LogInformation(string.Format(format, args));
        }

        public static void LogInformation(string message, Exception exception)
        {
            _log.Info(message, exception);
        }
    }
}
