using System.Drawing;

namespace Tree
{
    public class ShapeData
    {
        public ShapeType ShapeType { get; set; }
        public Color ShapeColor { get; set; }
    }
    public class ShapeFactory : IShapeFactory
    {
        private ServiceProvider _serviceProvider;

        public ShapeFactory(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Shape GetShape(ShapeData shapeFactoryArg)
        {
            Shape shape = null;
            ShapeType shapeType = shapeFactoryArg.ShapeType;
            switch (shapeType)
            {
                case ShapeType.CIRCLE:
                    shape = new Circle { Color = shapeFactoryArg.ShapeColor };
                    break;
                case ShapeType.RECTANGLE:
                    shape= new Rectangle() { Color = shapeFactoryArg.ShapeColor };
                    break;
                case ShapeType.TRIANGLE:
                    shape = new Triangle() { Color = shapeFactoryArg.ShapeColor };
                    break;
                default:
                    break;
            }

            shape.SetServiceProvider(_serviceProvider);

            return shape;
        }
    }
}