namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    // Properties
    public int Size { get; }
    private Rectangle border;


    // Constructors
    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException("Size must be between 5 and 20.");
        }
        Size = size;
        border = new Rectangle(0, 0, Size - 1, Size - 1);
    }


    // Methods
    public override bool Exist(Point p)
    {
        return border.Contains(p);
    }

    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d);

        switch (d)
        {
            case Direction.Up:
                return Exist(nextPoint) ? nextPoint : new Point(p.X, 0);
            case Direction.Right:
                return Exist(nextPoint) ? nextPoint : new Point(0, p.Y);
            case Direction.Down:
                return Exist(nextPoint) ? nextPoint : new Point(p.X, Size - 1);
            case Direction.Left:
                return Exist(nextPoint) ? nextPoint : new Point(Size - 1, p.Y);
            default:
                return p; // Wrong direction => No change
        }
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextDiagonalPoint = p.NextDiagonal(d);

        switch (d)
        {
            case Direction.Up:
                return Exist(nextDiagonalPoint) ? nextDiagonalPoint : new Point((p.X + 1) % Size, (p.Y + 1) % Size);
            case Direction.Right:
                return Exist(nextDiagonalPoint) ? nextDiagonalPoint : new Point((p.X + 1) % Size, (p.Y - 1 + Size) % Size);
            case Direction.Down:
                return Exist(nextDiagonalPoint) ? nextDiagonalPoint : new Point((p.X - 1 + Size) % Size, (p.Y - 1 + Size) % Size);
            case Direction.Left:
                return Exist(nextDiagonalPoint) ? nextDiagonalPoint : new Point((p.X - 1 + Size) % Size, (p.Y + 1) % Size);
            default:
                return p; // Wrong direction => No change
        }
    }
}
