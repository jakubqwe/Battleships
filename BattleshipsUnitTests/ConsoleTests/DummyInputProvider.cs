using Battleships;
using Battleships.Core;

namespace BattleshipsUnitTests.ConsoleTests;

internal class DummyInputProvider : IInputProvider
{
    private int _column = 4;
    private int _row = 3;

    public Coords GetCoordinates()
    {
        if (--_column < 0)
        {
            _column = 3;
            _row--;
        }

        return new Coords(_column, _row);
    }
}