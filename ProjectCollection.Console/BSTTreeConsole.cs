using ProjectCollection.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console1 = System.Console;

namespace ProjectCollection.Console
{
    class BSTTreeConsole
    {
        public static void Run()
        {
            TimeSpendTest();
        }

        public static void TimeSpendTest()
        {
            BinarySearchTree tree = new BinarySearchTree();
            DateTime start = DateTime.Now;
            FileHelper.ReadFile(@"E:\数据\测试数据\numbers.txt", (num) => tree.Add(num));
            Console1.WriteLine("创建树耗时:" + (DateTime.Now - start).TotalMilliseconds);

            start = DateTime.Now;
            FileHelper.ReadFile(@"E:\数据\测试数据\numbers.txt", (num) => tree.Exists(num));
            Console1.WriteLine("查找树耗时:" + (DateTime.Now - start).TotalMilliseconds);

            start = DateTime.Now;
            FileHelper.ReadFile(@"E:\数据\测试数据\numbers.txt", (num) => tree.Remove(num));
            Console1.WriteLine("清空树耗时:" + (DateTime.Now - start).TotalMilliseconds);
        }
    }
}
