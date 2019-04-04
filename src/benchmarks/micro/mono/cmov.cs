// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using MicroBenchmarks;

namespace Mono
{
    [BenchmarkCategory(Categories.Mono)]
    public class CMov 
    {
        [Benchmark]
        public void CMov1()
        {
       		int y = 0;
		    int z = 1;

    		for (int i=0; i<50000; i++)
            {
    			if (y == 0) 
    				z = i;
			
    			if (y == 4)
    				y = i;
			
    			if (z == 0)
    				y = 1;
			
    			if (y == 1)
    				z = i;
			
    			if (y == 1)
	    			y = i;
			
		    	if (z == 2)
			    	y = z;
    			else
	    			y = i;
		    }

            // Make sure the JIT doesn't optimize the loop away.
            Report(y, z);
        }

        [Benchmark]
        public void CMov2()
        {
            int a = 1, b = 2, c = 3, d = 4, e = 5;
    		for (int i=0; i<50000; i++)
            {
    			// on the stack
    			if (a == b)
    				a = i;
    			if (b == a)
    				b = i;
    			if (c == d)
    				c = i;
    			if (d == e)
    				d = i;
    			if (e == a)
    				e = i;
	    	}
		
            // Make sure the JIT doesn't optimize the loop away.
		    Report(a, b, c, d, e);
        }

        [Benchmark]
        public void CMov3()
        {
            int a = 0, b = 0, c = 0, d = 0, e = 0;
    		for (int i = 0; i < 50000; i ++)
            {
    			a = b == 10 ?  1 :  1;
    			b = b >  1  ?  9 :  8;
    			c = b <= c  ?  1 :  2;
    			d = d >  0  ?  1 :  0;
    			e = e == 0  ? -1 :  0;
	    	}
            
            // Make sure the JIT doesn't optimize the loop away.
            Report(a, b, c, d, e);
        }

        [Benchmark]
        public void CMov4()
        {
            int a = 0, b = 0, c = 0, d = 0, e = 0;
    		for (int i = 0; i < 50000; i ++)
            {
    			// sgn (x)
    			if (a == 0)
    				a = 0;
    			else if (a < 0)
    				a = -1;
    			else
    				a = 1;
			
    			// cond incr
    			if (a <= 0)
    				a ++;
			
    			// buffer ring
    			if (b == 49)
    				b = 0;
    			else
    				b ++;
			
    			// max
    			c = a > b ? a : b;
			
    			// abs
    			d = a > 0 ? a : -a;
	    	}

            // Make sure the JIT doesn't optimize the loop away.
            Report(a, b, c, d, e);
        }

        [Benchmark]
        public void CMov5()
        {
            int a = 1, b = 2, c = 3, d = 4, e = 5;
    		for (int i = 0; i < 50000; i ++)
            {
    			// on the stack
    			a = e == 1 ? b : c;
    			b = a == 1 ? c : d;
	    		c = b == 1 ? d : e;
    			d = c == 1 ? e : a;
    			e = d == 1 ? a : b;
    		}

            // Make sure the JIT doesn't optimize the loop away.
            Report(a, b, c, d, e);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Report(int a, int b = 0, int c = 0, int d = 0, int e = 0)
        {
        }
    }
}
