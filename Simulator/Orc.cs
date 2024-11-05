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
            rage = Validator.Limiter(value, 1, 10);
        }
    }

    private int huntCounter = 0;

    public override int Power => 7 * Level + 3 * Rage;

    public override string Info => $"{Name} [{Level}][{Rage}]";


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
