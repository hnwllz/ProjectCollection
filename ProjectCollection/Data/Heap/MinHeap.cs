using ProjectCollection.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCollection.Data
{
    /// <summary>
    /// 最小顶堆
    /// </summary>
    public class MinHeap :BaseHeap
    { 

        public MinHeap(int capacity):base(capacity)
        {
        }

        /// <summary>
        /// 下沉
        /// </summary>
        /// <param name="v"></param>
        protected override void FloatDown(int index)
        {
            ValidateIndex(index);
            int maxIndex = index;
            int left = GetLeftChild(index);
            int right = GetRightChild(index);

            //获取左右子节点中最小的节点
            if (left <= EndIndex)
            {
                maxIndex = left;
            }
            if (right <= EndIndex && InnerArray[left] > InnerArray[right])
            {
                maxIndex = right;
            }
            //如果父节点比左右子节点都小，则停止下沉
            if (InnerArray[index] <= InnerArray[maxIndex])
            {
                return;
            }

            ArrayHelper.Swap(InnerArray, index, maxIndex);
            FloatDown(maxIndex);
        }

        /// <summary>
        /// 上浮
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected override void FloatUp(int index)
        {
            ValidateIndex(index);
            if (index == 0)
            {
                return;
            }

            int parent = GetParent(index);
            if (InnerArray[index] < InnerArray[parent])
            {
                ArrayHelper.Swap(InnerArray, index, parent);
                FloatUp(parent);
            }
        }

        public override bool IsHeap()
        {
            for(int i = 1; i <= this.EndIndex; i++)
            {
                int pIndex = GetParent(i);
                if(this.InnerArray[pIndex] > this.InnerArray[i])
                {
                    return false;
                }
            }

            return true;
        }
    }

}
