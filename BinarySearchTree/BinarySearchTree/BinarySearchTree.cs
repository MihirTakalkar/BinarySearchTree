using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BinarySearchTree
{
    class BinarySearchTree<T> where T : IComparable<T>
    {
        Node<T> root;


        public void Insert(T value)
        {
            if (root == null)
            {
                root = new Node<T>(value);
                return;
            }

            // compareTo
            // a == b ==> 0
            // a < b ==> -1 
            // a > b ==> 1

            Node<T> node = new Node<T>(value);
            Node<T> currentNode = root;

            while (currentNode != null)
            {
                int compare = value.CompareTo(currentNode.value);

                if (compare == 1)
                {
                    if (currentNode.RightChild == null)
                    {
                        currentNode.RightChild = node;
                        node.Parent = currentNode;
                        return;
                    }

                    currentNode = currentNode.RightChild;
                }

                else if (compare == -1)
                {
                    if (currentNode.LeftChild == null)
                    {
                        currentNode.LeftChild = node;
                        node.Parent = currentNode;
                        return;
                    }
                    currentNode = currentNode.LeftChild;


                }

            }

        }

        public Node<T> Delete(T value)
        {
            Node<T> currentNode = Search(value);
        }

        public Node<T> Search(T val)
        {
            Node<T> current = root;

            while (current != null)
            {
                int comp = val.CompareTo(current.value);

                if (comp == 0)
                {
                    break;
                }

                else if (comp < 0)
                {
                    current = current.LeftChild;
                }

                else
                {
                    current = current.RightChild;
                }
            }

            return current;
        }

        Node<T> Minimum(Node<T> node)
        {
            Node<T> currentNode = node;

            while (currentNode.LeftChild != null)
            {
                currentNode = currentNode.LeftChild;
            }

            return currentNode;
        }

        Node<T> Maximum(Node<T> node)
        {
            Node<T> currentNode = node;

            while(currentNode.RightChild != null)
            {
                currentNode = currentNode.RightChild;
            }

            return currentNode;
        }
    }
}
