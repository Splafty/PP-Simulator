namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    // Constructors
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
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
