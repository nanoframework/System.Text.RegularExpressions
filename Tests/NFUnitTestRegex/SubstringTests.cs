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
    class SubstringTests
    {
        [TestMethod]
        public void RegExpTest_3_Substring_Test_0()
        {
            string expected, actual;
            Regex regex;
            string message;

            Debug.WriteLine("Test subst()");
            regex = new Regex("a*b");
            expected = "-foo-garply-wacky-";
            actual = regex.Replace("aaaabfooaaabgarplyaaabwackyb", "-");
            message = "Wrong result of substitution in\"a*b\"";
            Assert.Equal(expected, actual, message);

            Debug.WriteLine("Test subst() with backreferences");
            regex = new Regex("http://[.\\w?/~_@&=%]+");
            expected = "visit us: 1234<a href=\"http://www.apache.org\">http://www.apache.org</a>!";
            actual = regex.Replace("visit us: http://www.apache.org!", "1234<a href=\"$0\">$0</a>");
            message = "Wrong subst() result";
            Assert.Equal(expected, actual, message);

            Debug.WriteLine("Test subst() with backreferences without leading characters before first backreference");
            regex = new Regex("(.*?)=(.*)");
            expected = "variable_test_value12";
            actual = regex.Replace("variable=value", "$1_test_$212");
            message = "Wrong subst() result";
            Assert.Equal(expected, actual, message);

            Debug.WriteLine("Test subst() with NO backreferences");
            regex = new Regex("^a$");
            expected = "b";
            actual = regex.Replace("a", "b");
            message = "Wrong subst() result";
            Assert.Equal(expected, actual, message);

            Debug.WriteLine(" Test subst() with NO backreferences");
            regex = new Regex("^a$", RegexOptions.Multiline);
            expected = "\r\nb\r\n";
            actual = regex.Replace("\r\na\r\n", "b");
            Assert.Equal(expected, actual, message);

            Debug.WriteLine(" Test for Bug #36106 ");
            regex = new Regex("fo(o)");
            actual = regex.Replace("foo", "$1");
            expected = "o";
            Assert.Equal(expected, actual, message);

            Debug.WriteLine(" Test for Bug #36405 ");
            regex = new Regex("^(.*?)(x)?$");
            actual = regex.Replace("abc", "$1-$2");
            expected = "abc-";
            Assert.Equal(expected, actual, message);

            regex = new Regex("^(.*?)(x)?$");
            actual = regex.Replace("abcx", "$1-$2");
            expected = "abc-x";
            Assert.Equal(expected, actual, message);

            regex = new Regex("([a-b]+?)([c-d]+)");
            actual = regex.Replace("zzabcdzz", "$1-$2");
            expected = "zzab-cdzz";
            Assert.Equal(expected, actual, message);
        }
    }
}
