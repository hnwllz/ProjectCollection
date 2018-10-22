using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCollection.Data
{
    public class BinarySearchTree : IBinaryTree<int>
    {
        private IBinaryTreeNode<int> Root { get; set; }
        private int Count { get; set; }

        public void Add(int value)
        {
            Count++;

            if (Root == null)
            {
                Root = new BinaryTreeNode(value);
                return;
            }

            var cur = Root;
            var p = cur;
            while(cur != null)
            {
                if(cur.Key >= value)
                {
                    p = cur;
                    cur = cur.Left;
                }
                else
                {
                    p = cur;
                    cur = cur.Right;
                }
            }

            if(value <= p.Key)
            {
                p.Left = new BinaryTreeNode(value);
                p.Left.Parent = p;
            }
            else
            {
                p.Right = new BinaryTreeNode(value);
                p.Right.Parent = p;
            }
        }

        public bool Exists(int value)
        {
            var cur = Root;
            while(cur != null)
            {
                if(cur.Key == value)
                {
                    return true;
                }

                if(cur.Key >= value)
                {
                    cur = cur.Left;
                }
                else
                {
                    cur = cur.Right;
                }
            }

            return false;
        }

        public void Remove(int value)
        {
            var cur = Root;
            while(cur != null)
            {
                if (cur.Key == value)
                {
                    Remove(cur);
                    Count--;
                    return;
                }

                if (cur.Key >= value)
                {
                    cur = cur.Left;
                }
                else
                {
                    cur = cur.Right;
                }
            }
        }

        private void Remove(IBinaryTreeNode<int> treeNode)
        {
            if(treeNode.Left != null && treeNode.Right != null)
            {
                var cur = treeNode.Right;
                while(cur.Left != null)
                {
                    cur = cur.Left;
                }

                treeNode.Key = cur.Key;
                if(cur == treeNode.Right)
                {
                    treeNode.Right = cur.Right;
                }
                else
                {
                    cur.Parent.Left = cur.Right;
                    cur.Parent = null;
                }
            }
            else if(treeNode.Left == null && treeNode.Right == null)
            {
                if(Root == treeNode)
                {
                    Root = null;
                }

                if (treeNode.Parent.Left == treeNode)
                {
                    treeNode.Parent.Left = null;
                    treeNode.Parent = null;
                }
                else
                {
                    treeNode.Parent.Right = null;
                    treeNode.Parent = null;
                }
            }
            else
            {
                var son = treeNode.Left ?? treeNode.Right;
                if(treeNode == Root)
                {
                    Root = son;
                }

                son.Parent = treeNode.Parent;
                if(treeNode.Parent.Left == treeNode)
                {
                    treeNode.Parent.Left = son;
                }
                else
                {
                    treeNode.Parent.Right = son;
                }
            }
        }

        /// <summary>
        /// 先序遍历
        /// </summary>
        /// <returns></returns>
        public int[] PreOrder()
        {
            int[] nums = new int[Count];
            int index = 0;

            SubPreOrder(Root, nums, ref index);
            return nums;
        }

        private void SubPreOrder(IBinaryTreeNode<int> treeNode,int[] nums,ref int index)
        {
            if(treeNode == null)
            {
                return;
            }

            SubPreOrder(treeNode.Left, nums,ref index);
            nums[index++] = treeNode.Key;
            SubPreOrder(treeNode.Right, nums,ref index);
        }

        public bool IsBST()
        {
            if(Root == null)
            {
                return true;
            }

            return IsBST(Root);
        }

        private bool IsBST(IBinaryTreeNode<int> treeNode)
        {
            if(treeNode.Left != null)
            {
                if(treeNode.Left.Key > treeNode.Key || !IsBST(treeNode.Left))
                {
                    return false;
                }
            }

            if(treeNode.Right != null)
            {
                if(treeNode.Right.Key < treeNode.Key || !IsBST(treeNode.Right))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
