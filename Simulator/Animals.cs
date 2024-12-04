using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Animals : IMappable
{
    // Properties
    public Map? Map { get; private set; }
    public Point Position { get; set; }
    public virtual char Symbol => 'A';

    private string description = "Unknown";
    public string Description
    {
        get => description;
        init
        {
            description = Validator.Shortener(value, 3, 15, '#');
        }
    }

    public int Size { get; set; } = 3;

    public virtual string Info => $"{Description} <{Size}>";


    //Constructors
    public Animals(string description, int size = 3)
    {
        Description = description;
        Size = size;
    }

    public Animals() { }


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

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";

    public virtual void Go(Direction direction)
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