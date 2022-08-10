namespace Battleships.Core;

public class Ship
{
    public int TilesNumber;

    public Ship(int tilesNumber, ShipClass shipClass)
    {
        TilesNumber = tilesNumber;
        ShipClass = shipClass;
    }

    public ShipClass ShipClass { get; }
    public bool IsSunk => TilesNumber == 0;

    public void Hit()
    {
        TilesNumber--;
    }
}