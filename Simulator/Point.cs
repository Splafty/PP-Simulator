namespace Simulator;

public readonly struct Point
{
    // Properties
    public readonly int X, Y;
    public Point(int x, int y) => (X, Y) = (x, y);


    // Methods
    public Point Next(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                return new Point(X, Y + 1);
            case Direction.Right:
                return new Point(X + 1, Y);
            case Direction.Down:
                return new Point(X, Y - 1);
            case Direction.Left:
                return new Point(X - 1, Y);
            default:
                return this; // Wrong direction => No change
        }
    }

    // Rotate given direction 45 degrees clockwise
    public Point NextDiagonal(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                return new Point(X + 1, Y + 1);
            case Direction.Right:
                return new Point(X + 1, Y - 1);
            case Direction.Down:
                return new Point(X - 1, Y - 1);
            case Direction.Left:
                return new Point(X - 1, Y + 1);
            default:
                return this; // Wrong direction => No change
        }
    }

    public override string ToString() => $"({X}, {Y})";

}