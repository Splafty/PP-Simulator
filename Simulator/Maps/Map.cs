namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    // Properties
    public int SizeX { get; }
    public int SizeY { get; }

    private readonly Dictionary<Point, List<IMappable>> _fields = new();
    private Rectangle border;

    protected Func<Map, Point, Direction, Point>? FNext { get; set; }
    protected Func<Map, Point, Direction, Point>? FNextDiagonal { get; set; }


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
    /// <param name="d">Direction.</param>w
    /// <returns>Next point.</returns>
    public Point Next(Point p, Direction d) => FNext?.Invoke(this, p, d) ?? p;

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public Point NextDiagonal(Point p, Direction d) => FNextDiagonal?.Invoke(this, p, d) ?? p;


    public virtual void Add(IMappable mappable, Point p)
    {
        if (!Exist(p))
        {
            throw new InvalidOperationException($"Point {p} is not a part of the map.");
        }

        if (!_fields.ContainsKey(p))
        {
            _fields[p] = new List<IMappable>();
        }

        _fields[p].Add(mappable);
    }

    public virtual void Remove(IMappable mappable, Point p)
    {
        if (!Exist(p))
        {
            throw new InvalidOperationException($"Point {p} is not a part of the map.");
        }

        if (_fields.ContainsKey(p))
        {
            _fields[p].Remove(mappable);

            if (_fields[p].Count == 0)
            {
                _fields.Remove(p);
            }
        }
    }

    public virtual void Move(IMappable mappable, Point from, Point to)
    {
        Remove(mappable, from);
        Add(mappable, to);
    }

    public virtual List<IMappable>? At(Point point)
    {
        if (_fields.ContainsKey(point))
        {
            return _fields[point];
        }

        return null;
    }

    public virtual List<IMappable> At(int x, int y)
    {
        return At(new Point(x, y));
    }
}