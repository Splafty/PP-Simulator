using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Creature
{
    // Properties
    private string? name;
    public string? Name { get; }


    private int level;
    public int Level { get; set; }


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
}