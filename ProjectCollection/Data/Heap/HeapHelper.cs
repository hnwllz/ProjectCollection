using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCollection.Data
{
    public  class HeapHelper
   { 
        public static MinHeap CreateMinHeap(int[] nums)
        {
            MinHeap heap = new MinHeap(nums.Length);
            AddRange(heap, nums);

            return heap;
        }

        public static MaxHeap CreateMaxHeap(int[] nums)
        {
            MaxHeap heap = new MaxHeap(nums.Length);
            AddRange(heap,nums);

            return heap;
        }

        public static  void AddRange(BaseHeap heap,int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                heap.Add(nums[i]);
            }
        }

        public bool IsMaxHeap(BaseHeap heap)
        {
            return (heap is MaxHeap) && heap.IsHeap();
        }

        public bool IsMinHeap(BaseHeap heap)
        {
            return (heap is MinHeap) && heap.IsHeap();
        }
    }
}
