using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_BinaryTree
{
    public class BinaryTreeNode<T>
    {
        public T Value { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode(T value)
        {
            this.Value = value;
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
            /*
          We use Level-order insertion strategy,
          Level-order insertion: in a binary tree is a strategy that fills the tree level by level, 
          from left to right. This approach ensures that every level of the tree is completely 
          filled before any nodes are added to a new level, 
          and each parent node has at most two children before moving on to the next node in the 
          sequence.

          */

            var newNode = new  BinaryTreeNode<T>(value);
            if (Root == null)
            {
                Root = newNode;
                return;
            }

            //Using Queue to Perform Level-Ordre insertion
            Queue<BinaryTreeNode<T>> queue= new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var Current= queue.Dequeue();

                if(Current.Left == null)
                {
                    Current.Left = newNode;
                    break;
                }else
                {
                    queue.Enqueue(Current.Left);
                }

                if (Current.Right == null)
                { 
                    Current.Right = newNode;
                    break;
                }else
                {  queue.Enqueue(Current.Right); }


            }

        }

        public void PrintTree()
        {
            PrintTree(Root, 0);
        }
        private void PrintTree(BinaryTreeNode<T> root, int space)
        {
            int COUNT = 10;  // Distance between levels to adjust the visual representation
            if (root == null)
                return;


            space += COUNT;
            PrintTree(root.Right, space); // Print right subtree first, then root, and left subtree last


            Console.WriteLine();
            for (int i = COUNT; i < space; i++)
                Console.Write(" ");
            Console.WriteLine(root.Value); // Print the current node after space


            PrintTree(root.Left, space); // Recur on the left child
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            var binaryTree = new BinaryTree<int>();
            Console.WriteLine("All inserted Values:\n");

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

        }
    }
}
