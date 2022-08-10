using Battleships.Core;

namespace Battleships;

internal class Program
{
    private static void Main(string[] args)
    {
        var ships = new List<ShipClass>
        {
            ShipClass.Battleship,
            ShipClass.Destroyer,
            ShipClass.Destroyer
        };

        var engine = new Engine(new ConsoleInputProvider(), new RandomGridBuilder(new Random(), 10));
        engine.Run(ships);
    }
}