namespace Simulator;

public class Orc : Creature
{
    // Properties
    private int rage = 1;
    public int Rage
    {
        get => rage;
        init
        {
            if (value < 0)
            {
                value = 0;
            }
            if (value > 10)
            {
                value = 10;
            }

            rage = value;
        }
    }

    private int huntCounter = 0;

    public override int Power => 7 * Level + 3 * Rage;


    // Constructors
    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }

    public Orc() { }


    // Methods
    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");

    public void Hunt()
    {
        Console.WriteLine($"{Name} is hunting.");
        huntCounter++;
        if (huntCounter % 2 == 0 & rage < 10)
        {
            rage++;
        }
    }
}
