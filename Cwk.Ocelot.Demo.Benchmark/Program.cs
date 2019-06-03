using System;
using BenchmarkDotNet.Running;

namespace Cwk.Ocelot.Demo.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Bench>();
        }
    }
}