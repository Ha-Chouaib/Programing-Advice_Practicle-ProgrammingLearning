using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_PostOrderTraversal
{
    public class BinaryTreeNode<T>
    {
        public T Value { get; set; }

        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }
    public class BinaryTree<T>
    {
        public BinaryTreeNode<T> Root { get; private set; }
        public BinaryTree()
        {
            Root = null;
        }

        public void Insert(T value)
        {
            var newNode = new BinaryTreeNode<T>(value);
            if (Root == null)
            {
                Root = newNode;
                return;
            }

            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var CurrentNode = queue.Dequeue();
                if (CurrentNode.Left == null)
                {
                    CurrentNode.Left = newNode;
                    break;
                }
                else { queue.Enqueue(CurrentNode.Left); }

                if (CurrentNode.Right == null)
                {
                    CurrentNode.Right = newNode;
                    break;
                }
                else { queue.Enqueue(CurrentNode.Right); }


            }
        }
        public void PrintTree()
        {
            PrintTree(Root, 0);
        }
        private void PrintTree(BinaryTreeNode<T> root, int space)
        {
            int COUNT = 10;
            if (root == null)
                return;

            space += COUNT;
            PrintTree(root.Right, space);


            Console.WriteLine();
            for (int i = COUNT; i < space; i++)
                Console.Write(" ");


            Console.WriteLine(root.Value);


            PrintTree(root.Left, space);
        }

        public void PostOrderTraversal()
        {
            PostOrderTraversal(Root);
            Console.WriteLine();
        }

        private void PostOrderTraversal(BinaryTreeNode<T> node)
        {
            if(node != null)
            {
                PostOrderTraversal(node.Left);
                PostOrderTraversal(node.Right);
                Console.Write(node.Value + "  ");
            }
        }
    }

    
        internal class Program
    {
        static void Main(string[] args)
        {
            //Left SubTree -> Right SubTree -> Root

            /*
             What is Postorder Traversal?
                In postorder traversal, a binary tree is traversed in the following order:
                
                1. Traverse the left subtree in postorder.
                2. Traverse the right subtree in postorder.
                3. Visit the root node.

            -- Postorder traversal is especially useful in scenarios where you need to visit child nodes before their parents,
            such as when calculating the size or depth of a tree,
            or when performing certain cleanup or evaluation tasks that require child nodes to be processed first.
             */
            var binaryTree = new BinaryTree<int>();
            Console.WriteLine("Values to be inserted: 5,3,8,1,4,6,9\n");

            binaryTree.Insert(5);
            binaryTree.Insert(3);
            binaryTree.Insert(8);
            binaryTree.Insert(1);
            binaryTree.Insert(4);
            binaryTree.Insert(6);
            binaryTree.Insert(9);

            binaryTree.PrintTree();

            Console.WriteLine("\nPostorder Traversal (Left SubTree - Right SubTree - Current):");
            binaryTree.PostOrderTraversal();

            Console.ReadKey();


        }
    }
}
