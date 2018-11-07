using ProjectCollection.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console1 = System.Console;

namespace ProjectCollection.Console
{
    static class BtreeConsole
    {
        public static void Run()
        {
            TimeSpendTest();
            //SimpleTest();
        }

        private static void TimeSpendTest()
        {
            BTree tree = new BTree(10);
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
            BTree tree = CreateTree();
            PrintTree(tree.Root);

            string input;
            int value;
            //do
            //{

            //    Console1.Write("Input Add Value:");
            //    input = Console1.ReadLine();
            //    if (input.Trim().Equals("", StringComparison.OrdinalIgnoreCase))
            //    {
            //        break;
            //    }

            //    if (int.TryParse(input, out value))
            //    {
            //        tree.Add(value);
            //        PrintTree(tree.Root);
            //    }
            //}
            //while (true);

            do
            {

                Console1.Write("Input Remove Value:");
                input = Console1.ReadLine();
                if (input.Trim().Equals("", StringComparison.OrdinalIgnoreCase))
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

        private static BTree CreateTree()
        {
            BTree tree = new BTree(5);
            for (int i = 20; i > 0; i--)
            {
                tree.Add(i);
            }

            return tree;
        }

        private static void PrintTree(BTreeNode treeNode,int deep=0)
        {
          
            if (treeNode == null)
            {
                return;
            }

            for (int i = 0; i < deep; i++) { Console1.Write("  "); }

            Console1.Write("|___");
            for (int j = 0; j < treeNode.Index; j++)
            {
                Console1.Write("{0},", treeNode.Values[j]);                
            }
            Console1.WriteLine("") ;

            for (int j = 0; j < treeNode.Index+1; j++)
            {
                PrintTree(treeNode.Nodes[j], 1 + deep);
            }
        }
    }
}
