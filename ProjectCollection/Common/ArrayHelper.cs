using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCollection.Common
{
    public class ArrayHelper
    {
        public static void Swap(int[] nums,int i,int j)
        {
            int tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }

        public static void Reverse(int[] nums)
        {
            int left = 0;
            int right = nums.Length;
            while (left < right)
            {
                Swap(nums, left, right);
            }
        }

        public static bool IsAscSorted(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i + 1] < nums[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
