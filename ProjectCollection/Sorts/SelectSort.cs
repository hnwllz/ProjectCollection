using ProjectCollection.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCollection.Sorts
{
    /// <summary>
    /// 选择排序
    /// </summary>
    public class SelectSort:ISortable
    {
        public void Sort(int[] nums)
        {
            if(nums == null || nums.Length < 2)
            {
                return;
            }
            
            
            for(int index = 0; index < nums.Length; index++)
            {
                int minIndex = index;
                for(int j = index + 1; j < nums.Length; j++)
                {
                    if (nums[j] < nums[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if(index != minIndex)
                {
                    ArrayHelper.Swap(nums, index, minIndex);
                }
            }
        }
    }
}
