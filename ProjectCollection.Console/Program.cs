using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCollection.Tools;
using Console1 = System.Console;
using ProjectCollection.Data;

namespace ProjectCollection.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            // GenerateNums();

            //AVLTreeShow();
            //Console1.WriteLine("-------------红黑树------------");
            //RBTreeConsole.Run();
            //Console1.WriteLine("-------------平衡树------------");
            //AVLTreeConsole.Run();
            //Console1.WriteLine("-------------搜索树------------");
            //BSTTreeConsole.Run();
            BtreeConsole.Run();
            Console1.ReadKey();
        }

        static void GenerateNums()
        {
            string director = "../../../ProjectCollection.Test/Data";
            int countOfnums = 10;
            while (countOfnums <= Math.Pow(10, 7))
            {
                System.Console.WriteLine("生成数量{0}的文件",countOfnums);
                NumberDataGenerator gen = new NumberDataGenerator();
                gen.MinValue = -countOfnums;
                gen.MaxValue = countOfnums;
                gen.FilePath = Path.Combine(director, string.Format("nums{0}.txt", countOfnums));
                gen.Generator(countOfnums);

                countOfnums *= 10;
            }

            System.Console.WriteLine("生成完成");
        }

        static void AVLTreeShow()
        {
            AVLTree tree = new AVLTree();
            tree.Add(1);
            tree.Add(2);
            tree.Add(3);
            tree.Add(4);
            tree.Add(5);
            tree.Add(6);
            PrintAVLTree(tree.Root);


            string input;
            int value;
            do
            {

                Console1.Write("Input Value:");
                input = Console1.ReadLine();
                if(input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }               

                if (int.TryParse(input, out value))
                {
                    tree.Add(value);
                    PrintAVLTree(tree.Root);
                }                
            }
            while (true);

            do
            {

                Console1.Write("Remove Value:");
                input = Console1.ReadLine();
                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                if (int.TryParse(input, out value))
                {
                    tree.Remove(value);
                    PrintAVLTree(tree.Root);
                }
            }
            while (true);

            Console1.ReadKey();
        }

        private static void PrintAVLTree(AVLTreeNode treeNode,int deep=0)
        {
            if(treeNode == null)
            {
                return;
            }
            
            for (int i = 0; i < deep; i++) { Console1.Write("  "); }
            Console1.WriteLine(string.Format("|___{0}({1})", treeNode.Value, treeNode.HighValue));
            PrintAVLTree(treeNode.Left,1+deep);            
            PrintAVLTree(treeNode.Right,1+deep);
        }
    }
}
