using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            Node<int> test = new Node<int>(10);

            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Insert(1);


        }
    }
}
