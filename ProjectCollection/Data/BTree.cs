using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCollection.Data
{
    public class BTree
    {
        private readonly int Node_N;
        public BTreeNode Root { get; private set; }
        public BTree(int n)
        {
            Node_N = n;
        }

        public void Add(int val)
        {
            if(Root == null)
            {
                Root = NewNode();
                Root.Values[0] = val;
                Root.Index++;
                return;
            }

            BTreeNode cur = Root;
            BTreeNode leafNode = cur;
            int pos = 0;
            while (cur != null)
            {
                pos = 0;
                while (pos < cur.Index)
                {
                    if (cur.Values[pos] > val)
                    {
                        break;
                    }

                    pos++;
                }

                leafNode = cur;
                cur = cur.Nodes[pos];
            }

            for(int i = leafNode.Index; i > pos; i--)
            {
                leafNode.Values[i] = leafNode.Values[i - 1];
            }

            leafNode.Index++;
            leafNode.Values[pos] = val;

            //如果叶子节点的值满，需要分裂
            cur = leafNode;
            while (cur.Index == Node_N)
            {
                int mid = Node_N / 2;
                int midVal = cur.Values[mid];
                BTreeNode rightNode = NewNode();
                while (cur.Index > ++mid)
                {
                    rightNode.Values[rightNode.Index] = cur.Values[mid];
                    rightNode.Nodes[rightNode.Index] = cur.Nodes[mid];
                    if (rightNode.Nodes[rightNode.Index] != null)
                    {
                        rightNode.Nodes[rightNode.Index].Parent = rightNode;
                    }

                    rightNode.Index++;
                }

                rightNode.Nodes[rightNode.Index] = cur.Nodes[mid];
                if (rightNode.Nodes[rightNode.Index] != null)
                {
                    rightNode.Nodes[rightNode.Index].Parent = rightNode;
                }

                cur.Index = Node_N / 2 ; 

                if (cur.Parent == null)
                {
                    cur.Parent = NewNode();
                    cur.Parent.Values[cur.Parent.Index] = midVal;
                    cur.Parent.Nodes[cur.Parent.Index] = cur;
                    cur.Parent.Nodes[cur.Parent.Index + 1] = rightNode;
                    
                    rightNode.Parent = cur.Parent;
                    cur.Parent.Index++;
                    Root = cur.Parent;
                }
                else
                {
                    int insPos = 0;
                    BTreeNode parent = cur.Parent;
                    for(insPos = 0;insPos < parent.Index; insPos++){
                        if (parent.Values[insPos] > midVal)
                        {
                            break;
                        }
                    }

                    for(int i = parent.Index; i > insPos; i--)
                    {
                        parent.Values[i] = parent.Values[i - 1];
                        parent.Nodes[i + 1] = parent.Nodes[i];
                    }

                    parent.Values[insPos] = midVal;
                    parent.Nodes[insPos+1] = rightNode;
                    rightNode.Parent = parent;
                    parent.Index++;                    
                }

                cur = cur.Parent;
            }
        }

        private BTreeNode Find(int val)
        {
            BTreeNode node = Root;
            while (node != null)
            {
                int i = 0;
                for (i = 0; i < node.Index; i++)
                {
                    if (node.Values[i] == val)
                    {
                        return node;
                    }
                    else if (val < node.Values[i])
                    {
                        break;
                    }
                }

                node = node.Nodes[i];
            }

            return null;
        }

        public BTreeNode FindNode(int val)
        {
            return Find(val);
        }

        public void Remove(int val)
        {
            BTreeNode node = Find(val);
            if(node == null)
            {
                return;
            }

            RemoveNodeOrSuccsor(node, val);
        }

        private void RemoveNodeOrSuccsor(BTreeNode node, int val)
        {
            BTreeNode succsor = node;
            int valIndexInNode = 0;
            for (int i = 0; i < node.Index; i++)
            {
                if (node.Values[i] == val)
                {
                    if (node.Nodes[i + 1] != null)
                    {
                        succsor = node.Nodes[i];
                    }
                    valIndexInNode = i;
                    break;
                }
            }

            int valIndexInSuccsor = valIndexInNode;
            if(succsor != node)
            {
                valIndexInSuccsor = succsor.Index - 1;
                while (succsor.Nodes[succsor.Index] != null)
                {
                    succsor = succsor.Nodes[succsor.Index];
                    valIndexInSuccsor = succsor.Index - 1;
                }
            }

            node.Values[valIndexInNode] = succsor.Values[valIndexInSuccsor];
            for(int i= valIndexInSuccsor; i < succsor.Index-1; i++)
            {
                succsor.Values[i] = succsor.Values[i + 1];
            }
            succsor.Index--;

            FixupNode(succsor);
        }

        private void FixupNode(BTreeNode succsor)
        {
            if(Root == succsor && Root.Index==0)
            {
                Root = Root.Nodes[0];
                return;
            }

            //如果节点值数量大于等于m/2，直接删除
            if (Root == succsor || succsor.Index >= (Node_N / 2))
            {
                return;
            }
            else
            {
                int nodeIndex = 0;
                BTreeNode parent = succsor.Parent;
                for (int i = 0; i <= parent.Index; i++)
                {
                    if (parent.Nodes[i] == succsor)
                    {
                        nodeIndex = i;
                    }
                }

                int broIndex = 0;
                int valInParentIndex = 0;
                if (nodeIndex == parent.Index)
                {
                    broIndex = nodeIndex - 1;
                    valInParentIndex = broIndex;
                }
                else
                {
                    broIndex = nodeIndex + 1;
                    valInParentIndex = nodeIndex;
                }


                BTreeNode broNode = parent.Nodes[broIndex];
                if (broIndex < nodeIndex)//左兄弟
                {
                    if (broNode.Index > Node_N / 2)
                    {
                        for(int i = succsor.Index; i > 0; i--)
                        {
                            succsor.Values[i] = succsor.Values[i - 1];
                            succsor.Nodes[i + 1] = succsor.Nodes[i];
                        }

                        succsor.Nodes[1] = succsor.Nodes[0];
                        succsor.Values[0] = parent.Values[valInParentIndex];
                        parent.Values[valInParentIndex] = broNode.Values[broNode.Index - 1];
                        succsor.Nodes[0] = broNode.Nodes[broNode.Index];
                        if (broNode.Nodes[broNode.Index] != null)
                        {
                            broNode.Nodes[broNode.Index].Parent = succsor;
                            broNode.Nodes[broNode.Index] = null;
                        }
                        succsor.Index++;
                        broNode.Index--;
                    }
                    else
                    {
                        broNode.Values[broNode.Index] = parent.Values[valInParentIndex];
                        for (int i = valInParentIndex; i < parent.Index - 1; i++)
                        {
                            parent.Values[i] = parent.Values[i + 1];
                            parent.Nodes[i + 1] = parent.Nodes[i + 2];
                        }

                        parent.Index--;
                        broNode.Index++;

                        for (int i = 0; i < succsor.Index; i++)
                        {
                            broNode.Nodes[broNode.Index] = succsor.Nodes[i];
                            broNode.Values[broNode.Index] = succsor.Values[i];
                            if (succsor.Nodes[i] != null)
                            {
                                succsor.Nodes[i].Parent = broNode;
                                succsor.Nodes[i] = null;
                            }

                            broNode.Index++;
                        }
                        broNode.Nodes[broNode.Index] = succsor.Nodes[succsor.Index];
                        if (succsor.Nodes[succsor.Index] != null)
                        {
                            succsor.Nodes[succsor.Index].Parent = broNode;
                        }
                        succsor.Index = 0;

                        FixupNode(parent);
                    }
                }
                else //右兄弟
                {
                    if (broNode.Index > Node_N / 2)
                    {
                        succsor.Values[succsor.Index] = parent.Values[valInParentIndex];
                        parent.Values[valInParentIndex] = broNode.Values[0];
                        succsor.Nodes[succsor.Index + 1] = broNode.Nodes[0];
                        if (broNode.Nodes[0] != null)
                        {
                            broNode.Nodes[0].Parent = succsor;
                        }

                        for (int i = 0; i < broNode.Index-1; i++)
                        {
                            broNode.Values[i] = broNode.Values[i + 1];
                            broNode.Nodes[i] = broNode.Nodes[i + 1];
                        }

                        broNode.Nodes[broNode.Index - 1] = broNode.Nodes[broNode.Index];
                        succsor.Index++;
                        broNode.Index--;
                    }
                    else
                    {
                        succsor.Values[succsor.Index] = parent.Values[valInParentIndex];
                        for (int i = valInParentIndex; i < parent.Index - 1; i++)
                        {
                            parent.Values[i] = parent.Values[i + 1];
                            parent.Nodes[i + 1] = parent.Nodes[i + 2];
                        }

                        parent.Index--;
                        succsor.Index++;

                        for (int i = 0; i < broNode.Index; i++)
                        {
                            succsor.Nodes[succsor.Index] = broNode.Nodes[i];
                            succsor.Values[succsor.Index] = broNode.Values[i];
                            if (broNode.Nodes[i]!=null)
                            {
                                broNode.Nodes[i].Parent = succsor;
                            }

                            succsor.Index++;
                        }

                        succsor.Nodes[succsor.Index] = broNode.Nodes[broNode.Index];
                        if (broNode.Nodes[broNode.Index] != null)
                        {
                            broNode.Nodes[broNode.Index].Parent = succsor;
                        }
                        broNode.Index = 0;

                        FixupNode(parent);
                    }
                }
            }
        }

        public BTreeNode NewNode()
        {
            return new BTreeNode(Node_N);
        }
    }

    public class BTreeNode
    {
        public int Index { get; set; }
        internal BTreeNode(int n)
        {
            Values = new int[n];
            Nodes = new BTreeNode[n + 1];
        }

        public int[] Values { get; private set; }
        public BTreeNode[] Nodes { get;private set; }
        public BTreeNode Parent { get; set; }
    }
}
