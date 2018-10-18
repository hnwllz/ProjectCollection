using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCollection.Sorts
{
    /// <summary>
    /// 合并排序
    /// </summary>
    public class CombineSort : ISortable
    {
        public void Sort(int[] nums)
        {
            if(nums == null || nums.Length < 2)
            {
                return;
            }

            PartSort(nums,0,nums.Length-1);
        }

        private void PartSort(int[] nums, int start, int end)
        {
            if(start == end)
            {
                return;
            }
            int mid = (start + end) / 2;
            PartSort(nums, start, mid);
            PartSort(nums, mid+1, end);
            CombineSortedArrays(nums,start,mid,end);
        }

        private void CombineSortedArrays(int[] nums, int start, int mid, int end)
        {
            //排序的时候需要借助临时空间
            int[] temp = new int[end-start+1];
            int left = start;
            int right = mid + 1;
            int index = 0;
            while(left<=mid || right <= end)
            {
                int lv = int.MaxValue, rv = int.MaxValue;
                if (left <= mid)
                {
                    lv = nums[left];
                }
                if(right <= end)
                {
                    rv = nums[right];
                }

                if(lv < rv)
                {
                    temp[index] = lv;
                    index++;left++;
                }
                else
                {
                    temp[index] = rv;
                    index++;right++;
                }
            }

            for(int i = 0; i < temp.Length; i++)
            {
                nums[i + start] = temp[i];
            }

            temp = null;
        }
    }
}
