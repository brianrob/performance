// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using BenchmarkDotNet.Attributes;
using MicroBenchmarks;

namespace Mono
{
    [BenchmarkCategory(Categories.Mono)]
    public class DivUn
    {
        [Benchmark]
        public int Test()
        {
            int x = 1;
    		for (int i=0; i < 100000000; ++i)
            {
                x += DoWork(12345);
            }

		    x = (int) ((uint)x / 1025);		
		    return x;
        }

        public static int DoWork(int x)
        {
    		x *= 163859;
    		x = (int) ((uint)x / 5);
    		x = (int) ((uint)x / 25);
    		x = (int) ((uint)x / 10);
    		x = (int) ((uint)x / 128);
    		x = (int) ((uint)x / 43);
    		x = (int) ((uint)x / 2);
    		x = (int) ((uint)x / 4);
    		x = (int) ((uint)x / 1);
    		return x;
	    }
    }
}
