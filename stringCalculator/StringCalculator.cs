using System;

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
            return 1;
        }
        
        public int Add(string numAsString1, string numAsString2)
        {
            return int.Parse(numAsString1)+int.Parse(numAsString2);
        }
    }
}