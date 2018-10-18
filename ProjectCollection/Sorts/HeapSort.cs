using ProjectCollection.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCollection.Sorts
{
    /// <summary>
    /// 堆排序
    /// </summary>
    public class HeapSort : ISortable
    {
        public void Sort(int[] nums)
        {
            if(nums == null || nums.Length < 2)
            {
                return;
            }

            MinHeap heap = HeapFactory.CreateMinHeap(nums);
            for(int i = 0; i < nums.Length; i++)
            {
                nums[i] = heap.PopMin();
            }
        }
    }
}
