namespace Tree
{
    public class LoggerService : Service
    {
        Logger _logger;

         public LoggerService()
        {
            _logger = Logging.CreateLogger();
            Servicetype = ServiceType.LoggerType;
        }

        public Logger GetLogger()
        {
            return _logger;
        }
    }

}
