namespace Battleships.Core;

public interface IGridBuilder
{
    void AddShips(IEnumerable<ShipClass> shipClasses);
    Tile[,] GetGrid();
}