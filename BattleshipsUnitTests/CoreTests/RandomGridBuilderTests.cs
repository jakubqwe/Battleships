using Battleships.Core;

namespace BattleshipsUnitTests.CoreTests;

public class RandomGridBuilderTests
{
    [Fact]
    public void EqualDistributionTest()
    {
        var distribution = new float[4];

        for (var i = 0; i < 10000; i++)
        {
            var builder = new RandomGridBuilder(new Random(), 10);
            builder.AddShips(new[]
                { ShipClass.Battleship, ShipClass.Battleship, ShipClass.Battleship, ShipClass.Battleship });
            var grid = builder.GetGrid();
            if (grid[0, 0] is ShipTile) distribution[0]++;
            if (grid[0, 9] is ShipTile) distribution[1]++;
            if (grid[9, 0] is ShipTile) distribution[2]++;
            if (grid[9, 9] is ShipTile) distribution[3]++;
        }

        Assert.True(distribution[0] / distribution[1] <= 1.3 && distribution[0] / distribution[1] >= 0.7);
        Assert.True(distribution[0] / distribution[2] <= 1.3 && distribution[0] / distribution[2] >= 0.7);
        Assert.True(distribution[0] / distribution[3] <= 1.3 && distribution[0] / distribution[3] >= 0.7);
    }

    [Fact]
    public void ExceptionsTest()
    {
        var builder = new RandomGridBuilder(new Random(), 1);
        Assert.Throws<Exception>(() => builder.AddShips(new[] { ShipClass.Battleship }));
    }

    [Fact]
    public void PlaceShipOnGridTest()
    {
        var builder = new RandomGridBuilder(new Random(), 5);
        builder.PlaceShipOnGrid(new Coords(0, 0), new Ship(4, ShipClass.Destroyer), true);
        var grid = builder.GetGrid();
        Assert.True(grid[0, 0] is ShipTile);
        Assert.True(grid[0, 1] is ShipTile);
        Assert.True(grid[0, 2] is ShipTile);
        Assert.True(grid[0, 3] is ShipTile);

        builder.PlaceShipOnGrid(new Coords(0, 1), new Ship(4, ShipClass.Destroyer), false);
        grid = builder.GetGrid();
        Assert.True(grid[1, 0] is ShipTile);
        Assert.True(grid[4, 0] is ShipTile);
    }

    [Fact]
    public void CanAddShipTest()
    {
        var builder = new RandomGridBuilder(new Random(), 4);
        Assert.True(builder.CanAddShip(new Coords(0, 0), new Ship(4, ShipClass.Destroyer), true));
        Assert.True(builder.CanAddShip(new Coords(0, 0), new Ship(4, ShipClass.Destroyer), false));
        Assert.False(builder.CanAddShip(new Coords(1, 0), new Ship(4, ShipClass.Destroyer), true));
    }

    [Fact]
    public void AddShipsTest()
    {
        var builder = new RandomGridBuilder(new Random(), 4);
        builder.AddShips(new[] { ShipClass.Destroyer, ShipClass.Destroyer, ShipClass.Destroyer, ShipClass.Destroyer });
        var grid = builder.GetGrid();
        for (var i = 0; i < 4; i++)
        {
            for (var j = 0; j < 4; j++)
            {
                Assert.True(grid[i, j] is ShipTile);
            }
        }
    }
}