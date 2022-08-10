using Battleships.Core;

namespace Battleships;

public static class InputParser
{
    public static Coords ParseCoords(string input)
    {
        input = input.Replace(" ", "");
        if (input.Length < 2)
        {
            throw new ArgumentException("Invalid input length", nameof(input));
        }

        if (!char.IsLetter(input[0]) || !char.IsNumber(input[1]))
        {
            throw new ArgumentException("Invalid input format", nameof(input));
        }

        var y = int.Parse(input.Substring(1));
        return new Coords(char.ToUpperInvariant(input[0]) - 'A', y - 1);
    }
}