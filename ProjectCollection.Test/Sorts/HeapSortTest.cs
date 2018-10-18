using ProjectCollection.Sorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCollection.Test.Sorts
{
    [Xunit.Trait("Sort", "HeapSort")]
    public class HeapSortTest:SortTest
    {       
        public HeapSortTest():base(new HeapSort())
        {
        }
    }
}
