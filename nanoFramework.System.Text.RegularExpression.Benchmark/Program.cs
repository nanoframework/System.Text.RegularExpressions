using nanoFramework.Benchmark;
using nanoFramework.System.Text.Benchmark;
using System;
using System.Diagnostics;
using System.Threading;

namespace nanoFramework.System.Text.RegularExpression.Benchmark
{
    public class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run(typeof(IAssemblyHandler).Assembly);
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
