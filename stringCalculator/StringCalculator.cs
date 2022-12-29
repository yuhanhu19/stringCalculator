using System;
using System.Linq;
using Xunit.Sdk;

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
            var strings = numAsString.Split(new char[]{',', '\n'});
            return strings.Select(int.Parse).ToList().Sum();
        }
    }
}