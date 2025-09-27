using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _02_PreOrderTraversal
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
            if(Root == null)
            {
                Root= newNode;
                return;
            }

            Queue<BinaryTreeNode<T>> queue =new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(Root);

            while(queue.Count > 0)
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

        private void PreOrderTraversal(BinaryTreeNode<T> node)
        {
            /*
              PreOrder Traversal visits the current node before its child nodes. 
              The process for PreOrder Traversal is as follows:


                 - Visit the current node.
                 - Recursively perform PreOrder Traversal of the left subtree.
                 - Recursively perform PreOrder Traversal of the right subtree.
            */


            if (node != null)
            {
                Console.Write(node.Value + " ");
                PreOrderTraversal(node.Left);
                PreOrderTraversal(node.Right);
            }
        }


        public void PreOrderTraversal()
        {
            PreOrderTraversal(Root);
            Console.WriteLine();
        }

   


}

internal class Program
    {
        static void Main(string[] args)
        {
            // Root --> Left --> Right
            var binaryTree = new BinaryTree<int>();
            Console.WriteLine("Values to be inserted: 5,3,8,1,4,6,9\n");

            binaryTree.Insert(5);
            binaryTree.Insert(3);
            binaryTree.Insert(8);
            binaryTree.Insert(1);
            binaryTree.Insert(4);
            binaryTree.Insert(6);
            binaryTree.Insert(9);
            binaryTree.Insert(10);
            binaryTree.Insert(11);
            binaryTree.Insert(12);

            binaryTree.PrintTree();

            Console.WriteLine("\nPreOrder Traversal (Current-Left SubTree - Right SubTree):");
            binaryTree.PreOrderTraversal();

            Console.ReadKey();

        }
    }
}
