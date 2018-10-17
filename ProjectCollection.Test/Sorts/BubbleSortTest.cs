﻿using ProjectCollection.Sorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectCollection.Test.Sorts
{
    [Xunit.Trait("Sort", "BubbleSort")]
    public class BubbleSortTest:SortTest
    {
        public BubbleSortTest():base(new BubbleSort())
        {

        }
    }


}
