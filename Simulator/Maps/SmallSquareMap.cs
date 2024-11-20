namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{
    // Constructors
    public SmallSquareMap(int size) : base(size, size)
    {
    }

    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d);

        if (Exist(nextPoint))
        {
            return nextPoint;
        }
        else
        {
            return p;
        }
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextDiagonalPoint = p.NextDiagonal(d);

        if (Exist(nextDiagonalPoint))
        {
            return nextDiagonalPoint;
        }
        else
        {
            return p;
        }
    }
}