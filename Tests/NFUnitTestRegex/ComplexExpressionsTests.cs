using nanoFramework.TestFramework;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace NFUnitTestRegex
{
    [TestClass]
    class ComplexExpressionsTests
    {
        [TestMethod]
        public void SingleEmailAddress()
        {
            Regex rx = new Regex(@"^([\w\d_.\-]+)@([\d\w\.\-]+)\.([\w\.]{2,5})$",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // Define a test string.                    
            string[] emails = new string[] { "laurelle@microsoft.com", "Anotherone@mhotmail.com", "m1@cc.cc", "bob.spoNge@tagada.tsoIn" };
            foreach (var text in emails)
            {
                var matches = rx.Matches(text);
                foreach (Match match in matches)
                {
                    Debug.WriteLine($"Email found: {match}");
                    Assert.Equal(text, match.ToString());
                }

                Assert.Equal(1, matches.Count);
            }
        }

        [TestMethod]
        public void ExtractEmailAddress()
        {
            Regex rx = new Regex(@"([\w\d_.\-]+)@([\d\w\.\-]+)\.([\w\.]{2,5})",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

            string text = "this is an email address: laurelle@microsoft.com!\r\n and Anotherone@mhotmail.com me@cc.cc bob.sponge@tagada.tsoin";

            var matches = rx.Matches(text);
            foreach (Match match in matches)
            {
                Debug.WriteLine($"Email found: {match}");
            }

            Assert.Equal(4, matches.Count);
        }

        [TestMethod]
        public void SingleHttpsAddress()
        {
            Regex rx = new Regex(@"^(https?:\/\/)([\da-z-._]+)\/?([\/\da-z.-]*)$",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // Define a test string.                    
            string[] urls = new string[] { "https://github.com/nanoFramework", "https://www1.something-123.com", "http://something/sub", "HTTPS://WWW.flkjlkf/ozrhzor/slkhdflgkh" };
            foreach (var text in urls)
            {
                var matches = rx.Matches(text);
                foreach (Match match in matches)
                {
                    Debug.WriteLine($"URL found: {match}");
                    Assert.Equal(text, match.ToString());
                }

                Assert.Equal(1, matches.Count);
            }
        }

        [TestMethod]
        public void ExtractHttpsAddress()
        {
            Regex rx = new Regex(@"(https?:\/\/)([\da-z-._]+)/?([\/\da-z.-]*)",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // Define a test string.                    
            string text = "this is an email address: laurelle@microsoft.com!\r\n and url https://github.com/nanoFramework  and there is one more https://www1.something-123.com/ and yet http another http://something/sub HTTPS://WWW.flkjlkf/ozrhzor/slkhdflgkh";
            string[] emails = new string[] { "https://github.com/nanoFramework", "https://www1.something-123.com/", "http://something/sub", "HTTPS://WWW.flkjlkf/ozrhzor/slkhdflgkh" };

            var matches = rx.Matches(text);
            int idx = 0;
            foreach (Match match in matches)
            {
                Debug.WriteLine($"URL found: {match}");
                Assert.Equal(emails[idx++], match.ToString());
            }

            Assert.Equal(4, matches.Count);
        }

        [TestMethod]
        public void MD5Test()
        {
            string pattern = @"[a-f0-9]{32}";
            string validMD5 = "36e8b0061e35a148375d0595492de11f";
            string text = $"This is a valid MD5 hash betwwen a Z and Q: Z{validMD5}Q";
            Match match = Regex.Match(text, pattern);            
            Assert.True(match.Success);
            Debug.WriteLine($"MD5 Found: {match}");
            Assert.Equal(validMD5, match.ToString());
        }

        [TestMethod]
        public void SHA256Test()
        {
            string pattern = @"[A-Fa-f0-9]{64}";
            string Sha256 = "196A8e96Eb8894811f22e7c696BB8D4BB2B57c1E0da3dA69cDC10Bc5899BaB73";
            string text = $"A valid MD5 hash will be extracted: Z{Sha256}Q";
            Match match = Regex.Match(text, pattern);            
            Assert.True(match.Success);
            Debug.WriteLine($"SHA256 Found: {match}");
            Assert.Equal(Sha256, match.ToString());
        }

        [TestMethod]
        public void SimpleXMLTest()
        {
            string pattern = @"<tag>[^<]*</tag>";
            string xml = "<tag>something here</tag>";
            string text = $"This is a valid XML tag between a Z and Q: Z{xml}Q";
            Match match = Regex.Match(text, pattern);            
            Assert.True(match.Success);
            Debug.WriteLine($"XML tag Found: {match}");
            Assert.Equal(xml, match.ToString());
        }
        
        [TestMethod]
        public void GUIDTest()
        {
            string pattern = @"[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?";
            string guid = "123e4567-e89b-12d3-a456-9AC7CBDCEE52";
            string text = $"This is a valid guid between a Z and Q: Z{guid}Q";
            Match match = Regex.Match(text, pattern);            
            Assert.True(match.Success);
            Debug.WriteLine($"GUID Found: {match}");
            Assert.Equal(guid, match.ToString());
            
            guid = "{123e4567-e89b-12d3-a456-9AC7CBDCEE52}";
            text = $"This is a valid guid tag: Z{guid}Q";
            match = Regex.Match(text, pattern);            
            Assert.True(match.Success);
            Debug.WriteLine($"GUID Found: {match}");
            Assert.Equal(guid, match.ToString());
        }        

        [TestMethod]
        public void DateTimeTest()
        {
            string pattern = @"(\d{4})-(\d{2})-(\d{2}) (\d{2}):(\d{2}):(\d{2})";
            string datetime = "2021-04-10 18:08:42";
            string text = $"A valid date time will be extracted: bla{datetime}234";
            Match match = Regex.Match(text, pattern);            
            Assert.True(match.Success);
            Debug.WriteLine($"DateTime Found: {match}");
            Assert.Equal(datetime, match.ToString());
        }
    }
}
