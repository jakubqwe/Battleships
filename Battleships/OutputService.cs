using Battleships.Core;

namespace Battleships;

internal static class OutputService
{
    public static void PrintWin(int numberOfShots)
    {
        Console.WriteLine($"You won. Number of shots: {numberOfShots}");
    }

    public static void PrintGrid(Tile[,] grid)
    {
        Console.Write("   ");
        for (var i = 0; i < grid.GetLength(0); i++)
        {
            Console.Write($"{(char)(i + 'A')} ");
        }

        Console.WriteLine();

        for (var i = 0; i < grid.GetLength(0); i++)
        {
            Console.Write($"{i + 1}{(i + 1 >= 10 ? " " : "  ")}");
            for (var j = 0; j < grid.GetLength(1); j++)
            {
                Console.Write(grid[i, j].IsHit ? grid[i, j] is ShipTile ? "X " : "O " : ". ");
            }

            Console.WriteLine();
        }
    }

    public static void PrintShotFeedback(ShotFeedback shotFeedback)
    {
        if (shotFeedback.ShipClass == ShipClass.None)
        {
            Console.WriteLine("Miss.");
            return;
        }

        Console.WriteLine($"{(shotFeedback.Sink ? "Sink" : "Hit")}. {shotFeedback.ShipClass}.");
    }
}