using System;
using System.Collections.Generic;
using System.Linq;

namespace Tree
{

    public enum LogLevel
    {
        Info,
        Warning,
        Error,
        Debug,
        Trace,
    }

    public class LoggerFactory : ILoggerFactory
    {
        public Logger CreateLogger()
        {
            return new FileLogger(LogLevel.Info);
        }
    }

    public interface ILoggerFactory
    {
        Logger CreateLogger();
    }

    public abstract class Logger
    {
        protected LogLevel _logLevel;

        public Logger(LogLevel level)
        {
            _logLevel = level;
        }

        public void Message(string msg, LogLevel severity)
        {
            WriteMessage(msg);
        }

        abstract protected void WriteMessage(string msg);
    }

    public class Logging
    {
        private static ILoggerFactory _factory = null;

        public static void ConfigureLogger(ILoggerFactory factory)
        {
        }

        public static ILoggerFactory LoggerFactory
        {
            get
            {
                if (_factory == null)
                {
                    _factory = new LoggerFactory();
                    ConfigureLogger(_factory);
                }
                return _factory;
            }
            set { _factory = value; }
        }
        public static Logger CreateLogger() => LoggerFactory.CreateLogger();
    }


}
