namespace Simulator.Maps;

public static class MoveLogic
{
    // Square map moves
    public static Point BorderNext(Map m, Point p, Direction d)
    {
        Point nextPoint = p.Next(d);

        if (m.Exist(nextPoint))
        {
            return nextPoint;
        }
        else
        {
            return p;
        }
    }

    public static Point BorderNextDiagonal(Map m, Point p, Direction d)
    {
        Point nextDiagonalPoint = p.NextDiagonal(d);

        if (m.Exist(nextDiagonalPoint))
        {
            return nextDiagonalPoint;
        }
        else
        {
            return p;
        }
    }


    // Torus map moves
    public static Point TorusNext(Map m, Point p, Direction d)
    {
        Point nextPoint = p.Next(d);

        switch (d)
        {
            case Direction.Up:
                return m.Exist(nextPoint) ? nextPoint : new Point(p.X, 0);
            case Direction.Right:
                return m.Exist(nextPoint) ? nextPoint : new Point(0, p.Y);
            case Direction.Down:
                return m.Exist(nextPoint) ? nextPoint : new Point(p.X, m.SizeY - 1);
            case Direction.Left:
                return m.Exist(nextPoint) ? nextPoint : new Point(m.SizeX - 1, p.Y);
            default:
                return p; // Wrong direction => No change
        }
    }

    public static Point TorusNextDiagonal(Map m, Point p, Direction d)
    {
        Point nextDiagonalPoint = p.NextDiagonal(d);

        switch (d)
        {
            case Direction.Up:
                return m.Exist(nextDiagonalPoint) ? nextDiagonalPoint : new Point((p.X + 1) % m.SizeX, (p.Y + 1) % m.SizeY);
            case Direction.Right:
                return m.Exist(nextDiagonalPoint) ? nextDiagonalPoint : new Point((p.X + 1) % m.SizeX, (p.Y - 1 + m.SizeY) % m.SizeY);
            case Direction.Down:
                return m.Exist(nextDiagonalPoint) ? nextDiagonalPoint : new Point((p.X - 1 + m.SizeX) % m.SizeX, (p.Y - 1 + m.SizeY) % m.SizeY);
            case Direction.Left:
                return m.Exist(nextDiagonalPoint) ? nextDiagonalPoint : new Point((p.X - 1 + m.SizeX) % m.SizeX, (p.Y + 1) % m.SizeY);
            default:
                return p; // Wrong direction => No change
        }
    }


    // Bounce map moves
    public static Point BounceNext(Map m, Point p, Direction d)
    {
        Point nextPoint = p.Next(d);

        switch (d)
        {
            case Direction.Up:
                return m.Exist(nextPoint) ? nextPoint : new Point(nextPoint.X, m.SizeY - 1 - (nextPoint.Y % (m.SizeY - 1)));
            case Direction.Right:
                return m.Exist(nextPoint) ? nextPoint : new Point(m.SizeX - 1 - (nextPoint.X % (m.SizeX - 1)), nextPoint.Y);
            case Direction.Down:
                return m.Exist(nextPoint) ? nextPoint : new Point(nextPoint.X, 0 - nextPoint.Y);
            case Direction.Left:
                return m.Exist(nextPoint) ? nextPoint : new Point(0 - nextPoint.X, nextPoint.Y);
            default:
                return p; // Wrong direction => No change
        }
    }

    public static Point BounceNextDiagonal(Map m, Point p, Direction d)
    {
        Point nextDiagonalPoint = p.NextDiagonal(d);

        switch (d)
        {
            case Direction.Up:
                if (p.X == m.SizeX - 1 && p.Y == m.SizeY - 1)
                {
                    return p;
                }
                else if (p.X == m.SizeX - 1)
                {
                    return m.Exist(p.NextDiagonal(Direction.Left)) ? p.NextDiagonal(Direction.Left) : p;
                }
                else if (p.Y == m.SizeY - 1)
                {
                    return m.Exist(p.NextDiagonal(Direction.Right)) ? p.NextDiagonal(Direction.Right) : p;
                }
                else
                {
                    return m.Exist(nextDiagonalPoint) ? nextDiagonalPoint : p;
                }

            case Direction.Right:
                if (p.X == m.SizeX - 1 && p.Y == 0)
                {
                    return p;
                }
                else if (p.X == m.SizeX - 1)
                {
                    return m.Exist(p.NextDiagonal(Direction.Down)) ? p.NextDiagonal(Direction.Down) : p;
                }
                else if (p.Y == 0)
                {
                    return m.Exist(p.NextDiagonal(Direction.Up)) ? p.NextDiagonal(Direction.Up) : p;
                }
                else
                {
                    return m.Exist(nextDiagonalPoint) ? nextDiagonalPoint : p;
                }

            case Direction.Down:
                if (p.X == 0 && p.Y == 0)
                {
                    return p;
                }
                else if (p.X == 0)
                {
                    return m.Exist(p.NextDiagonal(Direction.Right)) ? p.NextDiagonal(Direction.Right) : p;
                }
                else if (p.Y == 0)
                {
                    return m.Exist(p.NextDiagonal(Direction.Left)) ? p.NextDiagonal(Direction.Left) : p;
                }
                else
                {
                    return m.Exist(nextDiagonalPoint) ? nextDiagonalPoint : p;
                }

            case Direction.Left:
                if (p.X == 0 && p.Y == m.SizeY - 1)
                {
                    return p;
                }
                else if (p.X == 0)
                {
                    return m.Exist(p.NextDiagonal(Direction.Up)) ? p.NextDiagonal(Direction.Up) : p;
                }
                else if (p.Y == m.SizeY - 1)
                {
                    return m.Exist(p.NextDiagonal(Direction.Down)) ? p.NextDiagonal(Direction.Down) : p;
                }
                else
                {
                    return m.Exist(nextDiagonalPoint) ? nextDiagonalPoint : p;
                }
            default:
                return p; // Wrong direction => No change
        }
    }
}