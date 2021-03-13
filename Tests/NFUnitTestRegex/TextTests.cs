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
    public class TextTests
    {
        [TestMethod]
        public void RegExpTest_5_Capture_Test_0()
        {
            /*
            // The example displays the following output:
            //       Match: Yes.
            //          Group 0: Yes.
            //             Capture 0: Yes.
            //          Group 1: Yes.
            //             Capture 0: Yes.
            //          Group 2: Yes
            //             Capture 0: Yes
            //       Match: This dog is very friendly.
            //          Group 0: This dog is very friendly.
            //             Capture 0: This dog is very friendly.
            //          Group 1: friendly.
            //             Capture 0: This
            //             Capture 1: dog
            //             Capture 2: is
            //             Capture 3: very
            //             Capture 4: friendly.
            //          Group 2: friendly
            //             Capture 0: This
            //             Capture 1: dog
            //             Capture 2: is
            //             Capture 3: very
            //             Capture 4: friendly
             */
            string input = "Yes. This dog is very friendly.";
            string pattern = @"((\w+)[\s.])+";
            //Regex test = new Regex(pattern);
            //string group = test.Group(0);


            MatchCollection results = Regex.Matches(input, pattern);

            foreach (Match match in results)
            {
                Debug.WriteLine("Match: " + match.Value);
                for (int groupCtr = 0; groupCtr < match.Groups.Count; groupCtr++)
                {
                    Group group = match.Groups[groupCtr];
                    Debug.WriteLine("   Group " + groupCtr + ": " + group.Value + "");
                    for (int captureCtr = 0; captureCtr < group.Captures.Count; captureCtr++)
                        Debug.WriteLine("      Capture " + captureCtr + ": " + group.Captures[captureCtr].Value);
                }
            }
            Assert.Equal(results.Count, 2);
            Assert.Equal(results[0].Groups.Count, 3);
            Assert.Equal(results[1].Groups.Count, 3);
        }

        [TestMethod]
        public void RegExpTest_5_Catpure_Test_1_CaptureCollection()
        {
            // The example displays the following output:
            //    Pattern: \b\w+\W{1,2}
            //    Match: The
            //      Match.Captures: 1
            //        0: 'The '
            //      Match.Groups: 1
            //        Group 0: 'The '
            //        Group(0).Captures: 1
            //          Capture 0: 'The '           

            int expectedCaptures = 1;
            int expectedGroups = 1;
            int Group0ExpectedCount = 1;

            string pattern;
            string input = "The young, hairy, and tall dog slowly walked across the yard.";
            Match match;

            // Match a word with a pattern that has no capturing groups.
            pattern = @"\b\w+\W{1,2}";
            match = Regex.Match(input, pattern);
            Debug.WriteLine("Pattern: " + pattern);
            Debug.WriteLine("Match: " + match.Value);
            Debug.WriteLine("  Match.Captures: " + match.Captures.Count);
            for (int ctr = 0; ctr < match.Captures.Count; ctr++) Debug.WriteLine("   " + ctr + ": '" + match.Captures[ctr].Value + "'");
            Debug.WriteLine("  Match.Groups: " + match.Groups.Count);
            for (int groupCtr = 0; groupCtr < match.Groups.Count; groupCtr++)
            {
                Debug.WriteLine("    Group " + groupCtr + ": '" + match.Groups[groupCtr].Value + "'");
                Debug.WriteLine("    Group(" + groupCtr + ").Captures: " + match.Groups[groupCtr].Captures.Count);
                for (int captureCtr = 0; captureCtr < match.Groups[groupCtr].Captures.Count; captureCtr++) Debug.WriteLine("      Capture " + captureCtr + ": '" + match.Groups[groupCtr].Captures[captureCtr].Value + "'");
            }

            //Verify Results
            Assert.Equal(match.Captures.Count, expectedCaptures);
            Assert.Equal(match.Captures[0].ToString(), "The ");
            Assert.Equal(match.Groups.Count, expectedGroups);
            Assert.Equal(match.Groups[0].Captures.Count, Group0ExpectedCount);
            Assert.Equal(match.Groups[0].ToString(), "The ");
            Assert.Equal(match.Groups[0].Captures[0].ToString(), "The ");
        }

        [TestMethod]
        public void RegExpTest_5_Catpure_Test_2_CaptureCollection()
        {
            // The example displays the following output:
            //    Pattern: (\b\w+\W{1,2})+
            //    Match: The young, hairy, and tall dog slowly walked across the yard.
            //      Match.Captures: 1
            //        0: 'The young, hairy, and tall dog slowly walked across the yard.'
            //      Match.Groups: 2
            //        Group 0: 'The young, hairy, and tall dog slowly walked across the yard.'
            //        Group(0).Captures: 1
            //          Capture 0: 'The young, hairy, and tall dog slowly walked across the yard.'
            //        Group 1: 'yard.'
            //        Group(1).Captures: 11
            //          Capture 0: 'The '
            //          Capture 1: 'young, '
            //          Capture 2: 'hairy, '
            //          Capture 3: 'and '
            //          Capture 4: 'tall '
            //          Capture 5: 'dog '
            //          Capture 6: 'slowly '
            //          Capture 7: 'walked '
            //          Capture 8: 'across '
            //          Capture 9: 'the '
            //          Capture 10: 'yard.'
            int expectedCaptures = 1;
            int expectedGroups = 1;

            string pattern;
            string input = "The young, hairy, and tall dog slowly walked across the yard.";
            Match match;

            expectedCaptures = 1;
            expectedGroups = 2;

            // Match a sentence with a pattern that has a quantifier that 
            // applies to the entire group.
            pattern = @"(\b\w+\W{1,2})+";
            match = Regex.Match(input, pattern);
            Debug.WriteLine("Pattern: " + pattern);
            Debug.WriteLine("Match: " + match.Value);
            Debug.WriteLine("  Match.Captures: " + match.Captures.Count);
            for (int ctr = 0; ctr < match.Captures.Count; ctr++) Debug.WriteLine("    " + ctr + ": '" + match.Captures[ctr].Value + "'");
            Debug.WriteLine("  Match.Groups: " + match.Groups.Count);
            for (int groupCtr = 0; groupCtr < match.Groups.Count; groupCtr++)
            {
                Debug.WriteLine("    Group " + groupCtr + ": '" + match.Groups[groupCtr].Value + "'");
                Debug.WriteLine("    Group(" + groupCtr + ").Captures: " + match.Groups[groupCtr].Captures.Count);
                for (int captureCtr = 0; captureCtr < match.Groups[groupCtr].Captures.Count; captureCtr++) Debug.WriteLine("      Capture " + captureCtr + ": '" + match.Groups[groupCtr].Captures[captureCtr].Value + "'");
            }

            //Verify Results
            Assert.Equal(match.Captures.Count, expectedCaptures);
            Assert.Equal(match.Groups.Count, expectedGroups);
            Assert.Equal(match.Groups[0].ToString(), "The young, hairy, and tall dog slowly walked across the yard.");
            Assert.Equal(match.Captures[0].ToString(), "The young, hairy, and tall dog slowly walked across the yard.");
            Assert.Equal(match.Groups[1].ToString(), "yard.");
        }
    }
}
