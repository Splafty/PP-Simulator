using Simulator;
using Simulator.Maps;

namespace SimConsole;

internal class LogVisualizer
{
    SimulationHistory Log { get; }
    public LogVisualizer(SimulationHistory log)
    {
        Log = log;
    }

    public void Draw(int turnIndex)
    {
        if (turnIndex < 0 || turnIndex >= Log.TurnLogs.Count)
        {
            throw new ArgumentOutOfRangeException("Turn index out of range.");
        }

        var turnLog = Log.TurnLogs[turnIndex];
        var lines = new List<string>();

        // Top border
        var topBorder = Box.TopLeft.ToString();
        for (int x = 0; x < Log.SizeX; x++)
        {
            topBorder += Box.Horizontal;
            if (x < Log.SizeX - 1)
            {
                topBorder += Box.TopMid;
            }
        }

        topBorder += Box.TopRight;
        lines.Add(topBorder);

        // Rows
        for (int y = Log.SizeY - 1; y >= 0; y--)
        {
            var row = Box.Vertical.ToString();
            for (int x = 0; x < Log.SizeX; x++)
            {
                var point = new Point(x, y);

                if (turnLog.Symbols.ContainsKey(point))
                {
                    var symbols = turnLog.Symbols[point];

                    if (symbols.Count > 1)
                    {
                        row += 'X';
                    }
                    else
                    {
                        row += symbols[0];
                    }
                }
                else
                {
                    row += ' ';
                }

                if (x < Log.SizeX - 1)
                {
                    row += Box.Vertical;
                }
            }

            row += Box.Vertical;
            lines.Add(row);

            // Mid border
            if (y > 0)
            {
                var midBorder = Box.MidLeft.ToString();
                for (int x = 0; x < Log.SizeX; x++)
                {
                    midBorder += Box.Horizontal;
                    if (x < Log.SizeX - 1)
                    {
                        midBorder += Box.Cross;
                    }
                }

                midBorder += Box.MidRight;
                lines.Add(midBorder);
            }
        }

        // Bottom border
        var bottomBorder = Box.BottomLeft.ToString();
        for (int x = 0; x < Log.SizeX; x++)
        {
            bottomBorder += Box.Horizontal;
            if (x < Log.SizeX - 1)
            {
                bottomBorder += Box.BottomMid;
            }
        }

        bottomBorder += Box.BottomRight;
        lines.Add(bottomBorder);

        // Printing result to console for now - we can do something with the result in the future
        if (turnIndex == 0)
        {
            Console.WriteLine($"[LOGS] Turn: {turnIndex}");
        }
        else
        {
            Console.WriteLine($"[LOGS] Turn: {turnIndex + 1}");
        }

        foreach (var line in lines)
        {
            Console.WriteLine(line);
        }
    }

}