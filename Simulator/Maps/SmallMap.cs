namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    // Properties
    private readonly List<IMappable>?[,] _fields;
    protected override List<IMappable>?[,] Fields => _fields;


    // Constructors
    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Map too wide.");
        }

        if (sizeY > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Map too high.");
        }

        _fields = new List<IMappable>?[sizeX, sizeY];
    }


    // Methods
    public override void Add(IMappable mappable, Point p)
    {
        if (!Exist(p))
        {
            throw new InvalidOperationException($"Point {p} is not a part of the map.");
        }

        if (Fields[p.X, p.Y] == null)
        {
            Fields[p.X, p.Y] = new List<IMappable>();
        }

        Fields[p.X, p.Y].Add(mappable);
    }

    public override void Remove(IMappable mappable, Point p)
    {
        if (!Exist(p))
        {
            throw new InvalidOperationException($"Point {p} is not a part of the map.");
        }

        if (Fields[p.X, p.Y] != null)
        {
            Fields[p.X, p.Y].Remove(mappable);

            if (Fields[p.X, p.Y]?.Count == 0)
            {
                Fields[p.X, p.Y] = null;
            }
        }
    }

    public override void Move(IMappable mappable, Point from, Point to)
    {
        Remove(mappable, from);
        Add(mappable, to);
    }

    // Return null so we dont create empty lists
    public override List<IMappable>? At(Point point)
    {
        if (Fields[point.X, point.Y] == null)
        {
            return null;
        }

        return Fields[point.X, point.Y];
    }

    public override List<IMappable> At(int x, int y)
    {
        return At(new Point(x, y));
    }
}
