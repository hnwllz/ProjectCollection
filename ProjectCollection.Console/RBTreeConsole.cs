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
            TimeSpendTest();
        }

        private static void TimeSpendTest()
        {
            RBTree tree = new RBTree();
            DateTime start = DateTime.Now;
            FileHelper.ReadFile(@"E:\数据\测试数据\numbers.txt",(num)=>tree.Add(num));
            Console1.WriteLine("创建树耗时:"+(DateTime.Now - start).TotalMilliseconds);

            start = DateTime.Now;
            FileHelper.ReadFile(@"E:\数据\测试数据\numbers.txt", (num) => tree.FindNode(num));
            Console1.WriteLine("查找树耗时:" + (DateTime.Now - start).TotalMilliseconds);

            start = DateTime.Now;
            FileHelper.ReadFile(@"E:\数据\测试数据\numbers.txt", (num) => tree.Remove(num));
            Console1.WriteLine("清空树耗时:" + (DateTime.Now - start).TotalMilliseconds);
        }

        private static void SimpleTest()
        {
            RBTree tree = CreateTree();
            PrintTree(tree.Root);

            string input;
            int value;
            do
            {

                Console1.Write("Input Value:");
                input = Console1.ReadLine();
                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                if (int.TryParse(input, out value))
                {
                    tree.Remove(value);
                    PrintTree(tree.Root);
                }
            }
            while (true);
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
          
            if (treeNode == null || treeNode is Nil)
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
