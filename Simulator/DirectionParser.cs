namespace Simulator;

public static class DirectionParser
{
    public static Direction[] Parse(string directions)
    {
        var result = new List<Direction>();

        foreach (char c in directions.ToUpper())
        {
            switch (c)
            {
                case 'U':
                    result.Add(Direction.Up);
                    break;
                case 'R':
                    result.Add(Direction.Right);
                    break;
                case 'D':
                    result.Add(Direction.Down);
                    break;
                case 'L':
                    result.Add(Direction.Left);
                    break;
                // Ignore any other case 
            }
        }

        return result.ToArray();
    }
}
