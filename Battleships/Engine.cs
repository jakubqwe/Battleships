using Battleships.Core;

namespace Battleships;

internal class Engine
{
    private readonly IGridBuilder _gridBuilder;
    private readonly IInputProvider _inputProvider;

    public Engine(IInputProvider inputProvider, IGridBuilder gridBuilder)
    {
        _inputProvider = inputProvider;
        _gridBuilder = gridBuilder;
    }

    public void Run(ICollection<ShipClass> ships)
    {
        var gameManager = new BattleshipGameManager(_gridBuilder, ships);

        OutputService.PrintGrid(gameManager.Grid);
        while (gameManager.ShipsNumber > 0)
        {
            try
            {
                var shotCoords = _inputProvider.GetCoordinates();
                var response = gameManager.ShootTile(shotCoords);
                if (!Console.IsOutputRedirected) Console.Clear();
                OutputService.PrintShotFeedback(response);
                OutputService.PrintGrid(gameManager.Grid);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        OutputService.PrintWin(gameManager.ShotsNumber);
    }
}