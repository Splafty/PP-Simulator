namespace Simulator;

public class Elf : Creature
{
    // Properties
    private int agility = 1;
    public int Agility
    {
        get => agility;
        init
        {
            agility = Validator.Limiter(value, 1, 10);
        }
    }

    private int singCounter = 0;

    public override int Power => 8 * Level + 2 * Agility;

    public override string Info => $"{Name} [{Level}][{Agility}]";


    // Constructors
    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }

    public Elf() { }


    // Methods
    public override string Greeting() => $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.";

    public void Sing()
    {
        singCounter++;
        if (singCounter % 3 == 0 & agility < 10)
        {
            agility++;
        }
    }
}