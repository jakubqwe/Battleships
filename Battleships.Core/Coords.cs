namespace Battleships.Core;

public struct Coords
{
    public int Column;
    public int Row;

    public Coords(int column, int row)
    {
        Column = column;
        Row = row;
    }
}