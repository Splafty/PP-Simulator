using Simulator.Maps;
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
    public Map? Map { get; private set; }
    public Point Position { get; private set; }

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
    public void InitMapAndPosition(Map map, Point position) { }

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

    // OUT
    // Takes one parameter (Up, Right, Down, Left)
    public string Go(Direction direction) => $"{direction.ToString().ToLower()}";

    // Takes an array of parameters
    public string[] Go(Direction[] directions)
    {
        // Map.Next()
        // Map.Next() == Position -> bez ruchu

        // Map.Move()

        var result = new string[directions.Length];

        for (int i = 0; i < directions.Length; i++)
        {
            result[i] = Go(directions[i]);
        }

        return result;
    }
    // OUT
    // Takes a string of parameters
    public string[] Go(string directions)
    {
        Direction[] parsedDirections = DirectionParser.Parse(directions);
        return Go(parsedDirections);
    }
}