// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using BenchmarkDotNet.Attributes;
using MicroBenchmarks;

namespace Mono
{
    [BenchmarkCategory(Categories.Mono)]
    public class Box
    {
        private static object X = null;

        [Benchmark]
        public void Test()
        {
            for(int i=0; i<5000000; i++)
            {
                X = i;
            }

            int j = (int)X;
        }
    }
}
