using System;
using System.Collections.Generic;
using System.Linq;

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

        public static string[] AllSlicesBetween(string input, string start, string end)
        {
            // string[] AllSlicesBetween(string input, string start, string end) 
            // eg. AllSlicesBetween("abcdefgabefg", "b", "e") == ["bcde","be"]
            // try to re-use some of previous methods to make it more readable
            // var stringList = new List<string>();
            // var result = "";
            // var offset = 0;
            // while (true)
            // {
            //     var startIndex = input.IndexOf(start, offset);
            //     var endIndex = input.IndexOf(end, offset);
            //     if (startIndex == -1 || endIndex == - 1) break;
            //     var length =  endIndex - startIndex + 1;
            //     result = input.Substring(input.IndexOf(SubstringFrom(input, start, offset)), length);
            //     stringList.Add(result);
            //     offset = endIndex + 1;
            // }
            // var inputArray = stringList.ToArray();
            // return inputArray;
            return SliceAllBetween(input, start, end).ToArray();
        }

        private static IEnumerable<string> SliceAllBetween(string input, string start, string end)
        {
            // "" => []
            // "abcde" "b" "d" => ["bcd"] | "e" "b" "d" => []
            // "abcdeedcba" "b" "d" => ["bcd", "dcb"]
            if(!ContainsAll(input, start, end)) return Enumerable.Empty<string>();
            else return SliceAllBetween(SubstringAfter(input, end), start, end).Append(FirstSliceBetween(input, start, end)).Reverse();
        }

        private static bool ContainsAll(string input, string start, string end)
        {
            return input.Contains(start) && input.Contains(end);
        }

        private static string SubstringAfter(string input, string cutPoint)
        {
            return input.Substring(input.IndexOf(cutPoint) + 1);
        }

        private static string FirstSliceBetween(string input, string start, string end)
        {
            //"abcdeedcba" "b" "d" => ["bcd", "dcb"]
            if(input.IndexOf(start) < input.IndexOf(end))
            return SubstringBetween(input, start, end);
            // need the substring from first instance of end
            else return SubstringBetween(input, end, start);
            // supposed to send input = input = "abcdeedcba" end = "d" start = "b" 
            // length = -2 for second instance of 'end'
        }

        public static string SubstringBetween(string input, string start, string end)
        {
            // SubstringBetween(string s, string start, string end) eg. SubstringBetween("ndianfq*(0YPO&", "*", "0") = "*(0"
            // [InlineData("abcdeedcba", "b", "d", new [] { "bcd", "dcb" })]
            var startIndex = input.IndexOf(start);
            // "abcdeedcba" "b" "d" => ["bcd", "dcb"]
            // 
            var length = input.IndexOf(end) - input.IndexOf(start) + 1;// TODO: error here - length = -2
            return input.Substring(startIndex, length);
        }
        
        public static string GreedySubstringBetween(string input, string start, string end)
        {
            // string GreedySubstringBetween(string s, string start, string end) 
            // eg. GreedySubstringBetween("abcdefgabcdefg", "b", "d") == "bcdefgabcd"
            // GreedySubstringBetween("absfdavdafdefabbwddefg", "b", "d") == "bsfdavdafdefabbwdd"
            var startIndex = input.IndexOf(start);
            var endIndex = input.LastIndexOf(end);
            var length = endIndex - startIndex + 1;
            return input.Substring(startIndex, length);
        }

        public static string ReverseIt(string input)
        {
            /*
                Substring
                Replace
                Contains
                Split
                Concat
                Join
                ToCharArray
                Remove
            */
            var reversedInput = "";
            // 
            for (int offset = 0; offset < input.Length; offset++)
            {
                var piece = input.Substring(offset, 1);
                reversedInput = String.Concat(piece, reversedInput);
            }
            return reversedInput;
        }

        public static string ReverseS(string input) 
        {
            if(input.Length == 0) return "";
            else return ReverseS(input.Tail() + input.Head());
        }
        
        // public static IEnumerable<char> ReverseA(IEnumerable<char> input) {
        //     if(input.Count = 0) return new List<char>();
        //     else {
        //         var list = split(input);
        //         return ReverseA(list.tail).Concat(new List<char>(){list.head});
        //     }
        // }

        private static (char head, List<char> tail) split(List<char> list) {
            var h = list[0];
            list.RemoveAt(0);
            return (h, list);
        }

        public static char[] ReverseIt(char[] input)
        {
            var reversedCharArray = new char [input.Length];
            for (int index = 0; index < input.Length; index++)
            {
                var offset = input.Length - index - 1; 
                reversedCharArray[index] = input[offset];
            }
            return reversedCharArray;
        }

        public static List<string> ReverseIt(List<string> listStrings)
        {
            listStrings.Reverse();
            return listStrings;
        }

        public static IEnumerable<T> Reverse<T>(IEnumerable<T> list)
        {
            return list.Count() == 0 ? Enumerable.Empty<T>() : Reverse(list.Skip(1)).Append(list.First());
        }

        public static string Reverse(string s)
        {
            return s.Length == 0 ? "" : Reverse(s.Substring(1)) + s.First();
        }

        public static char[] ReverseItChar(char[] input)
        {
            var reverseInput = input.Reverse();
            return reverseInput.ToArray();
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

        public static string ReplaceAll(string input, string target, string replacement)
        {
            return input.Replace(target, replacement);
        }
        /*
        check if string length is greater than  0
        no return empty string
        yes:
            find position target in input
            remove target from input
            insert replacemnet where target was
            follow steps above to check if target still in string
            input = ""

            let input = "abcdefg", target = "cd", replacement = "a": 
                string = "abefg", then "abaefg"
            
            let input = "a quick fox", target = "the", replacement = "a":
                " quick fox"
                "the quick fox"
            
            input = the quick fox
            target = the
            replacement = there
        */
    }  
}