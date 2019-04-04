// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using MicroBenchmarks;

namespace Mono
{
    [BenchmarkCategory(Categories.Mono)]
    public class Commute
    {
        [Benchmark]
        public void CommuteTest()
        {
            int a = 0;
    
            for (int i = 0; i < 50000; i++)
            {
			    a = 
    				(((((a + 1) - 2) + 3) - 4 + 5 - 6 + 7) +
    				(((((a + 1) - 2) + 3) - 4 + 5 - 6 + 7) +
    				(((((a + 1) - 2) + 3) - 4 + 5 - 6 + 7) +
    				(((((a + 1) - 2) + 3) - 4 + 5 - 6 + 7) +
    				(((((a + 1) - 2) + 3) - 4 + 5 - 6 + 7) +
    				(((((a + 1) - 2) + 3) - 4 + 5 - 6 + 7) +
    				(((((a + 1) - 2) + 3) - 4 + 5 - 6 + 7) +
    				(((((a + 1) - 2) + 3) - 4 + 5 - 6 + 7) +
    				(((((a + 1) - 2) + 3) - 4 + 5 - 6 + 7) +
    				(((((a + 1) - 2) + 3) - 4 + 5 - 6 + 7) +
    				(((((a + 1) - 2) + 3) - 4 + 5 - 6 + 7) +
    				(((((a + 1) - 2) + 3) - 4 + 5 - 6 + 7) +
    				(((((a + 1) - 2) + 3) - 4 + 5 - 6 + 7) +
    				(((((a + 1) - 2) + 3) - 4 + 5 - 6 + 7) +
    				(((((a + 1) - 2) + 3) - 4 + 5 - 6 + 7) +
    				(((((a + 1) - 2) + 3) - 4 + 5 - 6 + 7) +
    				(((((a + 1) - 2) + 3) - 4 + 5 - 6 + 7) +
    				(((((a + 1) - 2) + 3) - 4 + 5 - 6 + 7)))))))))))))))))));
	    	}

            // TODO: Does this actually prevent the JIT from optimizing this away?
            Report(a);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Report(int a)
        {
        }
    }
}
