using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tree
{
    public class BinaryTree<T>
    {
        public enum Link
        {
            NONE,
            LEFT,
            RIGHT
        }

        private Node<T> _root;

        public BinaryTree()
        {
            _root = null;
        }

        public BinaryTree(T data)
        {
            _root = new Node<T>(data);
        }

        public Node<T> CreateRoot(T data)
        {
            _root = new Node<T>(data);
            return _root;
        }
        
        public Node<T> AddNodeLeft(ref Node<T> Root, T data)
        {
            Node<T> leftNode = new Node<T>(data);
            AddNode(ref Root, leftNode, Link.LEFT);
            return leftNode;
        }

        public Node<T> AddNodeRight(ref Node<T> Root, T data)
        {
            Node<T> rightNode = new Node<T>(data);
            AddNode(ref Root, rightNode, Link.RIGHT);
            return rightNode;
        }

        private void AddNode(ref Node<T> Root, in Node<T> Node, in Link Link )
        {
            if (Root == null)
            {
                Root = Node;
            }
             
            switch(Link)
            {
                case Link.LEFT:
                    Root.Left = Node;
                    break;
                case Link.RIGHT:
                    Root.Right = Node;
                    break;
                default:
                    break;
            }
        }

        public void PrintLevelOrder()
        {
            int height = Height(_root);
            for (int i = 0; i < height; i++)
            {
                PrintLevel(_root, i);
                Console.WriteLine();
            }
        }

        private void PrintLevel(Node<T> Node, int level)
        {
            if (Node == null)
            {
                return;
            }

            if (level == 0)
            {
                Shape shape = (Node.Data as Shape);
                Console.Write(shape.ToString()+" ");
            }
            else if (level > 0)
            {
                PrintLevel(Node.Left, level - 1);
                PrintLevel(Node.Right, level - 1);
            }
        }

        public void Draw(Node<T> node)
        {
            //preorder
            if (node == null)
            {
                return;
            }

            Shape shape = node.Data as Shape;
            shape.Draw();

            Draw(node.Left);
            Draw(node.Right);
        }

        public void Draw() { Draw(_root); }

        public Node<T> GetRoot()
        {
            return _root;
        }

        public void FindParentLink(Node<T> Node, T val, Node<T> Parent, ref Link ParentLink)
        {
            if (Node == null)
            {
                return;
            }
            if (Node.Data.Equals(val))
            {
                if (Parent.Left!=null && Parent.Left.Data.Equals(val))
                {
                    ParentLink = Link.LEFT;
                }
                else if (Parent.Right != null && Parent.Right.Data.Equals(val))
                {
                    ParentLink = Link.RIGHT;
                }
            }
            else
            {
                FindParentLink(Node.Left, val, Node, ref ParentLink);
                FindParentLink(Node.Right, val, Node, ref ParentLink);
            }
        }

        public int Height(Node<T> Node)
        {
            if (Node == null)
            {
                return 0;
            }
            return 1 + Math.Max(Height(Node.Left), Height(Node.Right));
        }
    }
}