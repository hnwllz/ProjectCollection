using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCollection.Tools;
using Console = System.Console;

namespace ProjectCollection.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberDataGenerator gen = new NumberDataGenerator();
            gen.MinValue = -400000;
            gen.MaxValue = 400000;
            gen.FilePath = @"E:\数据\测试数据\numbers.txt";
            gen.Generator(400000);

            System.Console.WriteLine("生成完成");
        }
    }
}
