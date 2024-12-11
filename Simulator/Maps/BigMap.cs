namespace Simulator.Maps;

public abstract class BigMap : Map
{
    // Properties
    private readonly Dictionary<Point, List<IMappable>> _fields = new();


    // Constructors
    protected BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Map too wide.");
        }

        if (sizeY > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Map too high.");
        }
    }


    // Methods
    public override void Add(IMappable mappable, Point p)
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

    public override void Remove(IMappable mappable, Point p)
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

    public override void Move(IMappable mappable, Point from, Point to)
    {
        Remove(mappable, from);
        Add(mappable, to);
    }

    public override List<IMappable>? At(Point point)
    {
        if (_fields.ContainsKey(point))
        {
            return _fields[point];
        }

        return null;
    }

    public override List<IMappable> At(int x, int y)
    {
        return At(new Point(x, y));
    }
}
