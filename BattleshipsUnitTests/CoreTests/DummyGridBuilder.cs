using Battleships.Core;

namespace BattleshipsUnitTests.CoreTests;

internal class DummyGridBuilder : IGridBuilder
{
    private readonly Tile[,] _grid;

    public DummyGridBuilder()
    {
        var ship = new Ship(4, ShipClass.Destroyer);
        _grid = new[,]
        {
            { new ShipTile(ship), new ShipTile(ship), new ShipTile(ship), new ShipTile(ship) },
            { new(), new Tile(), new Tile(), new Tile() },
            { new Tile(), new Tile(), new Tile(), new Tile() },
            { new Tile(), new Tile(), new Tile(), new Tile() }
        };
    }

    public void AddShips(IEnumerable<ShipClass> shipClasses)
    {
    }

    public Tile[,] GetGrid()
    {
        return _grid;
    }
}