using System;
using System.Drawing;

namespace Tree
{
    public class TreeShapes
    {
        public BinaryTree<Shape> CreateObjects()
        {
            IShapeFactory shapeFactory = new ShapeFactory(_serviceProvider);

            Shape rectangleRed = shapeFactory.GetShape(new ShapeData { ShapeType = ShapeType.RECTANGLE, ShapeColor = Color.Red });

            Shape rectangleBlue = shapeFactory.GetShape(new ShapeData { ShapeType = ShapeType.RECTANGLE, ShapeColor = Color.Blue });

            Shape circleBlue = shapeFactory.GetShape(new ShapeData { ShapeType = ShapeType.CIRCLE, ShapeColor = Color.Blue });

            Shape circleGreen = shapeFactory.GetShape(new ShapeData { ShapeType = ShapeType.CIRCLE, ShapeColor = Color.Green });

            Shape triangleYellow = shapeFactory.GetShape(new ShapeData { ShapeType = ShapeType.TRIANGLE, ShapeColor = Color.Yellow });

            Shape triangleRed = shapeFactory.GetShape(new ShapeData { ShapeType = ShapeType.TRIANGLE, ShapeColor = Color.Red });

            Shape triangleGreen = shapeFactory.GetShape(new ShapeData { ShapeType = ShapeType.TRIANGLE, ShapeColor = Color.Green });

            BinaryTree<Shape> tree = new BinaryTree<Shape>(rectangleRed);
            Node<Shape> treeRoot = tree.GetRoot();

            Node<Shape> rootLeftNode = tree.AddNodeLeft(ref treeRoot, circleBlue);
            Node<Shape> rootRightNode = tree.AddNodeRight(ref treeRoot, triangleYellow);

            tree.AddNodeLeft(ref rootLeftNode, circleGreen);
            tree.AddNodeRight(ref rootLeftNode, triangleRed);

            tree.AddNodeLeft(ref rootRightNode, rectangleBlue);
            tree.AddNodeRight(ref rootRightNode, triangleGreen);

            return tree;
        }

        public void SetServiceProvider(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        private ServiceProvider _serviceProvider;
    }

    public class Application
    {
        private ServiceProvider _serviceProvider;


        public Application(ServiceProvider ServiceProvider)
        {
            _serviceProvider = ServiceProvider;
        }

        public void Run()
        {
            TreeShapes treeshapes = new TreeShapes();
            treeshapes.SetServiceProvider(_serviceProvider);

            BinaryTree<Shape> tree = treeshapes.CreateObjects();

            tree.PrintLevelOrder();
            tree.Draw();
        }
    }

    class Program
    {
        /*               redsquare
                       /           \
                      /             \
           bluecircle               yellow triangle
           /        \                      /        \
           /         \                    /          \
        greencircle   red triangle       bluesquare   green triangle
         */

        
        static void Main(string[] args)
        {

            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddService(new LoggerService());
            ServiceProvider serviceProvider = new ServiceProvider(serviceCollection);

            Application application = new Application(serviceProvider);
            application.Run();

        }
    }

}
