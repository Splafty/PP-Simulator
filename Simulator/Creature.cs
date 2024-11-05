using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public abstract class Creature
{
    // Properties
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
    public abstract void SayHi();

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

    // Takes one parameter (Up, Right, Down, Left)
    public void Go(Direction direction)
    {
        Console.WriteLine($"{Name} goes {direction.ToString().ToLower()}.");
    }

    // Takes an array of parameters
    public void Go(Direction[] directions)
    {
        foreach (var direction in directions)
        {
            Go(direction);
        }
    }

    // Takes a string of parameters
    public void Go(string directions)
    {
        Direction[] parsedDirections = DirectionParser.Parse(directions);
        Go(parsedDirections);
    }
}