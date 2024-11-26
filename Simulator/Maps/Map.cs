namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    // Properties
    public int SizeX { get; }
    public int SizeY { get; }
    protected abstract List<Creature>?[,] Fields { get; }
    private Rectangle border;


    // Constructors
    public Map(int sizeX, int sizeY)
    {
        if (sizeX < 5 || sizeY < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Map to small, min size 5x5.");
        }
        SizeX = sizeX;
        SizeY = sizeY;

        border = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }


    // Methods
    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p)
    {
        return border.Contains(p);
    }

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);

    public void Add(Creature creature, Point p)
    {
        if (!Exist(p))
        {
            throw new InvalidOperationException($"Point {p} is not a part of the map.");
        }

        if (Fields[p.X, p.Y] == null)
        {
            Fields[p.X, p.Y] = new List<Creature>();
        }

        Fields[p.X, p.Y].Add(creature);
    }

    public void Remove(Creature creature, Point p)
    {
        if (!Exist(p))
        {
            throw new InvalidOperationException($"Point {p} is not a part of the map.");
        }

        if (Fields[p.X, p.Y] != null)
        {
            Fields[p.X, p.Y].Remove(creature);

            if (Fields[p.X, p.Y]?.Count == 0)
            {
                Fields[p.X, p.Y] = null;
            }
        }
    }

    public void Move(Creature creature, Point from, Point to)
    {
        Remove(creature, from);
        Add(creature, to);
    }

    // Return null so we dont create empty lists
    public List<Creature>? At(Point point)
    {
        if (Fields[point.X, point.Y] == null)
        {
            return null;
        }

        return Fields[point.X, point.Y];
    }

    public List<Creature> At(int x, int y)
    {
        return At(new Point(x, y));
    }
}