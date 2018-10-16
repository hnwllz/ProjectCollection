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
    public class BubbleSort
    {
        public void Sort(int[] nums)
        {
            if(nums == null)
            {
                return;
            }

            int l = nums.Length;
            for(int i = 0; i < l; i++)
            {
                bool isSorted = true;
                for(int j = i + 1; j < l; j++)
                {
                    if(nums[i] > nums[j])
                    {
                        int temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                        isSorted = false;
                    }
                }
                //如果后续没有交换，那么认为后续都是有序的
                if (isSorted)
                {
                    break;
                }
            }
            
        }
    }
}
