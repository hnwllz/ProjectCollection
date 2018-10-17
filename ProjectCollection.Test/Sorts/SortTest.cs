using ProjectCollection.Sorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectCollection.Test.Sorts
{
    public abstract class SortTest
    {
        public ISortable Sort { get; private set; }

        public SortTest(ISortable sort)
        {
            this.Sort = sort;
        }

        [Fact]
        public void TestNullNums()
        {
            Sort.Sort(null);
        }

        [Fact]
        public void TestEmptyNums()
        {
            Sort.Sort(new int[0]);
        }

        [Theory]
        [InlineData(new int[] { 3, 2, 1 })]
        [InlineData(new int[] { 1, 2, 1 })]
        [InlineData(new int[] { 10, 2, 21, 1, 3, 2, 0, 38, 28, 81 })]
        public void TestNums(int[] nums)
        {
            Sort.Sort(nums);            
            Assert.True(ArrayHelper.IsSorted(nums));
        }

        
        [Theory]
        [InlineData(@"E:\数据\测试数据\numbers.txt")]
        public void TestNumsFromFile(string filePath)
        {
            int[] nums = FileHelper.ReadArray(filePath);

            DateTime start = DateTime.Now;
            Sort.Sort(nums);
            Console.WriteLine("耗时：" + (DateTime.Now - start).TotalMilliseconds);
            Assert.True(ArrayHelper.IsSorted(nums));
        }
    }
}
