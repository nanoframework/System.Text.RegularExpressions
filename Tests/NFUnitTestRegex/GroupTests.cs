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
    public class GroupTests
    {
        [TestMethod]
        public void RegExpTest_6_Group_Test_0()
        {
            // The example displays the following output:
            //       Match: This is one sentence.
            //          Group 1: 'This is one sentence.'
            //             Capture 1: 'This is one sentence.'
            //          Group 2: 'sentence'
            //             Capture 1: 'This '
            //             Capture 2: 'is '
            //             Capture 3: 'one '
            //             Capture 4: 'sentence'
            //          Group 3: 'sentence'
            //             Capture 1: 'This'
            //             Capture 2: 'is'
            //             Capture 3: 'one'
            //             Capture 4: 'sentence'
            string pattern = @"(\b(\w+?)[,:;]?\s?)+[?.!]";
            string input = "This is one sentence. This is a second sentence.";

            Match match = Regex.Match(input, pattern);
            Debug.WriteLine("Match: " + match.Value);
            int groupCtr = 0;
            foreach (Group group in match.Groups)
            {
                groupCtr++;
                Debug.WriteLine("   Group " + groupCtr + ": '" + group.Value + "'");
                int captureCtr = 0;
                foreach (Capture capture in group.Captures)
                {
                    captureCtr++;
                    Debug.WriteLine("      Capture " + captureCtr + ": '" + capture.Value + "'");
                }
            }

            Assert.Equal(match.Groups.Count, 3);
            Assert.Equal(match.Groups[0].ToString(), "This is one sentence.");
            Assert.Equal(match.Groups[1].ToString(), "sentence");
            Assert.Equal(match.Groups[2].ToString(), "sentence");
        }

        [TestMethod]
        public void RegExpTest_6_Group_Test_1_GroupCollection()
        {
            // The example displays the following output:
            //       ®: Microsoft
            //       ®: Excel
            //       ®: Access
            //       ®: Outlook
            //       ®: PowerPoint
            //       ™: Silverlight
            // Found 6 trademarks or registered trademarks.
            int expectedCount = 6;

            string pattern = @"\b(\w+?)([®™])";
            string input = "Microsoft® Office Professional Edition combines several office " +
                           "productivity products, including Word, Excel®, Access®, Outlook®, " +
                           "PowerPoint®, and several others. Some guidelines for creating " +
                           "corporate documents using these productivity tools are available " +
                           "from the documents created using Silverlight™ on the corporate " +
                           "intranet site.";
            Regex test = new Regex(pattern);
            MatchCollection matches = test.Matches(input);
            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                Debug.WriteLine(groups[2] + ": " + groups[1]);
            }

            Debug.WriteLine("Found " + matches.Count + " trademarks or registered trademarks.");

            Assert.Equal(matches.Count, expectedCount);
            Assert.Equal(matches[0].ToString(), "Microsoft®");
            Assert.Equal(matches[1].ToString(), "Excel®");
            Assert.Equal(matches[2].ToString(), "Access®");
            Assert.Equal(matches[3].ToString(), "Outlook®");
            Assert.Equal(matches[4].ToString(), "PowerPoint®");
            Assert.Equal(matches[5].ToString(), "Silverlight™");
        }
    }
}