
namespace Simulator.Maps;

public class BigBounceMap : BigMap
{
    // Constructors
    public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
    }


    // Methods
    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d);
        switch (d)
        {
            case Direction.Up:
                return Exist(nextPoint) ? nextPoint : new Point(nextPoint.X, SizeY - 1 - (nextPoint.Y % (SizeY - 1)));
            case Direction.Right:
                return Exist(nextPoint) ? nextPoint : new Point(SizeX - 1 - (nextPoint.X % (SizeX - 1)), nextPoint.Y);
            case Direction.Down:
                return Exist(nextPoint) ? nextPoint : new Point(nextPoint.X, 0 - nextPoint.Y);
            case Direction.Left:
                return Exist(nextPoint) ? nextPoint : new Point(0 - nextPoint.X, nextPoint.Y);
            default:
                return p; // Wrong direction => No change
        }
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextDiagonalPoint = p.NextDiagonal(d);

        // We are checking for corner cases and acting accordingly - like we discussed during the lesson
        // If the point is not in a corner and if we follow the rules of physics the "bounce" should probably work like this(??).
        // I don't know if this solution is correct for this exercise, so if it's wrong I will change it.
        switch (d)
        {
            case Direction.Up:
                if (p.X == SizeX - 1 && p.Y == SizeY - 1)
                {
                    return p;
                }
                else if (p.X == SizeX - 1)
                {
                    return Exist(p.NextDiagonal(Direction.Left)) ? p.NextDiagonal(Direction.Left) : p;
                }
                else if (p.Y == SizeY - 1)
                {
                    return Exist(p.NextDiagonal(Direction.Right)) ? p.NextDiagonal(Direction.Right) : p;
                }
                else
                {
                    return Exist(nextDiagonalPoint) ? nextDiagonalPoint : p;
                }

            case Direction.Right:
                if (p.X == SizeX - 1 && p.Y == 0)
                {
                    return p;
                }
                else if (p.X == SizeX - 1)
                {
                    return Exist(p.NextDiagonal(Direction.Down)) ? p.NextDiagonal(Direction.Down) : p;
                }
                else if (p.Y == 0)
                {
                    return Exist(p.NextDiagonal(Direction.Up)) ? p.NextDiagonal(Direction.Up) : p;
                }
                else
                {
                    return Exist(nextDiagonalPoint) ? nextDiagonalPoint : p;
                }

            case Direction.Down:
                if (p.X == 0 && p.Y == 0)
                {
                    return p;
                }
                else if (p.X == 0)
                {
                    return Exist(p.NextDiagonal(Direction.Right)) ? p.NextDiagonal(Direction.Right) : p;
                }
                else if (p.Y == 0)
                {
                    return Exist(p.NextDiagonal(Direction.Left)) ? p.NextDiagonal(Direction.Left) : p;
                }
                else
                {
                    return Exist(nextDiagonalPoint) ? nextDiagonalPoint : p;
                }

            case Direction.Left:
                if (p.X == 0 && p.Y == SizeY - 1)
                {
                    return p;
                }
                else if (p.X == 0)
                {
                    return Exist(p.NextDiagonal(Direction.Up)) ? p.NextDiagonal(Direction.Up) : p;
                }
                else if (p.Y == SizeY - 1)
                {
                    return Exist(p.NextDiagonal(Direction.Down)) ? p.NextDiagonal(Direction.Down) : p;
                }
                else
                {
                    return Exist(nextDiagonalPoint) ? nextDiagonalPoint : p;
                }
            default:
                return p; // Wrong direction => No change
        }
    }
}
