using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCollection.Sorts;

namespace ProjectCollection.Test.Sorts
{

    [Xunit.Trait("Sort", "QuiklySort")]
    public class QuiklySortTest : SortTest
    {
        public QuiklySortTest() : base(new QuiklySort())
        {
        }
    }
}
