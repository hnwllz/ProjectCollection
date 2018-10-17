using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCollection.Sorts;
using Xunit;

namespace ProjectCollection.Test.Sorts
{
    [Xunit.Trait("Sort","InsertSort")]
    public class InsertSortTest : SortTest
    {
        public InsertSortTest() : base(new InsertSort())
        {
        }
    }
}
