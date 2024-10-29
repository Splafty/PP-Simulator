using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Creature
{
    // Properties
    private string name = "Unknown";
    public string Name 
    {
        get => name;
        init
        {
            value = value.Trim();

            if (value.Length > 25)
            {
                value = value.Substring(0, 25).TrimEnd();
            }

            if (value.Length < 3)
            {
                value = value.PadRight(3, '#');
            }

            if (char.IsLower(value[0]))
            {
                value = char.ToUpper(value[0]) + value.Substring(1);
            }

            name = value;
        }
    }


    private int level;
    public int Level
    {
        get => level;
        init
        {

            if (value < 1)
            {
                value = 1;
            }

            else if (value > 10)
            {
                value = 10;
            }

            level = value;
        }
    }


    // Constructors
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }


    // Methods
    public void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");

    public string Info => $"{Name} [{Level}]";

    public void Upgrade()
    {
        if (level < 10)
        {
            level++;
        }
    }
}