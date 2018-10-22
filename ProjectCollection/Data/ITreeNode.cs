using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCollection.Data
{
    /// <summary>
    /// 树节点
    /// </summary>
    public interface IBinaryTreeNode<T>
    {
        T Key { get; set; }

        IBinaryTreeNode<T> Parent { get; set; }
        IBinaryTreeNode<T> Left { get; set; }
        IBinaryTreeNode<T> Right { get; set; }
    }

    public class BinaryTreeNode: IBinaryTreeNode<int>
    {
        public BinaryTreeNode() { }
        public BinaryTreeNode(int value) { Key = value; }

        public int Key
        {
            get;set;
        }

        public IBinaryTreeNode<int> Left
        {
            get; set;
        }

        public IBinaryTreeNode<int> Parent
        {
            get; set;
        }

        public IBinaryTreeNode<int> Right
        {
            get; set;
        }
    }
}
