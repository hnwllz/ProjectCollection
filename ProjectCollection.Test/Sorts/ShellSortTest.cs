using ProjectCollection.Sorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCollection.Test.Sorts
{
    [Xunit.Trait("Sort","ShellSort")]
    public class ShellSortTest:SortTest
    {
        public ShellSortTest():base(new ShellSort()) { }
    }
}
