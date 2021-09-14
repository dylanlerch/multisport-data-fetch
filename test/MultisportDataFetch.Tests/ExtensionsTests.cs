using System;
using Xunit;
using MultisportDataFetch;

namespace MultisportDataFetch.Tests
{
    public class ExtensionsTests
    {
        [Theory]
        [InlineData("\t\t\t", "")]
        [InlineData("\n\n\n", "")]
        [InlineData("\n  \n \n", "   ")]
        [InlineData("Hello\nWorld", "HelloWorld")]
        [InlineData("Hello&nbsp;World", "HelloWorld")]
        public void CleanWhitespace(string input, string expected)
        {
            var actual = input.CleanWhitespace();

            Assert.Equal(expected, actual);
        }
    }
}
