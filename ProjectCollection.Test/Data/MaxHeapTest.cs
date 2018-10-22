using ProjectCollection.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectCollection.Test.Data
{
    [Trait("Heap","MaxHeap")]
    public class MaxHeapTest
    {
        [Fact]
        public void TestEmptyHeap()
        {
            MaxHeap heap = new MaxHeap(0);
            Assert.True(heap.IsEmpty);
            Assert.True(heap.IsFull);
            Assert.Throws<HeapEmptyException>(() => heap.GetRoot());
            Assert.Throws<HeapEmptyException>(() => heap.PopRoot());
            Assert.Throws<HeapException>(() => heap.Add(1));
        }

        [Theory]
        [InlineData(new int[] { 10, 9, 1, 8, 9, 7 }, 10)]
        [InlineData(new int[] { 1, 9, 10, 8, 9, 7 }, 10)]
        [InlineData(new int[] { 1, 9, 7, 8, 9, 10 }, 10)]
        public void TestNonEmptyHeap(int[] nums, int minValue)
        {
            BaseHeap heap = HeapHelper.CreateMaxHeap(nums);

            Assert.False(heap.IsEmpty);
            Assert.True(heap.IsFull);
            Assert.True(heap.IsHeap());
            Assert.Equal(minValue, heap.GetRoot());
            Assert.Equal(minValue, heap.PopRoot());
        }
    }
}
