using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCollection.Data
{
    public  class HeapFactory
    {
        public static MinHeap CreateMinHeap(int[] nums)
        {
            MinHeap heap = new MinHeap(nums.Length);
            for(int i = 0; i < nums.Length; i++)
            {
                heap.Add(nums[i]);               
            }

            return heap;
        }
    }
}
