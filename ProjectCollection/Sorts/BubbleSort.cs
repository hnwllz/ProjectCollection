using ProjectCollection.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCollection.Sorts
{
    /// <summary>
    /// 冒泡排序
    /// </summary>
    public class BubbleSort: ISortable
    {
        public void Sort(int[] nums)
        {
            if(nums == null)
            {
                return;
            }

            int l = nums.Length;
            for (int i = 0; i < l; i++)
            {
                bool isSorted = true;
                for(int j = 0; j < l - i - 1; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        ArrayHelper.Swap(nums, j, j+1);
                        isSorted = false;
                    }
                }

                if (isSorted)
                {
                    return;
                }
            }

        }
    }
}
