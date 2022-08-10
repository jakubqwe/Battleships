using Battleships.Core;

namespace Battleships;

internal class ConsoleInputProvider : IInputProvider
{
    public Coords GetCoordinates()
    {
        Console.WriteLine(@"Provide shot coordinates (ex. A5): ");
        return InputParser.ParseCoords(Console.ReadLine());
    }
}

internal interface IInputProvider
{
    Coords GetCoordinates();
}