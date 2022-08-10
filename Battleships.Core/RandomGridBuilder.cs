using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Battleships.Core
{
    public class RandomGridBuilder : IGridBuilder
    {
        private readonly Tile[,] _grid;
        private readonly Random _random;
        private readonly int _gridSize;
        public RandomGridBuilder(Random random, int gridSize)
        {
            _gridSize = gridSize;
            _random = random;

            _grid = new Tile[gridSize, gridSize];
            FillGrid();
        }

        internal void FillGrid()
        {
            for (var i = 0; i < _gridSize; i++)
            {
                for (var j = 0; j < _gridSize; j++)
                {
                    _grid[i, j] = new Tile();
                }
            }
        }

        public void AddShips(IEnumerable<ShipClass> shipsClasses)
        {
            foreach (var shipClass in shipsClasses)
            {
                var ship = new Ship((int)shipClass, shipClass);
                AddShip(ship);
            }
        }

        internal void AddShip(Ship ship)
        {
            var isVertical = _random.Next(2) == 0;
            if (TryAddShip(ship, isVertical))
            {
                return;
            }

            if (TryAddShip(ship, !isVertical))
            {
                return;
            }

            throw new Exception("Cannot place ship on grid");
        }

        internal bool TryAddShip(Ship ship, bool isVertical)
        {
            var possibleCoords = Enumerable.Range(0, _gridSize * _gridSize)
                .Select(e => new Coords(e % _gridSize, e / _gridSize))
                .ToArray();

            for (int i = 0; i < possibleCoords.Length; i++)
            {
                var coordsIndex = _random.Next(possibleCoords.Length - i);
                var coords = possibleCoords[coordsIndex];

                if (CanAddShip(coords, ship, isVertical))
                {
                    PlaceShipOnGrid(coords, ship, isVertical);
                    return true;
                }

                possibleCoords[coordsIndex] = possibleCoords[^(i + 1)];
            }

            return false;
        }

        internal bool CanAddShip(Coords coords, Ship ship, bool isVertical)
        {
            for (int i = 0; i < (int)ship.ShipClass; i++)
            {
                var x = isVertical ? coords.Column + i : coords.Column;
                var y = isVertical ? coords.Row : coords.Row + i;
                if (x >= _gridSize || y >= _gridSize || _grid[y, x] is ShipTile)
                {
                    return false;
                }
            }

            return true;
        }

        internal void PlaceShipOnGrid(Coords coords, Ship ship, bool isVertical)
        {
            for (int i = 0; i < (int)ship.ShipClass; i++)
            {
                var x = isVertical ? coords.Column + i : coords.Column;
                var y = isVertical ? coords.Row : coords.Row + i;
                _grid[y, x] = new ShipTile(ship);
            }
        }

        public Tile[,] GetGrid()
        {
            return _grid;
        }
    }
}
