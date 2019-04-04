// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Reflection;
using BenchmarkDotNet.Attributes;
using MicroBenchmarks;

namespace Mono
{
    [BenchmarkCategory(Categories.Mono)]
    public class Ctor
    {
        private CtorTestClass _Instance = new CtorTestClass();
        private ConstructorInfo _CtorInfo = typeof(CtorTestClass).GetConstructor(Type.EmptyTypes);

        [Benchmark]
        public object NewOperator()
        {
            return new CtorTestClass();
        }

        [Benchmark]
        public object Clone()
        {
            return _Instance.Clone();
        }

        [Benchmark]
        public object ActivatorCreateInstance()
        {
            return Activator.CreateInstance(typeof(CtorTestClass));
        }

        [Benchmark]
        public object CtorViaReflection()
        {
            return _CtorInfo.Invoke(null);
        }
    }

    public class CtorTestClass
    {
        public CtorTestClass()
        {
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
