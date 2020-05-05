using NUnit.Framework;
using System.Drawing;
using Tree;
using static Tree.BinaryTree<Tree.Shape>;

namespace TreeTest
{
    class BinaryTreeTest
    {
        private BinaryTree<Shape> _tree;

        [SetUp]
        public void Init()
        {
            Shape rectangleRed = new Triangle {Color = Color.Red};
            _tree = new BinaryTree<Shape>(rectangleRed);
        }

        [TearDown]
        public void Dispose()
        {
        }

        #region Sample_TestCode

        [Test]
        public void CreateRootTrue()
        {
            //ACT
            var root = _tree.GetRoot();

            //ASSERT
            Assert.IsNotNull(root);
        }

        [Test]
        public void AddChildrenLeft()
        {
            //ARRANGE
            Shape triangleRed = new Triangle { Color = Color.Red};
            Node<Shape> treeRoot = _tree.GetRoot();

            //ACT
            Node<Shape> rootLeftNode = _tree.AddNodeLeft(ref treeRoot, triangleRed);

            //ASSERT
            Assert.IsNotNull(rootLeftNode);
            Shape rootLeftShape = rootLeftNode.Data as Shape;
            Assert.AreEqual(rootLeftShape.Color, Color.Red);
            Assert.AreEqual(rootLeftShape.GetShapeType(), ShapeType.TRIANGLE);
        }

        [Test]
        public void AddChildrenRight()
        {
            //ARRANGE
            Shape triangleGreen =  new Triangle();

            triangleGreen.Color = Color.Green;
            Node<Shape> treeroot = _tree.GetRoot();

            //ACT
            Node<Shape> rootRightNode = _tree.AddNodeRight(ref treeroot, triangleGreen);

            //ASSERT
            Assert.IsNotNull(rootRightNode);
            Shape rootRightShape = rootRightNode.Data as Shape;
            Assert.AreEqual(rootRightShape.Color, Color.Green);
            Assert.AreEqual(rootRightShape.GetShapeType(), ShapeType.TRIANGLE);
        }

        [Test]
        public void Height()
        {
            //ARRANGE
            TreeShapes treeShapes = new TreeShapes();
            BinaryTree<Shape> tree = treeShapes.CreateObjects();

            //ACT
            int height = tree.Height(tree.GetRoot());

            //ASSERT
            Assert.AreEqual(3, height);
        }

        [Test]
        public void ParentLinkRight()
        {
            //ARRANGE
            Link parentLink = Link.NONE;
            Shape triangleGreen = new Triangle();

            triangleGreen.Color = Color.Green;
            Node<Shape> treeRoot = _tree.GetRoot();
            Node<Shape> rootRightNode = _tree.AddNodeRight(ref treeRoot, triangleGreen);
            
            //ACT
            _tree.FindParentLink(treeRoot, triangleGreen, treeRoot, ref parentLink);
            
            //ASSERT
            Assert.AreEqual(parentLink, Link.RIGHT);
        }

        [Test]
        public void ParentLinkLeft()
        {
            //ARRANGE
            Link parentLink = Link.NONE;
            Shape triangleGreen = new Triangle();

            triangleGreen.Color = Color.Green;
            Node<Shape> treeRoot = _tree.GetRoot();
            Node<Shape> rootRightNode = _tree.AddNodeLeft(ref treeRoot, triangleGreen);

            //ACT
            _tree.FindParentLink(treeRoot, triangleGreen, treeRoot, ref parentLink);

            //ASSERT
            Assert.AreEqual(parentLink, Link.LEFT);
        }
        #endregion
    }
}
