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
    public class RegexMatchBenchmark : RegexBenchmarkBase
    {
        public override object MethodToBenchmark(string input, string pattern, RegexOptions options = default)
        {
            if (options != default(RegexOptions))
            {
                return Regex.Match(input, pattern);
            }
            else
            {
                return Regex.Match(input, pattern, options);
            }
        }
    }

    [DebugLogger]
    [ConsoleParser]
    [IterationCount(100)]
    public class RegexMatchesBenchmark : RegexBenchmarkBase
    {
        public override object MethodToBenchmark(string input, string pattern, RegexOptions options = default)
        {
            if (options != default(RegexOptions))
            {
                return Regex.Matches(input, pattern);
            }
            else
            {
                return Regex.Matches(input, pattern, options);
            }
        }
    }


    public abstract class RegexBenchmarkBase
    {
        private readonly string _input;
        private readonly string _input1000x;

        public RegexBenchmarkBase()
        {
            Debug.WriteLine($"\n\nStarting {this.GetType().Name}...");

            _input = "This is a test. ";
            var builder = new StringBuilder();
            for (var j = 0; j < 1000; j++)
            {
                builder.Append(_input);
            }
            _input1000x = builder.ToString();
        }

        public abstract object MethodToBenchmark(string input, string pattern, RegexOptions options = default);

        [Benchmark]
        public void Regex_Match()
        {
            _ = MethodToBenchmark(_input, "test");
        }

        [Benchmark]
        public void Regex_Match_LargerInput()
        {
            _ = MethodToBenchmark(_input1000x, "test");
        }

        [Benchmark]
        public void Regex_Match_LongerPattern()
        {
            _ = MethodToBenchmark(_input, "This is a test");
        }

        [Benchmark]
        public void Regex_Match_ShorterPattern()
        {
            _ = MethodToBenchmark(_input, "s");
        }

        [Benchmark]
        public void Regex_Match_100xInput_WhitespaceInPattern()
        {
            _ = MethodToBenchmark(_input, @"\sa\s");
        }

        [Benchmark]
        public void Regex_Match_100xInput_WordInPattern()
        {
            _ = MethodToBenchmark(_input, @"\w");
        }

        [Benchmark]
        public void Regex_Match_100xInput_WildcardInPattern()
        {
            _ = MethodToBenchmark(_input, @".s");
        }

        [Benchmark]
        public void Regex_Match_IgnoreCase()
        {
            _ = MethodToBenchmark(_input, "Test", RegexOptions.IgnoreCase);
        }

        [Benchmark]
        public void Regex_Match_Multiline()
        {
            _ = MethodToBenchmark(_input, "Test", RegexOptions.Multiline);
        }

        [Benchmark]
        public void Regex_Match_IgnorePatternWhitespace()
        {
            _ = MethodToBenchmark(_input, "Test", RegexOptions.IgnorePatternWhitespace);
        }
    }
}
