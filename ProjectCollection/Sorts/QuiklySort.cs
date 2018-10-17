using ProjectCollection.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCollection.Sorts
{
    /// <summary>
    /// 快速排序
    /// </summary>
    public class QuiklySort : ISortable
    {
        public void Sort(int[] nums)
        {
            if (nums == null || nums.Length < 2)
                return;

            QuiklySortCore(nums, 0, nums.Length-1);
        }

        private void QuiklySortCore(int[] nums,int start,int end)
        {
            if(start >= end)
            {
                return;
            }

            int left = start;
            int right = end;
            while (right > left)
            {
                while (left < right && nums[right] >= nums[start])
                {
                    right--;
                }
                while (left<right && nums[left] <= nums[start])
                {
                    left++;
                }                

                if (left != right)
                {
                    ArrayHelper.Swap(nums, left, right);
                }
            }

            ArrayHelper.Swap(nums, start, left);
            QuiklySortCore(nums, start, left - 1);
            QuiklySortCore(nums, left + 1, end);
        }
    }
}
