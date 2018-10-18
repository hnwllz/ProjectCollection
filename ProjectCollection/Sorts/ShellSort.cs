using ProjectCollection.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCollection.Sorts
{
    /// <summary>
    /// 希尔排序
    /// </summary>
    public class ShellSort : ISortable
    {
        public void Sort(int[] nums)
        {
            if(nums == null || nums.Length < 2)
            {
                return;
            }

            for(int gap = nums.Length/2;gap>0;gap /= 2)
            {
                for(int i = gap; i < nums.Length; i++)
                {
                    int j = i;
                    while (j >= gap)
                    {
                        if (nums[j] < nums[j - gap])
                        {
                            ArrayHelper.Swap(nums,j,j-gap);
                            j = j - gap;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
