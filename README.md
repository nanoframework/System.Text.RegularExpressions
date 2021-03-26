[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=nanoframework_lib-nanoFramework.System.Text.RegularExpressions&metric=alert_status)](https://sonarcloud.io/dashboard?id=nanoframework_lib-nanoFramework.System.Text.RegularExpressions) [![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=nanoframework_lib-nanoFramework.System.Text.RegularExpressions&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=nanoframework_lib-nanoFramework.System.Text.RegularExpressions) [![License](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE) [![NuGet](https://img.shields.io/nuget/dt/nanoFramework.System.Text.RegularExpressions.svg?label=NuGet&style=flat&logo=nuget)](https://www.nuget.org/packages/nanoFramework.System.Text/) [![#yourfirstpr](https://img.shields.io/badge/first--timers--only-friendly-blue.svg)](https://github.com/nanoframework/Home/blob/master/CONTRIBUTING.md)
[![Discord](https://img.shields.io/discord/478725473862549535.svg?logo=discord&logoColor=white&label=Discord&color=7289DA)](https://discord.gg/gCyBu8T)

![nanoFramework logo](https://github.com/nanoframework/Home/blob/master/resources/logo/nanoFramework-repo-logo.png)

-----

### Welcome to the **nanoFramework** System.Text.RegularExpressions repository!

## Build status

| Component | Build Status | NuGet Package |
|:-|---|---|
| System.Text.RegularExpressions | [![Build Status](https://dev.azure.com/nanoframework/System.Text.RegularExpressions/_apis/build/status/System.Text.RegularExpressions?repoName=nanoframework%2Flib-nanoFramework.System.Text.RegularExpressions&branchName=main)](https://dev.azure.com/nanoframework/System.Text.RegularExpressions/_build/latest?definitionId=69&repoName=nanoframework%2Flib-nanoFramework.System.Text.RegularExpressions&branchName=main) | [![NuGet](https://img.shields.io/nuget/v/nanoFramework.System.Text.RegularExpressions.svg?label=NuGet&style=flat&logo=nuget)](https://www.nuget.org/packages/nanoFramework.System.Text.RegularExpressions/)  |
| System.Text.RegularExpressions (preview) | [![Build Status](https://dev.azure.com/nanoframework/System.Text.RegularExpressions/_apis/build/status/System.Text.RegularExpressions?repoName=nanoframework%2Flib-nanoFramework.System.Text.RegularExpressions&branchName=develop)](https://dev.azure.com/nanoframework/System.Text.RegularExpressions/_build/latest?definitionId=69&repoName=nanoframework%2Flib-nanoFramework.System.Text.RegularExpressions&branchName=develop) | [![NuGet](https://img.shields.io/nuget/vpre/nanoFramework.System.Text.RegularExpressions.svg?label=NuGet&style=flat&logo=nuget)](https://www.nuget.org/packages/nanoFramework.System.Text.RegularExpressions/) |

**Important**: This Regular Expressions parser will cover most of your needs. It has some limitation when the pattern is complex and not a full compatibility. This is an on going work, mainly built on the .NET Microframework implementation. Please do not hesitate to raise any issue if any issue. Also, any help to improve this parser it's more than welcome.

In the [Tests](./Tests) you will find advance tests, so far only one is failing. Help to fix the parser needed!

## Usage

The level of compatibility with the full framework is high. The `Match`, `Group` classes are working as you can expect. The following examples gives an idea of the usage:

```csharp
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
```

Another example using `Split`:

```csharp
regex = new Regex("[ab]+");
acutalResults = regex.Split("xyzzyababbayyzabbbab123");
for (int i = 0; i < acutalResults.Length; i++)
{
    Debug.WriteLine($"{acutalResults[i]}");
}
// The results will be:
// xyzzy
// yyz
// 123
```

You can as well use the `Replace` function:

```csharp
regex = new Regex("a*b");
actual = regex.Replace("aaaabfooaaabgarplyaaabwackyb", "-");
Debug.WriteLine($"{actual}");
regex = new Regex("([a-b]+?)([c-d]+)");
actual = regex.Replace("zzabcdzz", "$1-$2");
Debug.WriteLine($"{actual}");
// The result will be:
// -foo-garply-wacky-
// zzab-cdzz
```

The next example shows the possibility to use options:

```csharp
regex = new Regex("abc(\\w*)");
Debug.WriteLine("RegexOptions.IgnoreCase abc(\\w*)");
regex.Options = RegexOptions.IgnoreCase;
if (regex.IsMatch("abcddd"))
{
    Debug.WriteLine("abcddd = true");
}
regex = new Regex("^abc$", RegexOptions.Multiline);
if (regex.IsMatch("\nabc"))
{
    Debug.WriteLine("abc found!");
}
// The result will be:
// abcddd = true
// abc found!
```

## Feedback and documentation

For documentation, providing feedback, issues and finding out how to contribute please refer to the [Home repo](https://github.com/nanoframework/Home).

Join our Discord community [here](https://discord.gg/gCyBu8T).

## Credits

The list of contributors to this project can be found at [CONTRIBUTORS](https://github.com/nanoframework/Home/blob/master/CONTRIBUTORS.md).

## License

The **nanoFramework** Class Libraries are licensed under the [MIT license](LICENSE.md).

Please check the header of the files in this repository, some of the code is under [Apache License 2.0](http://www.apache.org/licenses/LICENSE-2.0).

## Code of Conduct

This project has adopted the code of conduct defined by the Contributor Covenant to clarify expected behavior in our community.
For more information see the [.NET Foundation Code of Conduct](https://dotnetfoundation.org/code-of-conduct).

### .NET Foundation

This project is supported by the [.NET Foundation](https://dotnetfoundation.org).
