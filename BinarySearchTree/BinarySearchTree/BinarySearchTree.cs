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


        public List<Node<T>> PreOrder()
        {
            List<Node<T>> preOrderList = new List<Node<T>>();
            Stack<Node<T>> preOrderStack = new Stack<Node<T>>();
            var currentNode = root;
            preOrderStack.Push(root);
            currentNode = currentNode.LeftChild;
            while (preOrderStack.Count != 0) //while stack has values
            {
                currentNode = preOrderStack.Pop();
                preOrderList.Add(currentNode);
                if (currentNode.RightChild != null)
                {
                    preOrderStack.Push(currentNode.RightChild);

                }

                if (currentNode.LeftChild != null)
                {
                    preOrderStack.Push(currentNode.LeftChild);
                }
            }

            return preOrderList;
        }

        public List<Node<T>> InOrder()
        {
            List<Node<T>> initial = PreOrder();
            for (int i = 0; i < initial.Count; i++)
            {
                initial[i].visited = false;
            }
            List<Node<T>> inOrderList = new List<Node<T>>();
            Stack<Node<T>> inOrderStack = new Stack<Node<T>>();
            var currentNode = root;
            inOrderStack.Push(root);

            while (inOrderStack.Count != 0)
            {
                currentNode = inOrderStack.Pop();

                if (currentNode.visited == false)
                {
                    currentNode.visited = true;
                    if (currentNode.RightChild != null)
                    {
                        inOrderStack.Push(currentNode.RightChild);
                    }

                    inOrderStack.Push(currentNode);
                    if (currentNode.LeftChild != null)
                    {
                        inOrderStack.Push(currentNode.LeftChild);
                    }
                }

                else
                {
                    inOrderList.Add(currentNode);
                }
            }


            return inOrderList;
        }

        public List<Node<T>> PostOrder()
        {
            List<Node<T>> initial = PreOrder();
            for (int i = 0; i < initial.Count; i++)
            {
                initial[i].visited = false;
            }
            List<Node<T>> postOrderList = new List<Node<T>>();
            Stack<Node<T>> postOrderStack = new Stack<Node<T>>();
            var currentNode = root;
            postOrderStack.Push(root);

            while (postOrderStack.Count != 0)
            {
                currentNode = postOrderStack.Pop();

                if (currentNode.visited == false)
                {
                    currentNode.visited = true;
                    postOrderStack.Push(currentNode);
                    if (currentNode.RightChild != null)
                    {
                        postOrderStack.Push(currentNode.RightChild);
                    }

                    if (currentNode.LeftChild != null)
                    {
                        postOrderStack.Push(currentNode.LeftChild);
                    }
                }

                else
                {
                    postOrderList.Add(currentNode);
                }
            }
            return postOrderList;
        }

        public List<Node<T>> BFT()
        {
            List<Node<T>> bftList = new List<Node<T>>();
            Queue<Node<T>> bftQueue = new Queue<Node<T>>();
            bftQueue.Enqueue(root);
            var currentNode = root;

            while (bftQueue.Count != 0)
            {
                currentNode = bftQueue.Dequeue();
                bftList.Add(currentNode);

                if(currentNode.LeftChild != null)
                {
                    bftQueue.Enqueue(currentNode.LeftChild);
                }

                if (currentNode.RightChild != null)
                {
                    bftQueue.Enqueue(currentNode.RightChild);
                }
            }



            return bftList;
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
                if (currentNode.IsLeftChild)
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
            if (currentNode == null)
            {
                return false;
            }

            bool cases = false;

            //2 children
            //if it has both children
            if (currentNode.LeftChild != null && currentNode.RightChild != null)
            {
                var candidate = currentNode.LeftChild;
                while (candidate.RightChild != null)
                {
                    candidate = candidate.RightChild;
                }
                currentNode.value = candidate.value;
                currentNode = candidate;
                cases = true;
            }
            //No children
            if (currentNode.LeftChild == null && currentNode.RightChild == null)
            {
                if (currentNode.value.Equals(root.value))
                {
                    root = null;
                }

                else if (currentNode.IsLeftChild)
                {
                    currentNode.Parent.LeftChild = null;
                }

                else
                {
                    currentNode.Parent.RightChild = null;
                }
                cases = true;
            }

            //1 child 
            if (cases == false)
            {
                var child = currentNode.LeftChild != null ? currentNode.LeftChild : currentNode.RightChild;
                if (currentNode.IsLeftChild)
                {
                    child.Parent = currentNode.Parent;
                    currentNode.Parent.LeftChild = child;
                }

                else
                {
                    child.Parent = currentNode.Parent;
                    currentNode.Parent.RightChild = child;
                }
            }

            return true;
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

            while (currentNode.RightChild != null)
            {
                currentNode = currentNode.RightChild;
            }

            return currentNode;
        }
    }
}
