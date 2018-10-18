using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCollection.Tools;
using Console1 = System.Console;

namespace ProjectCollection.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            GenerateNums();
            /*
            int a = int.MinValue;
            int n = 32;
            while (n-- > 0)
            {
                a = a / 2;
            }
            Console1.WriteLine(a);
            */
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
    }
}
