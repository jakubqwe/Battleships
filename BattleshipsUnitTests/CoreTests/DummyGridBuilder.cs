using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.Core;

namespace BattleshipsUnitTests.CoreTests
{
    internal class DummyGridBuilder : IGridBuilder
    {
        private Tile[,] _grid;

        public DummyGridBuilder()
        {
            var ship = new Ship(4, ShipClass.Destroyer);
            _grid = new Tile[,]
            {
                {new ShipTile(ship), new ShipTile(ship), new ShipTile(ship), new ShipTile(ship) },
                {new Tile(), new Tile(), new Tile(), new Tile()},
                {new Tile(), new Tile(), new Tile(), new Tile()},
                {new Tile(), new Tile(), new Tile(), new Tile()}
            };
        }
        public void AddShips(IEnumerable<ShipClass> shipsClasses)
        {
        }

        public Tile[,] GetGrid()
        {
            return _grid;
        }
    }
}
