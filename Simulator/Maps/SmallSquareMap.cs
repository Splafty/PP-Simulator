namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    // Properties
    public int Size { get; }
    private Rectangle border;


    // Constructors
    public SmallSquareMap(int size)
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