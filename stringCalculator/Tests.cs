using System;
using Xunit;

namespace stringCalculator
{
    public class Tests
    {
        [Fact]
        public void ShouldReturn0GivenEmptyString()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("");
            Assert.Equal(0, result);
        }
    }
}