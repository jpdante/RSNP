using System;
using System.Collections.Generic;
using System.Text;

namespace RSNP.Testing {
    public enum LogLevel {
        None, Debug, Error, Warn, Info, Fatal
    }

    public static class ConsoleLogger {

        public static void Log(LogLevel level, object message, Exception exception) {
            string log = $"[{DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss.fff")}] ";
            switch(level) {
                case LogLevel.None:
                    break;
                case LogLevel.Debug:
                    log += "[Debug] ";
                    break;
                case LogLevel.Info:
                    log += "[Info] ";
                    break;
                case LogLevel.Warn:
                    log += "[Warn] ";
                    break;
                case LogLevel.Error:
                    log += "[Error] ";
                    break;
                case LogLevel.Fatal:
                    log += "[Fatal] ";
                    break;
            }
            if (message != null) {
                log += $"{message}";
            }
            if (exception != null) {
                log += $"\n{exception.Message}\n{exception.StackTrace.ToString()}";
            }
            WriteLine(level, log);
        }

        public static void Log(LogLevel level, Exception exception) {
            Log(level, null, exception);
        }

        public static void Log(LogLevel level, object message) {
            Log(level, message, null);
        }

        public static void Log(object message, Exception exception) {
            Log(LogLevel.None, message, exception);
        }

        public static void Log(object message) {
            Log(LogLevel.None, message, null);
        }

        public static void Log(Exception exception) {
            Log(LogLevel.None, null, exception);
        }

        private static void WriteLine(LogLevel level, string log) {
            switch (level) {
                case LogLevel.None:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(log);
                    break;
                case LogLevel.Debug:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(log);
                    break;
                case LogLevel.Info:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(log);
                    break;
                case LogLevel.Warn:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(log);
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(log);
                    break;
                case LogLevel.Fatal:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(log);
                    break;
            }
        }

    }
}
