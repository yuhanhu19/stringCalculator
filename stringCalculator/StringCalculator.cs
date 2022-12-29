using System;
using System.Collections.Generic;
using System.Linq;

namespace stringCalculator
{
    public class StringCalculator
    {
        public int Add(string numAsString)
        {
            if (string.IsNullOrEmpty(numAsString))
            {
                return 0;
            }

            var delimiters = new List<char> { ',', '\n' };
            string numberString = numAsString;
            if (numberString.StartsWith("//"))
            {
                var splitString = numberString.TrimStart('/').Split('\n');
                var newDelimiterString = splitString.First();
                numberString = numberString.TrimStart('/').Replace(newDelimiterString, "\n");
            }
            var strings = numberString.Split(delimiters.ToArray());
            if (strings.Last()=="")
            {
                throw new FormatException("Number expected but EOF found.");
            }
            return strings.Where(s => s != "").ToArray().Select(int.Parse).ToList().Sum();
        }
    }
}