using ProjectCollection.Common;
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
            /*
             * 方法一;借助最小堆实现，空间复杂度O(n)
            MinHeap heap = HeapFactory.CreateMinHeap(nums);
            for(int i = 0; i < nums.Length; i++)
            {
                nums[i] = heap.PopMin();
            }
            */
            //方法二，利用最大顶堆进行原地排序，速度是方法一的一倍
            InitArray(nums);//构建最大顶堆.如果是逆序排序的话就构建最小顶堆
            SortHeap(nums);//对最大顶堆进行排序
        }

        //前提nums已经构成最小堆
        private static void SortHeap(int[] nums)
        {
            for(int i = nums.Length - 1; i > 0; i--)
            {
                //将最大值交换到末尾，然后数组长度减一，重新调整最大顶堆
                ArrayHelper.Swap(nums, 0, i);
                FloatDown(nums, 0, i - 1);
            }
        }

        private static void InitArray(int[] nums)
        {
            //初始化数组，构建最大顶堆
            for(int i = 0; i < nums.Length; i++)
            {
                FloatUp(nums, i, nums.Length - 1);
            }
        }

        /// <summary>
        /// 下沉
        /// </summary>
        /// <param name="v"></param>
        private static void FloatDown(int[] InnerArray, int index,int EndIndex)
        {
            if(index < 0 || index > EndIndex)
            {
                return;
            }

            int maxIndex = index;
            int left = 2 * index + 1;
            int right = 2 * index + 2;

            //获取左右子节点中最小的节点
            if (left <= EndIndex)
            {
                maxIndex = left;
            }
            if (right <= EndIndex && InnerArray[left] < InnerArray[right])
            {
                maxIndex = right;
            }
            //如果父节点比左右子节点都小，则停止下沉
            if (InnerArray[index] >= InnerArray[maxIndex])
            {
                return;
            }

            ArrayHelper.Swap(InnerArray, index, maxIndex);
            FloatDown(InnerArray,maxIndex,EndIndex);
        }

        /// <summary>
        /// 上浮
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private static void FloatUp(int[] InnerArray, int index, int EndIndex)
        {
            if (index < 0 || index > EndIndex)
            {
                return;
            }

            if (index == 0)
            {
                return;
            }

            int parent = (index -1)/2;
            if (InnerArray[index] > InnerArray[parent])
            {
                ArrayHelper.Swap(InnerArray, index, parent);
                FloatUp(InnerArray,parent,EndIndex);
            }
        }

    }
}
