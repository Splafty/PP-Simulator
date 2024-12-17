﻿namespace Simulator;

public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];
    // store starting positions at index 0

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }

    private void Run()
    {
        while (!_simulation.Finished)
        {
            var positionsandsymbols = new Dictionary<Point, char>();

            _simulation.Turn();

            foreach (var imappable in _simulation.IMappables)
            {
                positionsandsymbols[imappable.Position] = imappable.Symbol;
            }

            var turnLog = new SimulationTurnLog
            {
                Mappable = _simulation.CurrentMappable.ToString(),
                Move = _simulation.CurrentMoveName,
                Symbols = positionsandsymbols
            };

            TurnLogs.Add(turnLog);
        }
    }
}