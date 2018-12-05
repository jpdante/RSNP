using System;
using System.Collections.Generic;
using System.Text;

namespace RSNP.Logging {
    public interface ILogger {
        void Debug(Type type, object message);
        void Debug(Type type, object message, Exception exception);
        void Debug(Type type, Exception exception);

        void Info(Type type, object message);
        void Info(Type type, object message, Exception exception);
        void Info(Type type, Exception exception);

        void Warn(Type type, object message);
        void Warn(Type type, object message, Exception exception);
        void Warn(Type type, Exception exception);

        void Error(Type type, object message);
        void Error(Type type, object message, Exception exception);
        void Error(Type type, Exception exception);

        void Fatal(Type type, object message);
        void Fatal(Type type, object message, Exception exception);
        void Fatal(Type type, Exception exception);
    }
}
