using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCollection.Data
{
    public abstract class BaseHeap:IHeap
    {
        public int Capacity { get; private set; }
        protected int[] InnerArray { get; set; }
        protected int EndIndex { get; set; }

        public bool IsEmpty
        {
            get
            {
                return EndIndex == -1;
            }
        }

        public bool IsFull
        {
            get
            {
                return this.Capacity - 1 == EndIndex;
            }
        }

        public BaseHeap(int capacity)
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

        public int GetRoot()
        {
            if (IsEmpty)
            {
                throw new HeapEmptyException();
            }

            return InnerArray[0];
        }

        public void RemoveRoot()
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

        public int PopRoot()
        {
            int value = GetRoot();
            RemoveRoot();
            return value;
        }

        /// <summary>
        /// 下沉
        /// </summary>
        /// <param name="v"></param>
        protected abstract void FloatDown(int index);

        protected int GetLeftChild(int index)
        {
            return index * 2 + 1;
        }

        protected int GetRightChild(int index)
        {
            return index * 2 + 2;
        }

        /// <summary>
        /// 上浮
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected abstract void FloatUp(int index);

        protected int GetParent(int index)
        {
            if (index == 0)
            {
                return 0;
            }

            return (index - 1) / 2;
        }

        protected bool ValidateIndex(int index)
        {
            if (index < 0 || index > EndIndex)
            {
                throw new HeapOutOfIndexException();
            }

            return true;
        }

        public abstract bool IsHeap();
    }


    public class HeapException : Exception
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
