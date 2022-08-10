using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.Core;

namespace BattleshipsUnitTests.CoreTests
{
    public class GameManagerTests
    {
        [Fact]
        public void ShootTileTests()
        {
            var gridBuilder = new DummyGridBuilder();
            var gameManager = new BattleshipGameManager(gridBuilder, new List<ShipClass> { ShipClass.Destroyer });
            var grid = gridBuilder.GetGrid();

            Assert.Equal(0, gameManager.ShotsNumber);
            Assert.Equal(1, gameManager.ShipsNumber);

            var response = gameManager.ShootTile(new Coords(0, 0));
            Assert.False(response.Sink);
            Assert.Equal(ShipClass.Destroyer, response.ShipClass);

            Assert.True(grid[0, 0].IsHit);
            Assert.Throws<InvalidOperationException>(() => gameManager.ShootTile(new Coords(0, 0)));

            Assert.Equal(1, gameManager.ShotsNumber);

            response = gameManager.ShootTile(new Coords(0, 1));
            Assert.Equal(ShipClass.None, response.ShipClass);

            gameManager.ShootTile(new Coords(1, 0));
            gameManager.ShootTile(new Coords(2, 0));
            response = gameManager.ShootTile(new Coords(3, 0));
            Assert.Equal(ShipClass.Destroyer, response.ShipClass);
            Assert.True(response.Sink);

            Assert.Equal(5, gameManager.ShotsNumber);
            Assert.Equal(0, gameManager.ShipsNumber);

        }
    }
}
