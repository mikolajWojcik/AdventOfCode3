using System;
using System.Collections.Generic;
using ConsoleApp3;
using Xunit;

namespace TestProject2
{
    public class UnitTest1
    {
        private List<string> _testList = new List<string>
        {
            "00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010"
        };
        
        [Fact]
        public void CheckOxygenRating()
        {
            var result = RatingHelper.GetRating(5, _testList, true);
            
            Assert.Equal(23, result);
        }
        
        [Fact]
        public void CheckCo2Rating()
        {
            var result = RatingHelper.GetRating(5, _testList, false);
            
            Assert.Equal(10, result);
        }
    }
}