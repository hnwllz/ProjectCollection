using ProjectCollection.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectCollection.Test.Data.Tree
{
    [Trait("Tree","BinarySearchTree")]
    public class BSTTest
    {
        [Theory]
        [InlineData(new int[] { 2, 7, 3, 0, 3, 2 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6 })]
        [InlineData(new int[] { 6, 5, 4, 3, 2, 1 })]
        public void TestInitBST(int[] nums)
        {
            BinarySearchTree bst = new BinarySearchTree();
            foreach(int num in nums)
            {
                bst.Add(num);
            }

            Assert.True(ArrayHelper.IsSorted(bst.PreOrder()));
        }

        [Theory]
        [InlineData(new int[] { 2, 7, 3, 0, 3, 2 }, new int[] { 2, 0 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 2, 0, 4 })]
        [InlineData(new int[] { 6, 5, 4, 3, 2, 1 }, new int[] { 2, 4, 1 })]
        public void TestBSTAfterRemoved(int[] nums,int[] rmNums)
        {
            BinarySearchTree bst = new BinarySearchTree();
            foreach (int num in nums)
            {
                bst.Add(num);
            }

            foreach(int num in rmNums)
            {
                bst.Remove(num);
            }

            Assert.True(ArrayHelper.IsSorted(bst.PreOrder()));
        }

        [Theory]
        [InlineData(new int[] { 2, 7, 3, 0, 3, 2 }, 7)]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6 }, 3)]
        [InlineData(new int[] { 6, 5, 4, 3, 2, 1 }, 3)]
        public void TestRemoveBST2(int[] nums, int rmNum)
        {
            BinarySearchTree bst = new BinarySearchTree();
            foreach (int num in nums)
            {
                bst.Add(num);
            }

            bst.Remove(rmNum);
            Assert.False(bst.Exists(rmNum));
        }
    }
}
