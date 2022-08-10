namespace Battleships.Core;

public class ShipTile : Tile
{
    public readonly Ship Ship;

    public ShipTile(Ship ship)
    {
        Ship = ship;
    }
}