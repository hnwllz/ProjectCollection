using ProjectCollection.QuestionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectCollection.Test.QuestionLibrary
{
    [Trait("LeetCode","224.基本计算器")]
    public class SimpleCalcutorTest
    {
        [Theory]
        [InlineData("1+1",2)]
        [InlineData("(1+1)+1",3)]
        [InlineData("(1+(1+1))",3)]
        [InlineData("(1+1)+(1+1)",4)]
        [InlineData("(1+1)-(1-1)", 2)]
        public void TestAdd(string strExp,int expectedValue)
        {
            SimpleCalcutor calc = new SimpleCalcutor();
            Assert.Equal(expectedValue, calc.Calculate(strExp));
        }
    }
}
