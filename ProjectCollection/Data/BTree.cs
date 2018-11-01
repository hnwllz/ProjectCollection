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

        public BTreeNode Find(int val)
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

        public void Remove(int val)
        {

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
