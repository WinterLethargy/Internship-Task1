using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class BinaryTreeNode
    {
        public int Data { get; set; }
        public BinaryTreeNode LeftChild { get; set; }
        public BinaryTreeNode RightChild { get; set; }

        public BinaryTreeNode()
        {

        }
        public BinaryTreeNode(int numb)
        {
            Data = numb;
        }
    }
}
