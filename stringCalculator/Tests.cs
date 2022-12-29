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
            Assert.Equal("Number expected but EOF found.",exception.Message);
        }
    }
}