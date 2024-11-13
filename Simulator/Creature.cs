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

    // Takes one parameter (Up, Right, Down, Left)
    public string Go(Direction direction) => $"{direction.ToString().ToLower()}";

    // Takes an array of parameters
    public string[] Go(Direction[] directions)
    {
        var result = new string[directions.Length];

        for (int i = 0; i < directions.Length; i++)
        {
            result[i] = Go(directions[i]);
        }

        return result;
    }

    // Takes a string of parameters
    public string[] Go(string directions)
    {
        Direction[] parsedDirections = DirectionParser.Parse(directions);
        return Go(parsedDirections);
    }
}