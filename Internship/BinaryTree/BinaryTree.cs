using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace BinaryTree
{
    public class BinaryTree
    {
        private BinaryTreeNode _root;

        public BinaryTree(params int[] numbers)
        {
            CreateTreeАFromIEnumerable(numbers);
        }
        public BinaryTree(IEnumerable<int> numbers)
        {
            CreateTreeАFromIEnumerable(numbers);
        }

        public virtual bool Insert(int numb)
        {
            var newNode = new BinaryTreeNode(numb);

            if (_root == null)
            {
                _root = newNode;
                return true;
            }

            var currentNode = _root;
            var parentNode = _root;

            while (true)
            {
                parentNode = currentNode;
                if (newNode.Data < currentNode.Data)
                {
                    currentNode = currentNode.LeftChild;
                    if (currentNode == null)
                    {
                        parentNode.LeftChild = newNode;
                        return true;
                    }
                    continue;
                }

                if (newNode.Data > currentNode.Data)
                {
                    currentNode = currentNode.RightChild;
                    if (currentNode == null)
                    {
                        parentNode.RightChild = newNode;
                        return true;
                    }
                    continue;
                }

                if (newNode.Data == currentNode.Data)
                {
                    return false;
                }
            }
        }
        public void Traverse(Action<BinaryTreeNode> preOrderVisit, Action<BinaryTreeNode> inOrderVisit, Action<BinaryTreeNode> postOrderVisit, Action nullHandler = null,
            Action<BinaryTreeNode> rootPreOrderVisit = null, Action<BinaryTreeNode> rootInOrderVisit = null, Action<BinaryTreeNode> rootPostOrderVisit = null,
            Action rootNullHandler = null)
        {
            if (_root == null)
            {
                (rootNullHandler ?? nullHandler)?.Invoke();
            }

            (rootPreOrderVisit ?? preOrderVisit)?.Invoke(_root);
            Traverse(_root.LeftChild);
            (rootInOrderVisit ?? inOrderVisit)?.Invoke(_root);
            Traverse(_root.RightChild);
            (rootPostOrderVisit ?? postOrderVisit)?.Invoke(_root);

            void Traverse(BinaryTreeNode node)
            {
                if (node != null && node != _root)
                {
                    preOrderVisit?.Invoke(node);
                    Traverse(node.LeftChild);
                    inOrderVisit?.Invoke(node);
                    Traverse(node.RightChild);
                    postOrderVisit?.Invoke(node);
                }
                nullHandler?.Invoke();
            }
        }
        public void TraversePreOrder(Action<BinaryTreeNode> visit)
        {
            Traverse(visit, null, null);
        }
        public void TraverseInOrder(Action<BinaryTreeNode> visit)
        {
            Traverse(null, visit, null);
        }
        public void TraversePostOrder(Action<BinaryTreeNode> visit)
        {
            Traverse(null, null, visit);
        }
        public void TraverseLevelOrder(Action<BinaryTreeNode> visit)
        {
            var nodeQueue = new Queue<BinaryTreeNode>();

            if (_root != null)
            {
                nodeQueue.Enqueue(_root);
            }

            while (nodeQueue.Count > 0)
            {
                var currentNode = nodeQueue.Dequeue();

                visit(currentNode);

                if (currentNode.LeftChild != null)
                {
                    nodeQueue.Enqueue(currentNode.LeftChild);
                }
                if (currentNode.RightChild != null)
                {
                    nodeQueue.Enqueue(currentNode.RightChild);
                }
            }
        }
        public bool SaveToFile(string path)
        {
            if (!Path.IsPathFullyQualified(path))
                return false;

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };

            using (var writer = XmlWriter.Create(path, settings))
            {
                Traverse(PreOrder, InOrder, PostOrder, NullHandler, RootPreOrder, null, null, RootNullHandler);

                void PreOrder(BinaryTreeNode node)
                {
                    writer.WriteAttributeString("Value", node.Data.ToString());
                    writer.WriteStartElement("LeftChild");
                }
                void InOrder(BinaryTreeNode node)
                {
                    writer.WriteEndElement();
                    writer.WriteStartElement("RightChild");
                }
                void PostOrder(BinaryTreeNode node)
                {
                    writer.WriteEndElement();
                }
                void NullHandler()
                {
                    writer.WriteValue(null);
                }
                void RootPreOrder(BinaryTreeNode root)
                {
                    writer.WriteStartElement("Root");
                    writer.WriteAttributeString("Value", root.Data.ToString());
                    writer.WriteStartElement("LeftChild");
                }
                void RootNullHandler()
                {
                    writer.WriteStartElement("Root");
                    writer.WriteAttributeString("Value", null);
                }
            }

            return true;
        }
        protected virtual void CreateTreeАFromIEnumerable(IEnumerable<int> numbers)
        {
            foreach (var number in numbers)
            {
                Insert(number);
            }
        }
    }
}
