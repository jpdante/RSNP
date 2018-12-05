using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RSNP.Logging {
    public class ILog {

        public readonly Type Type;

        public ILog(Type type) {
            Type = type;
        }

        public void Debug(object message) {
            if(LogManager.IsDebugEnabled) {
                foreach(ILogger logger in LogManager.Loggers) {
                    logger.Debug(Type, message);
                }
            }
        }
        public void Debug(object message, Exception exception) {
            if (LogManager.IsDebugEnabled) {
                foreach (ILogger logger in LogManager.Loggers) {
                    logger.Debug(Type, message, exception);
                }
            }
        }
        public void Debug(Exception exception) {
            if (LogManager.IsDebugEnabled) {
                foreach (ILogger logger in LogManager.Loggers) {
                    logger.Debug(Type, exception);
                }
            }
        }

        public void Info(object message) {
            if (LogManager.IsInfoEnabled) {
                foreach (ILogger logger in LogManager.Loggers) {
                    logger.Info(Type, message);
                }
            }
        }
        public void Info(object message, Exception exception) {
            if (LogManager.IsInfoEnabled) {
                foreach (ILogger logger in LogManager.Loggers) {
                    logger.Info(Type, message, exception);
                }
            }
        }
        public void Info(Exception exception) {
            if (LogManager.IsInfoEnabled) {
                foreach (ILogger logger in LogManager.Loggers) {
                    logger.Info(Type, exception);
                }
            }
        }

        public void Warn(object message) {
            if (LogManager.IsWarnEnabled) {
                foreach (ILogger logger in LogManager.Loggers) {
                    logger.Warn(Type, message);
                }
            }
        }
        public void Warn(object message, Exception exception) {
            if (LogManager.IsWarnEnabled) {
                foreach (ILogger logger in LogManager.Loggers) {
                    logger.Warn(Type, message, exception);
                }
            }
        }
        public void Warn(Exception exception) {
            if (LogManager.IsWarnEnabled) {
                foreach (ILogger logger in LogManager.Loggers) {
                    logger.Warn(Type, exception);
                }
            }
        }

        public void Error(object message) {
            if (LogManager.IsErrorEnabled) {
                foreach (ILogger logger in LogManager.Loggers) {
                    logger.Error(Type, message);
                }
            }
        }
        public void Error(object message, Exception exception) {
            if (LogManager.IsErrorEnabled) {
                foreach (ILogger logger in LogManager.Loggers) {
                    logger.Error(Type, message, exception);
                }
            }
        }
        public void Error(Exception exception) {
            if (LogManager.IsErrorEnabled) {
                foreach (ILogger logger in LogManager.Loggers) {
                    logger.Error(Type, exception);
                }
            }
        }

        public void Fatal(object message) {
            if (LogManager.IsFatalEnabled) {
                foreach (ILogger logger in LogManager.Loggers) {
                    logger.Fatal(Type, message);
                }
            }
        }
        public void Fatal(object message, Exception exception) {
            if (LogManager.IsFatalEnabled) {
                foreach (ILogger logger in LogManager.Loggers) {
                    logger.Fatal(Type, message, exception);
                }
            }
        }
        public void Fatal(Exception exception) {
            if (LogManager.IsFatalEnabled) {
                foreach (ILogger logger in LogManager.Loggers) {
                    logger.Fatal(Type, exception);
                }
            }
        }

        public void SelfDelete() {
            LogManager.DeleteLog(Type);
        }
    }
}
