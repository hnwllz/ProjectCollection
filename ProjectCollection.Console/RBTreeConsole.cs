using ProjectCollection.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console1 = System.Console;

namespace ProjectCollection.Console
{
    static class RBTreeConsole
    {
        public static void Run()
        {
            RBTree tree = CreateTree();
            PrintTree(tree.Root);
        }

        private static RBTree CreateTree()
        {
            RBTree tree = new RBTree();
            tree.Add(1);
            tree.Add(2);
            tree.Add(3);
            tree.Add(4);
            tree.Add(5);
            tree.Add(6);
            tree.Add(7);
            tree.Add(8);
            tree.Add(9);


            return tree;
        }

        private static void PrintTree(RBTreeNode treeNode,int deep=0)
        {
          
            if (treeNode == null)
            {
                return;
            }

            for (int i = 0; i < deep; i++) { Console1.Write("  "); }
            Console1.WriteLine(string.Format("|___{0}({1})", treeNode.Value, GetNodeColor(treeNode.Color)));
            PrintTree(treeNode.Left, 1 + deep);
            PrintTree(treeNode.Right, 1 + deep);
        }

        private static object GetNodeColor(RBTreeNodeColors color)
        {
            if(color == RBTreeNodeColors.Black)
            {
                return "黑";
            }

            return "红";
        }
    }
}
