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
    public class MinHeap : IHeap
    {
        public int Capacity { get; private set; }
        private int[] InnerArray { get; set; }
        private int EndIndex { get; set; }

        private bool IsEmpty
        {
            get
            {
                return EndIndex == -1;
            }
        }

        private bool IsFull
        {
            get
            {
                return this.Capacity - 1 == EndIndex;
            }
        }

        public MinHeap(int capacity)
        {
            this.Capacity = capacity;
            this.EndIndex = -1;
            InnerArray = new int[capacity];
        }

        public void Add(int value)
        {
            if (IsFull)
            {
                throw new HeapException("堆已经满了");
            }

            InnerArray[++EndIndex] = value;
            FloatUp(EndIndex);
        }

        public int GetMin()
        {
            if (IsEmpty)
            {
                throw new HeapEmptyException();
            }

            return InnerArray[0];
        }

        public void RemoveMin()
        {
            if (IsEmpty)
            {
                return;
            }

            InnerArray[0] = InnerArray[EndIndex];
            InnerArray[EndIndex] = 0;
            EndIndex--;
            if (!IsEmpty)
            {
                FloatDown(0);
            }
        }

        public int PopMin()
        {
            int value = GetMin();
            RemoveMin();
            return value;
        }

        /// <summary>
        /// 下沉
        /// </summary>
        /// <param name="v"></param>
        private void FloatDown(int index)
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

        private int GetLeftChild(int index)
        {
            return index * 2 + 1; 
        }

        private int GetRightChild(int index)
        {
            return index * 2 + 2;
        }

        /// <summary>
        /// 上浮
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private void FloatUp(int index)
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

        private int GetParent(int index)
        {
            if(index == 0)
            {
                return 0;
            }

            return (index - 1) / 2;
        }

        private bool ValidateIndex(int index)
        {
            if(index<0 || index> EndIndex)
            {
                throw new HeapOutOfIndexException();
            }

            return true;
        }
        
    }

    public class HeapException:Exception
    {
        public HeapException(string msg) : base(msg)
        {
        }
    }

    public class HeapEmptyException : Exception
    {
        public HeapEmptyException() : base("最小顶堆为空或容量为0") { }
    }

    public class HeapOutOfIndexException : Exception
    {
        public HeapOutOfIndexException() : base("索引值不在范围内") { }
    }

    public interface IHeap
    {
    }
}
