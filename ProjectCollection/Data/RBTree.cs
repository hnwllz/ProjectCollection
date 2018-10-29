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

            RBTreeNode newNode = new RBTreeNode(val) { Left = new Nil(), Right = new Nil() };
            newNode.Left.Parent = newNode;
            newNode.Right.Parent = newNode;
            if (Root == null)
            {
                Root = newNode;
                Root.Color = RBTreeNodeColors.Black;
                return;
            }

            
            RBTreeNode cur = Root;
            RBTreeNode father = cur;
            while(cur != null && !(cur is Nil))
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

                if (uncle.Color == RBTreeNodeColors.Red)
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
                        if(newNode == parent.Right)
                        {
                            LeftRotation(parent);
                        }

                        RightRotation(grandpa);
                    }
                    else
                    {
                        if(newNode == parent.Left)
                        {
                            RightRotation(parent);
                        }

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

        public void Remove(int value)
        {
            RBTreeNode delNode = FindNode(value);
            if(delNode == null)
            {
                return;
            }

           Remove(delNode);
        }

        private void Remove(RBTreeNode z)
        {
            RBTreeNode y;
            if(IsNil(z.Left) || IsNil(z.Right))
            {
                y = z;
            }
            else
            {
                y = FindsuccedNode(z);
            }

            RBTreeNode x;
            if (IsNil(y.Left))
            {
                x = y.Right;
            }
            else
            {
                x = y.Left;
            }

            x.Parent = y.Parent;
            if(y.Parent == null)
            {
                Root = x;
            }
            else
            {
                if(y == y.Parent.Left)
                {
                    y.Parent.Left = x;
                }
                else
                {
                    y.Parent.Right = x;
                }
            }

            if(y != z)
            {
                z.Value = y.Value;
            }

            if(y.Color == RBTreeNodeColors.Black)
            {
               RB_Delete_Fixup(x);
            }

            return;
        }

        private void RB_Delete_Fixup(RBTreeNode x)
        {
            RBTreeNode bro = null;
            while(x != Root && x.Color == RBTreeNodeColors.Black)
            {
                if(x == x.Parent.Left)
                {
                    bro = x.Parent.Right;
                    if (bro.Color == RBTreeNodeColors.Red)
                    {
                        bro.Color = RBTreeNodeColors.Black;
                        x.Parent.Color = RBTreeNodeColors.Red;
                        LeftRotation(x.Parent);
                        bro = x.Parent.Right;
                    }

                    if(bro.Left.Color == RBTreeNodeColors.Black &&
                        bro.Right.Color == RBTreeNodeColors.Black)
                    {
                        bro.Color = RBTreeNodeColors.Red;
                        x = x.Parent;
                    }
                    else
                    {
                        if (bro.Left.Color == RBTreeNodeColors.Red)
                        {
                            bro.Left.Color = RBTreeNodeColors.Black;
                            bro.Color = RBTreeNodeColors.Red;
                            RightRotation(bro);
                            bro = x.Parent.Right;
                        }

                        bro.Color = x.Parent.Color;
                        x.Parent.Color = RBTreeNodeColors.Black;
                        bro.Right.Color = RBTreeNodeColors.Black;
                        LeftRotation(x.Parent);
                        x = Root;
                    }
                }
                else
                {
                    bro = x.Parent.Left;
                    if (bro.Color == RBTreeNodeColors.Red)
                    {
                        bro.Color = RBTreeNodeColors.Black;
                        x.Parent.Color = RBTreeNodeColors.Red;
                        RightRotation(x.Parent);
                        bro = x.Parent.Left;
                    }

                    if (bro.Left.Color == RBTreeNodeColors.Black &&
                        bro.Right.Color == RBTreeNodeColors.Black)
                    {
                        bro.Color = RBTreeNodeColors.Red;
                        x = x.Parent;
                    }
                    else
                    {
                        if (bro.Right.Color == RBTreeNodeColors.Red)
                        {
                            bro.Left.Color = RBTreeNodeColors.Black;
                            bro.Color = RBTreeNodeColors.Red;
                            LeftRotation(bro);
                            bro = x.Parent.Right;
                        }

                        bro.Color = x.Parent.Color;
                        x.Parent.Color = RBTreeNodeColors.Black;
                        bro.Right.Color = RBTreeNodeColors.Black;
                        RightRotation(x.Parent);
                        x = Root;
                    }
                }                
            }

            x.Color = RBTreeNodeColors.Black;
        }

        private bool IsNil(RBTreeNode node)
        {
            return node is Nil;
        }

        /*
        private RBTreeNode Remove(RBTreeNode node)
        {
            if ( !IsNil(node.Left)  && !IsNil(node.Right))
            {
                RBTreeNode succedNode = FindsuccedNode(node);
                node.Value = succedNode.Value;

                return Remove(succedNode);
            }
            else if (IsNil(node.Left) && IsNil(node.Right))
            {
                if (node.Parent == null)
                {
                    Root = null;
                    return null;
                }
                else if (node == node.Parent.Left)
                {
                    node.Parent.Left = new Nil(node.Parent);
                    return node.Parent.Left;
                }
                else
                {
                    node.Parent.Right = new Nil(node.Parent);
                    return node.Parent.Right;
                }
            }
            else
            {
                RBTreeNode childNode = IsNil(node.Left) ? node.Right : node.Left;
                if (node.Parent == null)
                {
                    Root = childNode;
                }
                else if (node == node.Parent.Left)
                {
                    node.Parent.Left = childNode;
                    childNode.Parent = node.Parent.Left;
                }
                else
                {
                    node.Parent.Right = childNode;
                    childNode.Parent = node.Parent.Right;
                }

                return childNode;
            }
        }
        */

        private RBTreeNode FindsuccedNode(RBTreeNode delNode)
        {
            RBTreeNode node = delNode.Right;
            RBTreeNode father = node;
            while(!IsNil(node))
            {
                father = node;
                node = node.Left;
            }

            return father;
        }

        public RBTreeNode FindNode(int value)
        {
            RBTreeNode node = Root;
            while(IsNil(node))
            {
                if(node.Value == value)
                {
                    return node;
                }

                if(value <= node.Value)
                {
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }

            return null;
        }


        private void FixDeledTreeBalance(RBTreeNode delNode)
        {
            if(delNode == null || delNode.Parent == null)
            {
                return;
            }

            
            RBTreeNode fahter = delNode.Parent;
            RBTreeNode bro = fahter.Left;
            bool isLeft = (fahter.Left == delNode);          
            if (delNode == fahter.Left)
            {
                bro = delNode.Parent.Right;
            }

            //Case 1: father is red
            if(fahter.Color == RBTreeNodeColors.Red)
            {
                fahter.Color = RBTreeNodeColors.Black;
                bro.Color = RBTreeNodeColors.Red;

                return;
            }

            //Case 2:parent is black,brother is red
            if(bro.Color == RBTreeNodeColors.Red)
            {
                fahter.Color = RBTreeNodeColors.Red;
                bro.Color = RBTreeNodeColors.Black;
                if(isLeft)
                {
                    LeftRotation(fahter);
                }
                else
                {
                    RightRotation(fahter);
                }

                return;
            }

            //case 3： parent is black,brohter is black,brother right is red
            if(bro.Right != null && bro.Right.Color == RBTreeNodeColors.Red)
            {
                LeftRotation(bro);
                FixDeledTreeBalance(delNode);

                return;
            }
            //case 4： parent is black,brohter is black,brother left is red
            if (bro.Left!=null && bro.Left.Color == RBTreeNodeColors.Red)
            {
                RightRotation(bro);
                FixDeledTreeBalance(delNode);

                return;
            }

            //case 5： parent is black,brohter is black,sons of brother  is black
            bro.Color = RBTreeNodeColors.Red;
            FixDeledTreeBalance(fahter);
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

    public class Nil : RBTreeNode
    {
        public Nil()
        {
            Value = 0;
            Color = RBTreeNodeColors.Black;
        }

        public Nil(RBTreeNode parent)
        {
            Value = 0;
            Color = RBTreeNodeColors.Black;
            Parent = parent;
        }

        private static Nil NullInstance = new Nil();
        public static Nil Null
        {
            get
            {
                return NullInstance;
            }
        }
    }

    public enum RBTreeNodeColors
    {
        Black,
        Red
    }
}
