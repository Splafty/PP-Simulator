using Simulator;
using Simulator.Maps;

namespace SimConsole;

public class MapVisualizer
{
    private readonly Map _map;

    public MapVisualizer(Map map)
    {
        _map = map;
    }

    public void Draw()
    {
        var lines = new List<string>();

        // Top border
        var topBorder = Box.TopLeft.ToString();
        for (int x = 0; x < _map.SizeX; x++)
        {
            topBorder += Box.Horizontal;
            if (x < _map.SizeX - 1)
            {
                topBorder += Box.TopMid;
            }
        }

        topBorder += Box.TopRight;
        lines.Add(topBorder);

        // Rows
        for (int y = _map.SizeY - 1; y >= 0; y--)
        {
            var row = Box.Vertical.ToString();
            for (int x = 0; x < _map.SizeX; x++)
            {
                var creatures = _map.At(new Point(x, y));

                if (creatures != null && creatures.Count > 1)
                {
                    row += 'X';
                }
                else if (creatures != null && creatures.Count == 1)
                {
                    var creature = creatures[0];
                    row += creature.Symbol;
                }
                else
                {
                    row += ' ';
                }

                if (x < _map.SizeX - 1)
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
                for (int x = 0; x < _map.SizeX; x++)
                {
                    midBorder += Box.Horizontal;
                    if (x < _map.SizeX - 1)
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
        for (int x = 0; x < _map.SizeX; x++)
        {
            bottomBorder += Box.Horizontal;
            if (x < _map.SizeX - 1)
            {
                bottomBorder += Box.BottomMid;
            }
        }

        bottomBorder += Box.BottomRight;
        lines.Add(bottomBorder);

        // Printing result to console for now - we can do something with the result in the future
        foreach (var line in lines)
        {
            Console.WriteLine(line);
        }
    }

}