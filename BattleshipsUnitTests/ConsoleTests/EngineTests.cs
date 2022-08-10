using Battleships;
using Battleships.Core;
using BattleshipsUnitTests.CoreTests;

namespace BattleshipsUnitTests.ConsoleTests;

public class EngineTests
{
    [Fact]
    public void RunTest()
    {
        var engine = new Engine(new DummyInputProvider(), new DummyGridBuilder());
        engine.Run(new List<ShipClass> { ShipClass.Destroyer });
    }
}