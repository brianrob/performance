// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using MicroBenchmarks;

namespace Mono
{
    [BenchmarkCategory(Categories.Mono)]
    public class ContextBoundObject
    {
        private TestClass _Instance = new TestClass();

        [Benchmark]
        public void Equals()
        {
            for(int i=0; i<50000; i++)
            {
                if(!_Instance.Equals(_Instance))
                {
                    Report(!_Instance.Equals(_Instance));
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Report(bool b)
        {
        }
    }

    public class TestClass : System.ContextBoundObject
    {
    }
}
