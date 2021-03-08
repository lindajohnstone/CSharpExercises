using System;
using System.Collections.Generic;
using Xunit;

namespace CSharpExercises.Tests
{
    public class StringTests
    {
        [Fact]
        public void StringTo_method()
        {
            // SubstringTo(string s, string target) eg. SubstringTo("ndianfq*(0YPO&", "*") = "ndianfq*"
            var expected = "ndianfq*";
            var target = "*";
            var result = Strings.SubstringTo("ndianfq*(0YPO&", target);
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void StringUntil_method()
        {
            // SubstringUntil(string s, string target) eg. SubstringUntil("ndianfq*(0YPO&", "*") = "ndianfq"
            var expected = "ndianfq";
            var target = "*";
            var result = Strings.SubstringUntil("ndianfq*(0YPO&", target);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void StringFrom_method()
        {
            // SubstringFrom(string s, string start) eg. SubstringFrom("ndianfq*(0YPO&", "*") = "*(0YPO&"
            var expected = "*(0YPO&";
            var target = "*";
            var offset = 0;
            var result = Strings.SubstringFrom("ndianfq*(0YPO&", target, offset);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void StringBetween_method()
        {
            // SubstringBetween(string s, string start, string end) eg. SubstringBetween("ndianfq*(0YPO&", "*", "0") = "*(0"
            var expected = "*(0";
            var result = Strings.SubstringBetween("ndianfq*(0YPO&", "*", "0");
            Assert.Equal(expected, result);
        }

        [Fact]
        public void AllSlicesBetween_testing_values()
        {
            var input = "abcdefgabefg";
            var start = input.IndexOf("b");
            var end = input.IndexOf("e");
            Assert.Equal(1, start);
            Assert.Equal(4, end);
            Assert.Equal(8, input.IndexOf("b", input.IndexOf("e")));
            Assert.Equal(9, input.IndexOf("e", input.IndexOf("e") + 1));
            Assert.Equal(8, input.IndexOf("b", 6)); // index 6 is first instance of "e"
            Assert.Equal("be", input.Substring(8, 2));
            Assert.Equal("bcde", input.Substring(input.IndexOf("b"), input.IndexOf("e") - input.IndexOf("b") + 1));
            Assert.Equal("be", input.Substring(input.IndexOf("b", input.IndexOf("e")), input.IndexOf("e") - input.IndexOf("b") - 1));
        }

        [Theory]
        [InlineData("abcdefgabefg", "b", "e", new[] { "bcde", "be" })]
        [InlineData("abcdefg", "b", "e", new[] { "bcde" })]
        public void AllSlicesBetween_method_(string input, string start, string end, string[] expected)
        {
            var result = Strings.AllSlicesBetween(input, start, end);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Find_first_value_AllSlicesBetween_method()
        {
            var input = "abcdefgabefg";
            var expected = "bcde";
            var result = input.Substring(input.IndexOf("b"), input.IndexOf("e"));
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Find_second_value_AllSlicesBetween_method()
        {
            var input = "abcdefgabefg";
            var expected = "be";
            var start = "b";
            var end = "e";
            var result = input.Substring(input.IndexOf(start, input.IndexOf(end)), input.IndexOf(end) - input.IndexOf(start) - 1);
            Assert.Equal(expected, result); 
        }

        [Theory]
        [InlineData("abcdefgabcdefg", "b", "d", "bcdefgabcd")]
        [InlineData("absfdavdafdefabbwddefg", "b", "d", "bsfdavdafdefabbwdd")]
        public void GreedySubstring_method(string input, string start, string end, string expected)
        {
            // string GreedySubstringBetween(string s, string start, string end) 
            // eg. GreedySubstringBetween("abcdefgabcdefg", "b", "d") == "bcdefgabcd"
            // GreedySubstringBetween("absfdavdafdefabbwddefg", "b", "d") == "bsfdavdafdefabbwdd"
            var result = Strings.GreedySubstringBetween(input, start, end);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GreedySubstring_method_find_end_index()
        {
            var input = "abcdefgabcdefg";
            var expected = 10;
            var end = "d";
            var result = input.IndexOf(end, (input.IndexOf(end) + 1));
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("abc", "cba")]
        [InlineData("abcd", "dcba")]
        public void Reverse_string(string input, string expected)
        {
            var result = Strings.ReverseIt(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Substring_And_IndexOf()
        {
            var input = "//[***]\n1***2***3";
            var start = input.IndexOf("[") + 1;
            var end = input.IndexOf("]") - start;
            var newInput = "//[,]\n1,2,4";
            Assert.Equal(4, newInput.IndexOf("]"));
            Assert.Equal(2, newInput.IndexOf("["));
            Assert.Equal(2, input.IndexOf("["));
            Assert.Equal(6, input.IndexOf("]"));
            Assert.Equal("***", input.Substring(start, end));
            Assert.Equal(",", newInput.Substring(3, newInput.IndexOf("]") - 3));
        }

        [Fact]
        public void More_substring()
        {
            // SubstringTo(string s, string target) eg. SubstringTo("ndianfq*(0YPO&", "*") = "ndianfq*"
            // SubstringUntil(string s, string target) eg. SubstringUntil("ndianfq*(0YPO&", "*") = "ndianfq"
            // SubstringFrom(string s, string start) eg. SubstringFrom("ndianfq*(0YPO&", "*") = "*(0YPO&"
            // SubstringBetween(string s, string start, string end) eg. SubstringBetween("ndianfq*(0YPO&", "*", "0") = "*(0"
            var input = "ndianfq*(0YPO&";
            Assert.Equal("*(0YPO&", input.Substring(input.IndexOf("*")));
            Assert.Equal("ndianfq", input.Substring(input.IndexOf("ndianfq*(0YPO&"), input.IndexOf("*")));
            Assert.Equal("*(", input.Substring(input.IndexOf("*"), input.IndexOf("0") - input.IndexOf("*")));
            Assert.Equal(7, input.IndexOf("*"));
            Assert.Equal(9, input.IndexOf("0"));
            Assert.Equal("ndianfq", input.Substring(input.IndexOf("ndianfq*(0YPO&"), input.IndexOf("*")));
        }

        [Fact]
        public void More_substring_and_indexof()
        {
            var input = "//[*][%]\n1*2%3";
            var value = input.Substring(input.IndexOf("\n"));
            var delimiters = input.Substring(0, input.LastIndexOf("]"));
            var delimiter = delimiters.Replace("//[", "").Split("][");
            Assert.Equal(4, input.IndexOf("]["));
            Assert.Equal("//[*][%", delimiters);
            Assert.Equal("*", delimiter[0]);
            Assert.Equal("%", delimiter[1]);
        }

        [Fact]
        public void String_Methods()
        {
            var hello = "Hello";
            var world = "World";
            Assert.Equal("Hello World", ($"{hello} {world}"));
            Assert.Equal("Hello World", String.Concat(hello, " ", world));
            Assert.Equal("Hello World", String.Join(" ", new List<string>() { hello, world }));
        }

        [Fact]
        public void String_Tests()
        {
            string s1 = "He said, \"This is the last \u0063hance\x0021\"";
            Assert.Equal("He said, \"This is the last chance!\"", s1);
            Assert.Equal(@"Nancy said Hello World! \ smiled.", "Nancy said Hello World! \\ smiled.");
            Assert.Equal(@"c:\documents\files\u0066.txt", "c:\\documents\\files\\u0066.txt");
        }

        [Fact]
        public void More_String_Tests()
        {
            // arrange
            string regularStringLiteral = "String literal 4\r\nAnother line";
            string verbatimStringLiteral = @"String literal 4
Another line";
            // act

            // assert
            Assert.Equal(verbatimStringLiteral, regularStringLiteral);
            Assert.Equal(@"
", "\r\n");
            Assert.Equal("", String.Empty);
        }

        [Fact]
        public void String_Substrings()
        {
            // arrange
            string s3 = "Visual C# Express";
            // act

            // assert
            Assert.Equal("C#", s3.Substring(7, 2));
            Assert.Equal("Visual Basic Express", s3.Replace("C#", "Basic"));
            Assert.Equal(7, s3.IndexOf("C"));
        }

        [Fact]
        public void String_Interpolation()
        {
            // arrange
            var jh = (firstName: "Jupiter", lastName: "Hammon", born: 1711, published: 1761);
            var name = "Linda";

            // act

            // assert
            Assert.Equal("Jupiter Hammon was an African American poet born in 1711.",
                $"{jh.firstName} {jh.lastName} was an African American poet born in {jh.born}.");
            Assert.Equal("He was first published in 1761 at the age of 50.",
                $"He was first published in {jh.published} at the age of {jh.published - jh.born}.");
            Assert.Equal("He'd be over 300 years old today.",
                $"He'd be over {Math.Round((2018d - jh.born) / 100d) * 100d} years old today.");
            Assert.Equal("Linda", $"{name}");
        }
        [Fact]
        public void IndexOf_2_integer_parameters()
        {
            var input = "The quick brown fox jumped over the lazy dog.";
            Assert.Equal("abcdefg".IndexOf("e", 2), "abcdefg".IndexOf("e"));
            Assert.Equal("abcd","abcdefg".Substring(0, "abcdefg".IndexOf("e", 2)));
            Assert.Equal(2, input.IndexOf("e"));
            Assert.Equal(24, input.IndexOf("e", 4));
        }
    }
}
