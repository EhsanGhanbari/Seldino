using System;
using log4net;
using log4net.Config;

namespace Seldino.Infrastructure.Logging
{
    public class Log4NetAdapter : ILogger
    {
        private readonly ILog _log;

        public Log4NetAdapter()
        {
            _log = LogManager.GetLogger(GetType());
            XmlConfigurator.Configure();
        }

        public void Log(string message)
        {
            _log.Info(message);
        }

        public void Log(Exception exception)
        {
            _log.Info(exception);
        }

        public void Info(string message)
        {
            _log.Info(message);
        }

        public void Info(Exception exception)
        {
           _log.Info(exception);
        }

        public void Error(string message)
        {
            _log.Error(message);
        }

        public void Error(Exception exception)
        {
           _log.Error(exception);
        }

        public void Error(string message, Exception exception)
        {
            _log.Error(message, exception);
        }
    }
}
