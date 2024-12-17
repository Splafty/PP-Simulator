
namespace Simulator.Maps;

public class BigTorusMap : BigMap
{
    // Constructors
    public BigTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
    }


    // Methods
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
                return Exist(nextPoint) ? nextPoint : new Point(p.X, SizeY - 1);
            case Direction.Left:
                return Exist(nextPoint) ? nextPoint : new Point(SizeX - 1, p.Y);
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
                return Exist(nextDiagonalPoint) ? nextDiagonalPoint : new Point((p.X + 1) % SizeX, (p.Y + 1) % SizeY);
            case Direction.Right:
                return Exist(nextDiagonalPoint) ? nextDiagonalPoint : new Point((p.X + 1) % SizeX, (p.Y - 1 + SizeY) % SizeY);
            case Direction.Down:
                return Exist(nextDiagonalPoint) ? nextDiagonalPoint : new Point((p.X - 1 + SizeX) % SizeX, (p.Y - 1 + SizeY) % SizeY);
            case Direction.Left:
                return Exist(nextDiagonalPoint) ? nextDiagonalPoint : new Point((p.X - 1 + SizeX) % SizeX, (p.Y + 1) % SizeY);
            default:
                return p; // Wrong direction => No change
        }
    }
}
