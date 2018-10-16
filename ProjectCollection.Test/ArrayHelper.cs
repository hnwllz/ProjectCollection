using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCollection.Test
{    class ArrayHelper
    {
        public static bool IsSorted(int[] nums)
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
