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

            var splitStrings = GetSplitStrings(numAsString);

            IList<string> errors = CheckAllPossibleErrors(splitStrings);
            if (errors.Any())
            {
                throw new Exception(string.Join("\n", errors));
            }

            IList<int> validNumbers = GetValidNumbers(splitStrings);

            return validNumbers.Sum();
        }

        private IList<int> GetValidNumbers(string[] numberStringToParse)
        {
            return numberStringToParse.Select(s => int.Parse(s)).Where(number => number <= 1000).ToList();
        }

        private IList<string> CheckAllPossibleErrors(string[] splitStrings)
        {
            IList<string> errors = new List<string>();
            IList<string> negatives = new List<string>();
            foreach (var s in splitStrings)
            {
                if (!IsNumber(s))
                {
                    errors.Add($"{s} is not a number.");
                }

                if (IsNegative(s))
                {
                    negatives.Add(s);
                }
            }

            if (negatives.Any())
            {
                errors.Add("Negative number(s) not allowed: " + string.Join(",", negatives));
            }

            return errors;
        }

        private bool IsNegative(string s)
        {
            return s.Contains('-');
        }

        private bool IsNumber(string s)
        {
            return int.TryParse(s, out _);
        }

        private string[] GetSplitStrings(string numberString)
        {
            var delimiters = new[] { ",", "\n" };
            if (numberString.StartsWith("//"))
            {
                var splitString = numberString.TrimStart('/').Split('\n');
                var newDelimiterString = splitString.First();
                return splitString[1].Split(new[] { newDelimiterString }, StringSplitOptions.None);
            }

            return numberString.Split(delimiters, StringSplitOptions.None);
        }
    }
}