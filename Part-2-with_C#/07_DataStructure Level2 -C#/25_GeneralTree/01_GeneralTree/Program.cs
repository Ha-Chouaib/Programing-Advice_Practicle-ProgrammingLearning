using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25_GeneralTree
{
    public class TreeNode<T>
    {
        public T Value { get; set; }

        public List<TreeNode<T>> Children { get; set; }

        public TreeNode(T value)
        {
            this.Value = value;
            Children = new List<TreeNode<T>>();
        }

        public void AddChild(TreeNode<T> Child)
        {
            Children.Add(Child);
        }
    }

    public class Tree<T>
    {
        public TreeNode<T> Root { get; private set; }
        public Tree(T rootValue)
        {
            Root = new TreeNode<T>(rootValue);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creating Tree Elements

            Tree<string> CompanyTree = new Tree<string>("CEO"); // Root
                                                                //Creating Nodes
            TreeNode<string> Finance = new TreeNode<string>("CFO");
            TreeNode<string> Tech = new TreeNode<string>("CTO");
            TreeNode<string> Marketing = new TreeNode<string>("CMO");

            //Adding Departments to The root Node <CEO>
            CompanyTree.Root.AddChild(Finance);
            CompanyTree.Root.AddChild(Tech);
            CompanyTree.Root.AddChild(Marketing);

            //Adding Employees to departments
            Finance.AddChild(new TreeNode<string>("Accountant"));
            Tech.AddChild(new TreeNode<string>("Developer"));
            Tech.AddChild(new TreeNode<string>("Ux Designer"));
            Marketing.AddChild(new TreeNode<string>("Social Media Manager"));

            //print the Tree

            PrintTree(CompanyTree.Root);



        }
        public static void PrintTree(TreeNode<string> node, string ident= " ")
        {
            Console.WriteLine(ident + node.Value);
            foreach (var N in node.Children)
            { 
                PrintTree(N, ident + "  ");
            }
        }
    }
}
