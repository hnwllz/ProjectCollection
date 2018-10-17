using ProjectCollection.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCollection.Sorts
{
    /// <summary>
    /// 插入排序
    /// </summary>
    public class InsertSort:ISortable
    {
        public void Sort(int[] nums)
        {
            if(nums == null || nums.Length < 2)
            {
                return;
            }

            for(int i = 1; i < nums.Length; i++)
            {
                int j = i;
                while (j > 0 && nums[j]<nums[j-1])
                {
                    if (nums[j] < nums[j-1])
                    {
                        ArrayHelper.Swap(nums, j-1, j);
                        j--;
                    }
                }
            }

        }
    }
}
