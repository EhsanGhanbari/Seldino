using System;

namespace Seldino.Infrastructure.Logging
{
    public interface ILogger
    {
        void Log(string message);

        void Log(Exception exception);

        void Info(string message);

        void Info(Exception exception);

        void Error(string message);

        void Error(Exception exception);

        void Error(string message, Exception exception);
    }
}

