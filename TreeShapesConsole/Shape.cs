using System.Drawing;
namespace Tree
{
    public abstract class Shape
    {
        private ServiceProvider _serviceProvider;

        public Color Color {get;set;}

        public void Draw()
        {
            string message = "draw " + ToString();

            LoggerService loggerService = _serviceProvider.GetService("logger") as LoggerService;
            Logger logger = loggerService.GetLogger();

            logger.Message(message, LogLevel.Info);
        }

        public abstract ShapeType GetShapeType();
        public override string ToString() { return "";  }

        //setter injection
        public void SetServiceProvider(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }

    
}