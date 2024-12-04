using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public abstract class Creature : IMappable
{
    // Properties
    public Map? Map { get; private set; }
    public Point Position { get; private set; }
    public abstract char Symbol { get; }

    private string name = "Unknown";
    public string Name 
    {
        get => name;
        init
        {
            name = Validator.Shortener(value, 3, 25, '#');
        }
    }

    private int level = 1;
    public int Level
    {
        get => level;
        init
        {
            level = Validator.Limiter(value, 1, 10);
        }
    }

    public abstract int Power { get; }

    public abstract string Info { get; }


    // Constructors
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }


    // Methods
    public void InitMapAndPosition(Map map, Point p)
    {
        if (!map.Exist(p))
        {
            throw new InvalidOperationException($"Point {p} is not a part of the map.");
        }

        Map = map;
        Position = p;
    }

    public abstract string Greeting();

    public void Upgrade()
    {
        if (level < 10)
        {
            level++;
        }
    }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

    public void Go(Direction direction)
    {
        if (Map == null)
        {
            return;
        }

        Point nextPosition = Map.Next(Position, direction);
        Map.Move(this, Position, nextPosition);

        Position = nextPosition;
    }
}