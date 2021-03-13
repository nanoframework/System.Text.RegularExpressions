//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace NFUnitTestRegex
{
    [TestClass]
    class SplitGrepTests
    {
        [TestMethod]
        public void RegExpTest_1_Split_Test_0()
        {
            string[] expectedResults;

            string[] acutalResults;

            Regex regex;
            expectedResults = new string[] { "xyzzy", "yyz", "123" };
            regex = new Regex("[ab]+");
            acutalResults = regex.Split("xyzzyababbayyzabbbab123");
            for (int i = 0; i < acutalResults.Length; i++)
            {
                Assert.Equal(expectedResults[i], acutalResults[i]);
            }

            expectedResults = new string[] { "xxxx", "xxxx", "yyyy", "zzz" };
            regex = new Regex("a*b");//match any amount of 'a' and 1 'b'
            acutalResults = regex.Split("xxxxaabxxxxbyyyyaaabzzz");
            for (int i = 0; i < acutalResults.Length; i++)
            {
                Assert.Equal(expectedResults[i], acutalResults[i]);
            }

            // Grep Tests
            RegExpTest_2_Grep_Test_0(ref acutalResults);

        }

        /// <summary>
        /// This test is entangled with RegExpTest_1_Split_Test_0
        /// Should the Split Logic Break the Grep Logic will break also.
        /// </summary>
        /// <param name="arg">The input to match against using grep</param>
        /// <returns></returns>
        internal void RegExpTest_2_Grep_Test_0(ref string[] arg)
        {
            string[] expectedResults;
            string[] acutalResults;

            Regex regex;

            regex = new Regex("x+");
            expectedResults = new String[] { "xxxx", "xxxx" };
            acutalResults = regex.GetMatches(arg);

            int al = acutalResults.Length;
            int el = expectedResults.Length;
            Assert.Equal(al, el); Assert.Equal(al, el);

            for (int i = 0; i < el; i++)
            {
                Debug.WriteLine("Actual[" + i + "] = " + acutalResults[i]);
                Assert.Equal(expectedResults[i], acutalResults[i]);
            }
        }
    }
}
