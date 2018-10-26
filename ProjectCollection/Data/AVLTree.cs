using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCollection.Data
{
    public class AVLTree
    {
        public AVLTreeNode Root { get; private set; }

        public void Add(int value)
        {
            AVLTreeNode newNode = new AVLTreeNode(value);

            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                AVLTreeNode cur = Root;
                AVLTreeNode facther = cur;
                while (cur != null)
                {
                    facther = cur;
                    if (cur.Value >= value)
                    {
                        cur = cur.Left;
                    }
                    else
                    {
                        cur = cur.Right;
                    }
                }

                if(facther.Value >= value)
                {
                    newNode.Parent = facther;
                    facther.Left = newNode;
                }
                else
                {
                    newNode.Parent = facther;
                    facther.Right = newNode;
                }
            }

            FixTreeNodeHighEx(newNode);
        }

        
        private void FixTreeNodeHigh(AVLTreeNode treeNode)
        {
            if(treeNode == null)
            {
                return;
            }

            treeNode.HighValue = Math.Max(GetNodeHight(treeNode.Left), GetNodeHight(treeNode.Right)) + 1;
            if(treeNode.Parent == null)
            {
                return;
            }

            int leftH = GetNodeHight(treeNode.Parent.Left);
            int rightH = GetNodeHight(treeNode.Parent.Right);
            if(leftH - rightH > 1)
            {
                //左左的情况
                if(GetNodeHight(treeNode.Left) > GetNodeHight(treeNode.Right))
                {
                    RightRotation(treeNode.Parent);
                }
                else
                {
                    //左右的情况，先右旋再左旋
                    RightLeftRotation(treeNode.Parent);
                }
            }
            else if(rightH - leftH > 1)
            {
                
                if (GetNodeHight(treeNode.Left) > GetNodeHight(treeNode.Right))
                {
                    LeftRightRotation(treeNode.Parent);
                }
                else
                {
                    LeftRotation(treeNode.Parent);
                }
            }

            FixTreeNodeHigh(treeNode.Parent);
        }

        private void FixTreeNodeHighEx(AVLTreeNode treeNode)
        {
            if(treeNode == null)
            {
                return;
            }

            int leftH = GetNodeHight(treeNode.Left);
            int rightH = GetNodeHight(treeNode.Right);
            
            if(leftH - rightH > 1)
            {
                int llh = GetNodeHight(treeNode.Left.Left);
                int lrh = GetNodeHight(treeNode.Left.Right);
                if(llh > lrh)
                {
                    RightRotation(treeNode);
                }
                else
                {
                    LeftRightRotation(treeNode);
                }
            }
            else if(rightH - leftH > 1)
            {
                int rlh = GetNodeHight(treeNode.Right.Left);
                int rrh = GetNodeHight(treeNode.Right.Right);
                if(rrh > rlh)
                {
                    LeftRotation(treeNode);
                }
                else
                {
                    RightLeftRotation(treeNode);
                }
            }

            treeNode.HighValue = Math.Max(GetNodeHight(treeNode.Left), GetNodeHight(treeNode.Right))+1;
            FixTreeNodeHighEx(treeNode.Parent);
        }

        private void RightLeftRotation(AVLTreeNode treeNode)
        {
            RightRotation(treeNode.Right);
            LeftRotation(treeNode);
        }

        private void LeftRightRotation(AVLTreeNode treeNode)
        {
            LeftRotation(treeNode.Left);
            RightRotation(treeNode);
        }

        private void RightRotation(AVLTreeNode treeNode)
        {
            AVLTreeNode left = treeNode.Left;
            left.Parent = treeNode.Parent;

            treeNode.Left = left.Right;
            if (left.Right != null)
            {
                left.Right.Parent = treeNode;
            }
            

            if(treeNode.Parent == null)
            {
                Root = left;
            }
            else if(treeNode.Parent.Left == treeNode)
            {
                treeNode.Parent.Left = left;
            }
            else
            {
                treeNode.Parent.Right = left;
            }

            treeNode.Parent = left;
            left.Right = treeNode;
            treeNode.HighValue = Math.Max(GetNodeHight(treeNode.Left), GetNodeHight(treeNode.Right)) + 1;
        }

        private void LeftRotation(AVLTreeNode treeNode)
        {
            AVLTreeNode right = treeNode.Right;
            right.Parent = treeNode.Parent;

            treeNode.Right = right.Left;
            if (right.Left != null)
            {
                right.Left.Parent = treeNode;
            }            

            if(treeNode.Parent == null)
            {
                Root = right;
            }
            else if(treeNode.Parent.Left == treeNode)
            {
                treeNode.Parent.Left = right;
            }
            else
            {
                treeNode.Parent.Right = right;
            }

            treeNode.Parent = right;
            right.Left = treeNode;
            treeNode.HighValue = Math.Max(GetNodeHight(treeNode.Left),GetNodeHight(treeNode.Right))+1;
        }

        private int GetNodeHight(AVLTreeNode avlNode)
        {
            if(avlNode == null)
            {
                return 0;
            }

            return avlNode.HighValue;
        }

        public void Remove(int value)
        {
            AVLTreeNode node = FindTreeNode(value);
            if(node == null)
            {
                return;
            }

            Remove(node);
        }

        private void Remove(AVLTreeNode node)
        {
            AVLTreeNode parentOfRemovedNode = null;
            if (node.Left != null && node.Right != null)
            {
                AVLTreeNode successor = FindSuccessorNode(node);
                node.Value = successor.Value;
                Remove(successor);
            }
            else if (node.Left == null && node.Right == null)
            {
                if (node.Parent == null)
                {
                    Root = null;
                }
                else
                {
                    if (node.Parent.Left == node)
                    {
                        node.Parent.Left = null;
                    }
                    else
                    {
                        node.Parent.Right = null;
                    }

                    parentOfRemovedNode = node.Parent;
                    node.Parent = null;
                }
            }
            else
            {
                AVLTreeNode childNode = node.Left != null ? node.Left : node.Right;
                childNode.Parent = node.Parent;
                if (node.Parent == null)
                {
                    Root = childNode;
                }
                else
                {
                    if (node.Parent.Left == node)
                    {
                        node.Parent.Left = childNode;
                    }
                    else
                    {
                        node.Parent.Right = childNode;
                    }

                    parentOfRemovedNode = node.Parent;
                }
            }

            if (parentOfRemovedNode != null)
            {
                FixTreeNodeHighEx(parentOfRemovedNode);
            }
        }

        /// <summary>
        /// 找到后继节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private AVLTreeNode FindSuccessorNode(AVLTreeNode node)
        {
            if(node.Right == null)
            {
                return null;
            }

            AVLTreeNode cur = node.Right;
            while(cur.Left != null)
            {
                cur = cur.Left;
            }

            return cur;
        }

        private AVLTreeNode FindTreeNode(int value)
        {
            AVLTreeNode cur = Root;
            while(cur != null)
            {
                if(cur.Value == value)
                {
                    return cur;
                }

                if(cur.Value < value)
                {
                    cur = cur.Right;
                }
                else
                {
                    cur = cur.Left;
                }
            }

            return null;
        }
    }

    public class AVLTreeNode
    {
        public AVLTreeNode() { }
        public AVLTreeNode(int key)
        {
            this.Value = key;
        }
        public AVLTreeNode(int key,AVLTreeNode parent)
        {
            this.Value = key;
            this.Parent = parent;
        }

        public int Value { get; set; }
        public AVLTreeNode Left { get; set; }
        public AVLTreeNode Right { get; set; }
        public AVLTreeNode Parent { get; set; }
        public int HighValue { get; set; }
    }
}
