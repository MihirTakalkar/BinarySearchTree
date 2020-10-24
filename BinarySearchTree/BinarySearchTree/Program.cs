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
            bst.Insert(1);
            bst.Insert(6);
            bst.Insert(10);
            bst.Insert(4);
            bst.Delete(3);

            var result = bst.InOrder();
            ;

        }
    }
}
