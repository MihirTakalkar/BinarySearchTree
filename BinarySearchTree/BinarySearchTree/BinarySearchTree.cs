using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    class BinarySearchTree<T>
    {
        Node<T> root;


        public void Insert(T value)
        {
            if(root == null)
            {
                root = new Node<T>(value);
                return;
            }


        }

        //public Node<T> Delete(T value)
        //{

        //}

        //Node<T> Search()
        //{

        //}

        //Node<T> Minimum(Node<T> node)
        //{

        //}

        //Node<T> Maximum(Node<T> node)
        //{

        //}
    }
}
