using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCollection.QuestionLibrary
{
    public class SimpleCalcutor
    {
        public int Calculate(string s)
        {
            if (s == null || s.Length < 1)
            {
                return 0;
            }

            Stack<int> nums = new Stack<int>();
            Stack<char> opers = new Stack<char>();

            int index = 0;
            char c;
            int operNum = 0;
            char oper = ' ';
            while (index < s.Length)
            {
                c = s[index++];
                if (c == '(')
                {
                    if (oper == ' ')
                    {
                        nums.Push(0);
                        opers.Push('+');
                    }
                    else
                    {
                        nums.Push(operNum);
                        opers.Push(oper);
                        oper = ' ';
                        operNum = 0;
                    }
                }
                else if (c == ')')
                {
                    operNum = Oper(nums.Pop(), operNum, opers.Pop());
                }
                else if (c == '+' || c == '-')
                {
                    oper = c;
                }
                else if ('0' <= c && c <= '9')
                {
                    string strNum = "";
                    strNum += c;
                    while (index < s.Length && '0' <= s[index] && s[index] <= '9')
                    {
                        strNum += s[index++];
                    }

                    int num = int.Parse(strNum);
                    if (oper == ' ')
                    {
                        operNum = num;
                    }
                    else
                    {
                        operNum = Oper(operNum, num, oper);
                        oper = ' ';
                    }
                }
                else if (c == ' ')
                {
                    continue;
                }
                else
                {
                    throw new Exception("非法字符:" + c);
                }
            }

            return operNum;
        }

        private int Oper(int a, int b, char c)
        {
            if (c == '+')
            {
                return a + b;
            }
            else if (c == '-')
            {
                return a - b;
            }
            else
            {
                return 0;
            }
        }
    }

}
