//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.Benchmark;
using nanoFramework.Benchmark.Attributes;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace nanoFramework.System.Text.RegularExpression.Benchmark
{
    [DebugLogger]
    [ConsoleParser]
    [IterationCount(100)]
    public class RegexReplaceBenchmark
    {
        private readonly string _input;
        private readonly string _input10x;
        private readonly Regex _regex;

        public RegexReplaceBenchmark()
        {
            Debug.WriteLine($"\n\nStarting {this.GetType().Name}...");

            _input = "This is a test. ";
            var builder = new StringBuilder();
            for (var j = 0; j < 10; j++)
            {
                builder.Append(_input);
            }
            _input10x = builder.ToString();

            _regex = new Regex("test");
        }


        [Benchmark]
        public void Regex_Replace()
        {
            _ = _regex.Replace(_input, "replacement");
        }

        [Benchmark]
        public void Regex_Replace_LargerInput()
        {
            _ = _regex.Replace(_input10x, "replacement");
        }

        [Benchmark]
        public void Regex_Replace_LargerInput_MaxOccurrences1()
        {
            _ = _regex.Replace(_input10x, "replacement", 1, 0);
        }

        [Benchmark]
        public void Regex_Replace_LargerInput_MaxOccurrences5()
        {
            _ = _regex.Replace(_input10x, "replacement", 5, 0);
        }
    }
}
