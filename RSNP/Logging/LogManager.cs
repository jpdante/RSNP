using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RSNP.Logging {
    public static class LogManager {

        public static bool IsFatalEnabled = true;
        public static bool IsWarnEnabled = true;
        public static bool IsInfoEnabled = true;
        public static bool IsDebugEnabled = false;
        public static bool IsErrorEnabled = true;

        internal static List<ILogger> Loggers = new List<ILogger>();
        private static Dictionary<Type, ILog> Logs = new Dictionary<Type, ILog>();

        public static void RegisterLogger(ILogger logger) {
            if (Loggers.Contains(logger)) throw new DuplicateWaitObjectException();
            else Loggers.Add(logger);
        }

        public static void UnregisterLogger(ILogger logger) {
            if (!Loggers.Contains(logger)) throw new KeyNotFoundException();
            else Loggers.Remove(logger);
        }

        public static ILog NewLog(Type type) {
            var log = new ILog(type);
            Logs.Add(type, log);
            return log;
        }

        public static void DeleteLog(Type type) {
            if (!Logs.ContainsKey(type)) throw new KeyNotFoundException();
            else Logs.Remove(type);
        }
    }
}
