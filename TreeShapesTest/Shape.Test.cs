using NUnit.Framework;
using System.Drawing;
using Tree;

namespace TreeTest
{
    class ShapeTest
    {
        [SetUp]
        public void Init()
        {
        }

        [TearDown]
        public void Dispose()
        {
        }

        #region Sample_TestCode

        [Test]
        public void ShapeSetType()
        {
            //ACT
            Shape rectangle = new Tree.Rectangle();
            
            //ASSERT
            Assert.AreEqual(rectangle.GetShapeType(), ShapeType.RECTANGLE);
        }

        [Test]
        public void ShapeSetGetColor()
        {
            //ACT
            Shape rectangleRed = new Tree.Rectangle();
            rectangleRed.Color = Color.Red;
            
            //ASSERT
            Assert.AreEqual(rectangleRed.Color, Color.Red);
        }


        #endregion
    }
}
