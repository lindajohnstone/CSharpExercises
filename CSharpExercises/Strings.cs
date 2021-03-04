using System;
using System.Collections.Generic;

namespace CSharpExercises
{
    public class Strings
    {
        public static string SubstringTo(string input, string target)
        {
            return input.Substring(0, input.IndexOf(target) + 1);
        }

        public static string SubstringUntil(string input, string target)
        {
            return input.Substring(0, input.IndexOf(target));
        }

        public static string SubstringFrom(string input, string target)
        {
            return input.Substring(input.IndexOf(target));
        }

        public static string SubstringBetween(string input, string start, string end)
        {
            return input.Substring(input.IndexOf(start), input.IndexOf(end) - input.IndexOf(start) + 1);
        }

        public static string[] AllSlicesBetween(string input, string start, string end)
        {
            // string[] AllSlicesBetween(string input, string start, string end) 
            // eg. AllSlicesBetween("abcdefgabefg", "b", "e") == ["bcde","be"]
            var stringList = new List<string>();
            var firstInstance = "";
            var offset = 0;
            while (true)
            {
                var startIndex = input.IndexOf(start, offset);
                var endIndex = input.IndexOf(end, offset);
                if (startIndex == -1 || endIndex == - 1) break;
                var length =  endIndex - startIndex + 1;
                firstInstance = input.Substring(input.IndexOf(start, offset), length);
                stringList.Add(firstInstance);
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
        /* Steps:
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

// hit => hmommyt
// hitit => hmommytmommyt
// hititit => hmommytmommytmommyt
public string momifier(string input) {
    var reuslt = ReplaceFirst(input, "i", "mommy");
    while(reuslt.Contains("i")) {
        reuslt = ReplaceFirst(reuslt, "i", "mommy");
    }
    if(reuslt.Contains("i")) {
        reuslt = ReplaceFirst(reuslt, "i", "mommy");
    }
    return reuslt;
}

public string ReplaceFirst(string text, string search, string replace)
{
  int pos = text.IndexOf(search);
  if (pos < 0)
  {
    return text;
  }
  return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
}
    }

    
}