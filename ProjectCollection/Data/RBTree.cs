using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCollection.Data
{
    /// <summary>
    /// 红黑树
    /// 红黑树的五个规则
    /// 1.根节点必须是黑色
    /// 2.节点是黑色或者红色
    /// 3.叶子节点（指Null节点）都是黑色
    /// 4.红色节点后必须是黑色节点
    /// 5.根节点到叶子节点的每个分支上的黑色节点数量一致
    /// </summary>
    public class RBTree
    {
        public RBTreeNode Root { get; private set; }

        public void Add(int val)
        {
            if(Root == null)
            {
                Root = new RBTreeNode(val, RBTreeNodeColors.Black);
                return;
            }

            RBTreeNode newNode = new RBTreeNode(val);
            RBTreeNode cur = Root;
            RBTreeNode father = cur;
            while(cur != null)
            {
                father = cur;
                if(val <= cur.Value)
                {
                    cur = cur.Left;
                }
                else
                {
                    cur = cur.Right;
                }
            }

            newNode.Parent = father;
            if (val <= father.Value)
            {
                father.Left = newNode;
            }
            else
            {
                father.Right = newNode;
            }

            FixTreeBalance(newNode);            
        }

        /// <summary>
        /// 红黑树自平衡
        /// </summary>
        /// <param name="newNode"></param>
        private void FixTreeBalance(RBTreeNode newNode)
        {
            if(newNode.Parent == null)
            {
                newNode.Color = RBTreeNodeColors.Black;
            }
            else if(newNode.Parent.Color == RBTreeNodeColors.Black)
            {
                //黑色什么都不做
                return;
            }
            else
            {
                RBTreeNode parent = newNode.Parent;
                RBTreeNode grandpa = parent.Parent;
                RBTreeNode uncle = null;
                if(parent == grandpa.Left)
                {
                    uncle = grandpa.Right;
                }
                else
                {
                    uncle = grandpa.Left;
                }

                if (uncle != null && uncle.Color == RBTreeNodeColors.Red)
                {
                    parent.Color = RBTreeNodeColors.Black;
                    uncle.Color = RBTreeNodeColors.Black;
                    grandpa.Color = RBTreeNodeColors.Red;

                    FixTreeBalance(grandpa);
                }
                else
                {
                    parent.Color = RBTreeNodeColors.Black;
                    grandpa.Color = RBTreeNodeColors.Red;

                    if (parent == grandpa.Left)
                    {
                        RightRotation(grandpa);
                    }
                    else
                    {
                        LeftRotation(grandpa);
                    }
                }
            }
        }


        private void RightRotation(RBTreeNode treeNode)
        {
            RBTreeNode left = treeNode.Left;
            left.Parent = treeNode.Parent;

            treeNode.Left = left.Right;
            if (left.Right != null)
            {
                left.Right.Parent = treeNode;
            }


            if (treeNode.Parent == null)
            {
                Root = left;
            }
            else if (treeNode.Parent.Left == treeNode)
            {
                treeNode.Parent.Left = left;
            }
            else
            {
                treeNode.Parent.Right = left;
            }

            treeNode.Parent = left;
            left.Right = treeNode;
        }

        private void LeftRotation(RBTreeNode treeNode)
        {
            RBTreeNode right = treeNode.Right;
            right.Parent = treeNode.Parent;

            treeNode.Right = right.Left;
            if (right.Left != null)
            {
                right.Left.Parent = treeNode;
            }

            if (treeNode.Parent == null)
            {
                Root = right;
            }
            else if (treeNode.Parent.Left == treeNode)
            {
                treeNode.Parent.Left = right;
            }
            else
            {
                treeNode.Parent.Right = right;
            }

            treeNode.Parent = right;
            right.Left = treeNode;
        }
    }

    public class RBTreeNode
    {

        public RBTreeNode() : this(0) { }

        public RBTreeNode(int val):
            this(val, RBTreeNodeColors.Red)
        {
        }

        public RBTreeNode(int value,RBTreeNodeColors color)
        {
            Value = value;
            Color = color;
        }

        public int Value { get; set; }
        public RBTreeNode Left { get; set; }
        public RBTreeNode Right { get; set; }
        public RBTreeNode Parent { get; set; }

        public RBTreeNodeColors Color { get; set; }
    }

    public enum RBTreeNodeColors
    {
        Black,
        Red
    }
}
