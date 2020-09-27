using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO.MemoryMappedFiles;
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

                if (compare >= 0)
                {
                    if (currentNode.RightChild == null)
                    {
                        currentNode.RightChild = node;
                        node.Parent = currentNode;
                        return;
                    }

                    currentNode = currentNode.RightChild;
                }

                else
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

        public void PrintTree()
        {
            PrintTreePreOrder(root, Console.WindowWidth / 2, 0, 18);
        }

        private void PrintTreePreOrder(Node<T> node, int x, int y, int dx)
        {
            if (node == null)
            {
                return;
            }
            Console.SetCursorPosition(x, y);
            Console.WriteLine(node.value);
            PrintTreePreOrder(node.LeftChild, x - dx, y + 1, dx - 4);
            PrintTreePreOrder(node.RightChild, x + dx, y + 1, dx - 4);

        }

        public bool Delete(T value)
        {
            Node<T> currentNode = Search(value);

            if (currentNode == null)
            {
                return false;
            }

            //2 Children
            if (currentNode.RightChild != null && currentNode.LeftChild != null)
            {
                var candidate = currentNode.LeftChild;
                while (candidate.RightChild != null)
                {
                    candidate = candidate.RightChild;
                }

                currentNode.value = candidate.value;

                currentNode = candidate;
            }

            //No Children
            if (currentNode.LeftChild == null && currentNode.RightChild == null)
            {
                if (currentNode == root)    // if root c  
                {
                    root = null;
                }

                else if (currentNode.IsLeftChild) // if left child c 
                {
                    currentNode.Parent.LeftChild = null;
                }

                else // if right child c 
                {
                    currentNode.Parent.RightChild = null;
                }

                return true;
            }
            else
            {
                //1 Child
                var parent = currentNode.Parent;
                //var child = currentNode.LeftChild != null ? currentNode.LeftChild : currentNode.RightChild;

                Node<T> child = currentNode.LeftChild;

                if (child == null)
                {
                    child = currentNode.RightChild;
                }


                if (currentNode == root)
                {
                    root = child;
                }

                // if leftchild
                if(currentNode.IsLeftChild)
                {
                    parent.LeftChild = child;
                }

                // if rightchild
                else
                {
                    parent.RightChild = child;
                }

                child.Parent = parent;

                return true;
    
            }

        }


        public bool Delete2(T value)
        {
            Node<T> currentNode = Search(value);
            //2 children
            var candidate = currentNode.LeftChild;
            while(candidate.RightChild != null)
            {
                candidate = candidate.RightChild;
            }
            candidate.value = currentNode.value;
            candidate.Parent = currentNode.Parent;

            //No children
            if(currentNode.LeftChild == null && currentNode.RightChild == null)
            {
                if (currentNode.value.Equals(root.value))
                {
                    root = null;
                }

                else if(currentNode.IsLeftChild)
                {
                    currentNode.Parent.LeftChild = null;
                }

                else
                {
                    currentNode.Parent.RightChild = null;
                }
            }

            //1 child 
            child = currentNode.LeftChild != null ? LeftChild : RightChild 
            if(currentNode.child.IsLeftChild)
            {
                
            }


            return false;
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
