using System;
using System.Collections.Generic;

namespace CSharpExercises
{
    public class Strings
    {
        public static string SubstringTo(string input, string end)
        {
            // SubstringTo(string s, string target) eg. SubstringTo("ndianfq*(0YPO&", "*") = "ndianfq*"
            return input.Substring(0, input.IndexOf(end) + 1);
        }

        public static string SubstringUntil(string input, string end)
        {
            // SubstringUntil(string s, string target) eg. SubstringUntil("ndianfq*(0YPO&", "*") = "ndianfq"
            return input.Substring(0, input.IndexOf(end));
        }

        public static string SubstringFrom(string input, string start, int offset)
        {
            // SubstringFrom(string s, string start) eg. SubstringFrom("ndianfq*(0YPO&", "*") = "*(0YPO&"
            return input.Substring(input.IndexOf(start, offset));
        }

        public static string SubstringBetween(string input, string start, string end)
        {
            // SubstringBetween(string s, string start, string end) eg. SubstringBetween("ndianfq*(0YPO&", "*", "0") = "*(0"
            var startIndex = input.IndexOf(start);
            var length = input.IndexOf(end) - input.IndexOf(start) + 1;
            return input.Substring(startIndex, length);
        }

        public static string[] AllSlicesBetween(string input, string start, string end)
        {
            // string[] AllSlicesBetween(string input, string start, string end) 
            // eg. AllSlicesBetween("abcdefgabefg", "b", "e") == ["bcde","be"]
            // try to re-use some of previous methods to make it more readable
            var stringList = new List<string>();
            var result = "";
            var offset = 0;
            while (true)
            {
                var startIndex = input.IndexOf(start, offset);
                var endIndex = input.IndexOf(end, offset);
                if (startIndex == -1 || endIndex == - 1) break;
                var length =  endIndex - startIndex + 1;
                result = input.Substring(input.IndexOf(SubstringFrom(input, start, offset)), length);
                stringList.Add(result);
                offset = endIndex + 1;
            }
            var inputArray = stringList.ToArray();
            return inputArray;
        }

        public static string GreedySubstringBetween(string input, string start, string end)
        {
            // string GreedySubstringBetween(string s, string start, string end) 
            // eg. GreedySubstringBetween("abcdefgabcdefg", "b", "d") == "bcdefgabcd"
            var startIndex = input.IndexOf(start);
            //var endIndex = input.LastIndexOf(end);
            var endIndex = input.IndexOf(end, (input.IndexOf(end) + 1));
            var length = endIndex - startIndex + 1;
            return input.Substring(startIndex, length);
        }
        // "abcdefg".IndexOf("e", 1) = 4
        // "abcdefg".Substring(0, "abcdefg".IndexOf("e", 2))
        /* 
        Steps:
        "abcdefg".Substring(a, b)
        a = 0
        b = "abcdefg".IndexOf("e",2)  = 4
        "abcdefg".Substring(0, 4) = "abcd"
        */
        // a = 1, b = 2, c = 3
        // (a + b) * (b + c) = 3 * 5 = 15
        // f = a * b
        // a = 1, b = 2
        // f = 1 * 2 = 2
        // a = 2, b = 4
        // f = 2 * 4 = 8

        // (20 * 11 + 5)/5
        // = (220 + 5)/5
        // = 225/5
        // = 45
    }  
}