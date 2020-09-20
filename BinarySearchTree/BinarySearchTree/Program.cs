using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {

            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Insert(5);
            bst.Insert(2);
            bst.Insert(3);
            bst.Insert(7);
            bst.Insert(6);
            bst.Delete(7);

            bst.PrintTree();


        }
    }
}
