using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    class Node<T>
    {
        public Node<T> Parent;
     
        public Node<T> LeftChild;
        
        public Node<T> RightChild;
        
        public T value;

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
