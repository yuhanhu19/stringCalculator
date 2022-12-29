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

        [Fact]
        public void ShouldReturn1GivenStringWith1()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("1");
            Assert.Equal(1, result);
        }

        [Fact]
        public void ShouldReturn3GivenStringWith1And2SeparatedByCommas()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("1,2");
            Assert.Equal(3, result);
        }

        [Fact]
        public void ShouldReturn6GivenStringWith1And2And3SeparatedByNewLinesAndCommas()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("1\n2,3");
            Assert.Equal(6, result);
        }

        [Fact]
        public void ShouldThrowExceptionWhenInputEndsWithDelimiter()
        {
            var stringCalculator = new StringCalculator();
            var exception = Assert.Throws<FormatException>(() => stringCalculator.Add("1,2,"));
            Assert.Equal("Number expected but EOF found.", exception.Message);
        }

        [Fact]
        public void ShouldReturnSumGivenStringSeparatedByCustomDelimiters()
        {
            var stringCalculator = new StringCalculator();
            var result1 = stringCalculator.Add("//;\n1;3");
            var result2 = stringCalculator.Add("//sep\n2sep5");

            Assert.Equal(4, result1);
            Assert.Equal(7, result2);
        }

        [Fact]
        public void ShouldThrowExceptionGivenNegativeNumbers()
        {
            var stringCalculator = new StringCalculator();
            var exception = Assert.Throws<ArgumentException>(() => stringCalculator.Add("1,-2"));
            Assert.Equal("Negative number(s) not allowed: -2", exception.Message);
        }
        
        [Fact]
        public void ShouldIgnoreNumbersGreaterThan1000()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("2,1001");
            Assert.Equal(2, result);
        }
        
        
    }
}