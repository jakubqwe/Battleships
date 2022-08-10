using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships;
using Battleships.Core;

namespace BattleshipsUnitTests.ConsoleTests
{
    public class InputParserTests
    {
        [Theory]
        [InlineData("A1", 0, 0)]
        [InlineData("a2", 0, 1)]
        [InlineData("B10", 1, 9)]
        [InlineData(" C 4 ", 2, 3)]
        public void ParseCoordsTest(string input, int expectedColumn, int expectedRow)
        {
            var coords = InputParser.ParseCoords(input);
            Assert.Equal(expectedColumn, coords.Column);
            Assert.Equal(expectedRow, coords.Row);
        }

        [Theory]
        [InlineData("A")]
        [InlineData("A ")]
        [InlineData("10")]
        [InlineData("AA")]
        [InlineData("")]
        public void ParseCoordsExceptionsTest(string input)
        {
            Assert.Throws<ArgumentException>(() => InputParser.ParseCoords(input));
        }
    }
}
