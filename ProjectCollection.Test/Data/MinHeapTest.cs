using ProjectCollection.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectCollection.Test.Data
{
    [Trait("Heap","MinHeap")]
    public class MinHeapTest
    {
        [Fact]
        public void TestEmptyHeap()
        {
            MinHeap heap = new MinHeap(0);
            Assert.True(heap.IsEmpty);
            Assert.True(heap.IsFull);
            Assert.Throws<HeapEmptyException>(() => heap.GetRoot());
            Assert.Throws<HeapEmptyException>(() => heap.PopRoot());
            Assert.Throws<HeapException>(() => heap.Add(1));
        }

        [Theory]
        [InlineData(new int[] { 1, 9, 10, 8, 7 }, 1)]
        [InlineData(new int[] { 10, 9, 1, 8, 7 }, 1)]
        [InlineData(new int[] { 10, 9, 7, 8, 1 }, 1)]
        public void TestNonEmptyHeap(int[] nums,int minValue)
        {
            BaseHeap heap = HeapHelper.CreateMinHeap(nums);

            Assert.False(heap.IsEmpty);
            Assert.True(heap.IsFull);
            Assert.True(heap.IsHeap());
            Assert.Equal(minValue, heap.GetRoot());
            Assert.Equal(minValue, heap.PopRoot());
        }
    }
}
