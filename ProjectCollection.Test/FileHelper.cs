﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCollection.Test
{
    class FileHelper
    {
        public static int[] ReadArray(string filePath)
        {
            List<int> lst = new List<int>();
            using(StreamReader sr = new StreamReader(OpenFile(filePath)))
            {
                StringBuilder strNum = new StringBuilder();
                while (!sr.EndOfStream)
                {
                    int c = sr.Read();
                    if((char)c == ','&& strNum.Length > 0)
                    {
                        lst.Add(int.Parse(strNum.ToString()));
                        strNum.Clear();
                    }
                    else
                    {
                        strNum.Append((char)c);
                    }
                }
            }

            return lst.ToArray();
        }


        public static FileStream OpenFile(string filePath)
        {
            return File.Open(filePath, FileMode.Open,FileAccess.Read);
        }
    }
}
