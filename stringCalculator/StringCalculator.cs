using System;

namespace stringCalculator
{
    public class StringCalculator
    {
        public int Add(string numAsString)
        {
            if (String.IsNullOrEmpty(numAsString))
            {
                return 0;
            }
            return 1;
        }
    }
}