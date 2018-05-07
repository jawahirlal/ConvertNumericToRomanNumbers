using ConvertToRoman.Service;
using System;
using Xunit;

namespace ConvertToRoman.Tests
{
    public class RomanConverterTests
    {
        IRomanConverter romanConverter;
        
        public RomanConverterTests()
        {
            romanConverter = new RomanConverter(new RomanValueMappingCollection());
        }

        [Fact]
        public void TestWhen_1_Return_Multiple()
        {
            TestRomanValue(1, "I");
            TestRomanValue(2, "II");
            TestRomanValue(3, "III");
        }

        [Fact]
        public void TestWhen_4_9_With_Prefix()
        {
            TestRomanValue(4, "IV");
            TestRomanValue(9, "IX");
        }

        [Fact]
        public void TestWhen_5_8_Postfix()
        {
            TestRomanValue(5, "V");
            TestRomanValue(6, "VI");
            TestRomanValue(7, "VII");
            TestRomanValue(8, "VIII");
        }

        [Fact]
        public void TestWhen_Above_10_With_Postfix()
        {
            TestRomanValue(10, "X");
            TestRomanValue(11, "XI");
            TestRomanValue(12, "XII");
        }

        [Fact]
        public void Test_With_Random_Numberes()
        {
            TestRomanValue(1776, "MDCCLXXVI");
            TestRomanValue(1990, "MCMXC");
            TestRomanValue(2014, "MMXIV");
        }


        private void TestRomanValue(int num, string expected)
        {
            var actual = romanConverter.Convert(num);
            Assert.Equal(expected, actual);
        }
    }
}
