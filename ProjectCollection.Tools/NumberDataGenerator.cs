using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCollection.Tools
{
    /// <summary>
    /// 测试数字生成器
    /// </summary>
    public class NumberDataGenerator
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }

        public string FilePath { get; set; }

        public void Generator(int count)
        {
            Random r = new Random();            
            using (StreamWriter sw = GetStringWriter())
            {
                try
                {
                    for (int i = 0; i < count; i++)
                    {
                        sw.Write(r.Next(MinValue, MaxValue));
                        sw.Write(',');
                    }
                }
                finally
                {
                    sw.Close();
                    sw.Dispose();
                }
            }
        }

        private StreamWriter GetStringWriter()
        {
            return new StreamWriter(OpenOrCreateFile(this.FilePath));
        }

        private Stream OpenOrCreateFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }

            return File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write);
        }
    }
}
