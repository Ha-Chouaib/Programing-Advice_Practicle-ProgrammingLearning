using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_FindOperation
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
        public TreeNode<T> Find(T value)
        {
            if (EqualityComparer<T>.Default.Equals(this.Value, value)) return this;

            foreach (var Child in Children)
            {
                var found = Child.Find(value);
                if (found != null) return found;
            }
            return null;
        }

    }

    public class Tree<T>
    {
        public T Value { get; set; }

        public TreeNode<T> root { get; private set; }

        public Tree(T rootValue)
        {
            root = new TreeNode<T>(rootValue);
        }

        public void PrintTree(string ident = " ")
        {
            PrintTree(this.root, ident);
        }
        private static void PrintTree(TreeNode<T> node, string ident = " ")
        {
            Console.WriteLine(ident + node.Value);
            foreach (var N in node.Children)
            {
                PrintTree(N, ident + "  ");
            }
        }

        public TreeNode<T> Find(T value)
        {
            return root?.Find(value);
        }
    } 



    internal class Program
    {
        static void Main(string[] args)
        {
            Tree<string> CompanyTree = new Tree<string>("CEO"); // Root
                                                                //Creating Nodes
            TreeNode<string> Finance = new TreeNode<string>("CFO");
            TreeNode<string> Tech = new TreeNode<string>("CTO");
            TreeNode<string> Marketing = new TreeNode<string>("CMO");

       
            CompanyTree.root.AddChild(Finance);
            CompanyTree.root.AddChild(Tech);
            CompanyTree.root.AddChild(Marketing);


            Finance.AddChild(new TreeNode<string>("Accountant"));
            Tech.AddChild(new TreeNode<string>("Developer"));
            Tech.AddChild(new TreeNode<string>("Ux Designer"));
            Marketing.AddChild(new TreeNode<string>("Social Media Manager"));

            CompanyTree.PrintTree();

            Console.WriteLine("\nFind <Developer>");

            if (CompanyTree.root.Find("Developer") != null)
                Console.WriteLine("--> Found :)");
            else
                Console.WriteLine("--> Not Found :(");


            Console.WriteLine("\nFinding <DBA>");

            if (CompanyTree.root.Find("DBA") != null)
                Console.WriteLine("--> Found :)");
            else
                Console.WriteLine("--> Not Found :(");


        }
    }
}
