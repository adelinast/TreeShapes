using NUnit.Framework;
using Tree;

namespace TreeTest
{
    class ShapeFactoryTest
    {
        ShapeFactory _shapeFactory;
        private ServiceProvider _serviceProvider;
        private ServiceCollection _serviceCollection;

        [SetUp]
        public void Init()
        {
            _serviceCollection = new ServiceCollection();
            _serviceProvider = new ServiceProvider(_serviceCollection);
            _shapeFactory = new ShapeFactory(_serviceProvider);
        }

        [TearDown]
        public void Dispose()
        {

        }

        #region Sample_TestCode

        [Test]
        public void GetShapeFromFactoryRectangle()
        {
            //ARRANGE
            var expectedShape = new Rectangle();

            //ACT
            Shape rectangle = _shapeFactory.GetShape(new ShapeData { ShapeType = ShapeType.RECTANGLE});

            //ASSERT
            Assert.IsNotNull(rectangle);
            Assert.IsInstanceOf<Rectangle>(rectangle);
            Assert.AreEqual(expectedShape.GetShapeType(), rectangle.GetShapeType());
        }


        [Test]
        public void GetShapeFromFactoryTriangle()
        {
            //ARRANGE
            var expectedShape = new Triangle();

            //ACT
            Shape triangle = _shapeFactory.GetShape(new ShapeData { ShapeType = ShapeType.TRIANGLE });


            //ASSERT
            Assert.IsNotNull(triangle);
            Assert.IsInstanceOf<Triangle>(triangle);
            Assert.AreEqual(expectedShape.GetShapeType(), triangle.GetShapeType());
        }

        #endregion
    }
}
