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

        public static string SubstringFrom(string input, string start, int count)
        {
            // SubstringFrom(string s, string start) eg. SubstringFrom("ndianfq*(0YPO&", "*") = "*(0YPO&"
            return input.Substring(input.IndexOf(start, count));
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
            // if (!ContainsAll(input, start, end)) return Enumerable.Empty<string>();
            // else return SliceAllBetween(SubstringAfter(input, end), start, end).Append(FirstSliceBetween(input, start, end)).Reverse();

            var result = Enumerable.Empty<string>();
            while(ContainsAll(input, start, end))
            {
                var aSlice = FirstSliceBetween(input, start, end);
                result = result.Append(aSlice);
                input = SubstringAfter(input, end);
            }
            return result;
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
            if (input.IndexOf(start) >= input.IndexOf(end)) return SubstringBetween(input, end, start);
            else return SubstringBetween(input, start, end);
        }

        public static string SubstringBetween(string input, string start, string end)
        {
            // SubstringBetween(string s, string start, string end) eg. SubstringBetween("ndianfq*(0YPO&", "*", "0") = "*(0"
            // [InlineData("abcdeedcba", "b", "d", new [] { "bcd", "dcb" })]
            var startIndex = input.IndexOf(start);
            // "abcdeedcba" "b" "d" => ["bcd", "dcb"]
            var length = input.IndexOf(end) - input.IndexOf(start) + 1;
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
            var reversedInput = "";
            for (int offset = 0; offset < input.Length; offset++)
            {
                var piece = input.Substring(offset, 1);
                reversedInput = String.Concat(piece, reversedInput);
            }
            return reversedInput;
        }

        public static string ReverseS(string input)
        {
            if (input.Length == 0) return "";
            else return ReverseS(input.Tail() + input.Head());
        }

        private static (char head, List<char> tail) split(List<char> list)
        {
            var h = list[0];
            list.RemoveAt(0);
            return (h, list);
        }

        public static char[] ReverseIt(char[] input)
        {
            var reversedCharArray = new char[input.Length];
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

        public static string ReplaceAll(string input, string target, string replacement)
        {
            var offset = 0;
            var result = "";
            while (offset < input.Length)
            {
                if (IsSubstringMatch(input, offset, target))
                {
                    result += replacement;
                    offset += target.Length;
                }
                else
                {
                    result += input.Substring(offset, 1);
                    offset++;
                }
            }
            return result;
        }

        private static bool IsSubstringMatch(string input, int offset, string target)
        {
            // check if the offset plus target length is less than the input length
            if (offset + target.Length <= input.Length) 
            {
                // does the substring match the target
                if (input.Substring(offset, target.Length) == target)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool ContainsTarget(string input, string target)
        {
            return input.Contains(target);
        }

        private static int FindIndex(string input, string target)
        {
            return input.IndexOf(target);
        }

        private static string RemoveTarget(string input, string target)
        {

            // use substringbetween?
            return input.Replace(target, String.Empty);
        }

        private static string InsertReplacement(string input, int index, string replacement)
        {
            return input.Insert(index, replacement);
        }

        


        /*
check if string length is greater than  0
no return empty string
yes:
   find position target in input
   is target in string?
   no:
       return string
   yes: 
       remove target from string
       ?? keep indexof as point of replacement
       insert replacement where target was
       return string
   follow steps above to check if target still in string
   is there a space after the target?
   yes:
       remove target from string
       insert replacement where target was
       return string
   no: 
       return string
   follow steps above to check if target still in string
   no: 
       return string
   is there a space before target
   yes: 
       remove target from string
       insert replacement where target was
       return string
   no:
       return string
   follow steps above to check if target still in string

   input = ""

   let input = "abcdefg", target = "cd", replacement = "a": 
       string = "abefg", then "abaefg"
       "cd" not in string

   let input = "a quick fox", target = "the", replacement = "a":
       " quick fox"
       "the quick fox"
       "a" not in string

   let input = "the quick brown fox jumped over the lazy dog", target = "the", replacement = "a": 
       " quick brown fox jumped over the lazy dog"
       "a quick brown fox jumped over the lazy dog"
       target found in input
       "a quick brown fox jumped over   lazy dog"
       "a quick brown fox jumped over a lazy dog"
       target not found 

   let input = "the quick fox", target = "the", replacement = "there"
       " quick fox"
       "there quick fox"
       target found
           "re quick fox"
           "there quick fox"
           lines 233 - 234 loop indefinitely
       ignore lines 239 - 241
       no space after target
       "there quick fox"
   let input = "baby", target = "a", replacement = "after"
       "bby"
       "bafter"
       target found
       "bafter"
       target found 
           continously loops
       no space after target
       no space before target
       "bafter"
   let input = "the quick fox", target = "a", replacement = "no"
       "the quick fox"
*/
    }
}