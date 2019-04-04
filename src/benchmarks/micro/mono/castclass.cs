// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using BenchmarkDotNet.Attributes;
using MicroBenchmarks;

namespace Mono
{
    [BenchmarkCategory(Categories.Mono)]
    public class CastClass
    {
        private static bool _Result = false;
        private int _Instance = 1;

        public void SetInstance(int val)
        {
            _Instance = val;
        }

        public bool GetResult()
        {
            return _Result;
        }

        [Benchmark]
        public void CastClassTest()
        {
            object o = new CastClass();

            for(int i=0; i<100000; i++)
            {
                if(((CastClass)o)._Instance != 1)
                    _Result = true;
            }
        }
    }
}
