using System;
using System.Globalization;
using System.Linq;
using Xunit.Sdk;

namespace stringCalculator
{
    public class StringCalculator
    {
        public int Add(string numAsString)
        {
            // if (numAsString.StartsWith("//"))
            // {
            //     
            // }

            if (string.IsNullOrEmpty(numAsString))
            {
                return 0;
            }

            var strings = numAsString.Split(new char[] { ',', '\n' });
            if (strings.Contains(null) || strings.Contains(""))
            {
                throw new FormatException("Number expected but EOF found.");
            }

            return strings.Select(int.Parse).ToList().Sum();
        }
    }
}