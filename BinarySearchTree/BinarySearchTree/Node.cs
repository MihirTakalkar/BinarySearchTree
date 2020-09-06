using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    class Node<T>
    {
        //parent
        public Node<T> Parent;
        //leftchild
        public Node<T> LeftChild;
        //right child
        public Node<T> RightChild;
        //value
        public T value;
        //IsRightChild
        public bool IsRightChild
        {
            get
            {
                if (Parent != null && Parent.RightChild == this)
                {
                    return true;
                }

                else 
                {
                    return false;
                }
            }
        }

        //IsLeftChild
        public bool IsLeftChild
        {
            get
            {
                if(Parent != null && Parent.LeftChild == this)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }
        }

        public Node(T value)
        {
            this.value = value;
        }
    }
}
