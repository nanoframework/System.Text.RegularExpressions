//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace NFUnitTestRegex
{
    [TestClass]
    class RegexpOptionTests
    {
        [TestMethod]
        public void RegExpTest_4_RegexpOptions_Test_1_IgnoreCase()
        {
            Regex regex;
            Debug.WriteLine(" Test RegexOptions.IgnoreCase");
            regex = new Regex("abc(\\w*)");
            Debug.WriteLine("RegexOptions.IgnoreCase abc(\\w*)");
            regex.Options = RegexOptions.IgnoreCase;
            Debug.WriteLine("abc(d*)");
            Assert.True(regex.IsMatch("abcddd"));
            Debug.WriteLine("abcddd = true");
            Assert.True(regex.IsMatch("aBcDDdd"));
            Debug.WriteLine("aBcDDdd = true");
            Assert.True(regex.IsMatch("ABCDDDDD"));
            Debug.WriteLine("ABCDDDDD = true");

            regex = new Regex("(A*)b\\1");
            regex.Options = RegexOptions.IgnoreCase;
            Assert.True(regex.IsMatch("AaAaaaBAAAAAA"));
            Debug.WriteLine("AaAaaaBAAAAAA = true");

            regex = new Regex("[A-Z]*");
            regex.Options = RegexOptions.IgnoreCase;
            Assert.True(regex.IsMatch("CaBgDe12"));
            Debug.WriteLine("CaBgDe12 = true");
        }

        [TestMethod]
        public void RegExpTest_4_RegexpOptions_Test_2_EOL_BOL()
        {
            Regex regex;
            Debug.WriteLine("Test for eol/bol symbols.");
            regex = new Regex("^abc$");
            Assert.False(regex.IsMatch("\nabc"));
        }

        [TestMethod]
        public void RegExpTest_4_RegexpOptions_Test_3_MultiLine()
        {
            Regex regex;
            Debug.WriteLine("Test RE.MATCH_MULTILINE. Test for eol/bol symbols.");
            regex = new Regex("^abc$", RegexOptions.Multiline);
            Assert.True(regex.IsMatch("\nabc"));
            Assert.True(regex.IsMatch("\rabc"));
            Assert.True(regex.IsMatch("\r\nabc"));
            Assert.True(regex.IsMatch("\u0085abc"));
            Assert.True(regex.IsMatch("\u2028abc"));
            Assert.True(regex.IsMatch("\u2029abc"));

            Debug.WriteLine("Test RE.MATCH_MULTILINE. Test that '.' does not matches new line.");
            regex = new Regex("^a.*b$", RegexOptions.Multiline);
            Assert.False(regex.IsMatch("a\nb"));
            Assert.False(regex.IsMatch("a\rb"));
            Assert.False(regex.IsMatch("a\r\nb"));
            Assert.False(regex.IsMatch("a\u0085b"));
            Assert.False(regex.IsMatch("a\u2028b"));
            Assert.False(regex.IsMatch("a\u2029b"));
        }
    }
}
