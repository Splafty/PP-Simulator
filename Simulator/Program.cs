namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab3a();

        //    Early tests
        //    Creature c = new Creature("Shrek", 7);
        //    c.SayHi();
        //    Console.WriteLine(c.Info);

        //    Creature d = new Creature("Fiona");
        //    d.SayHi();
        //    Console.WriteLine(d.Info);

        //    Creature e = new Creature();
        //    e.SayHi();
        //    Console.WriteLine(d.Info);

        //    Animals rats = new() { Description = "Rats", Size = 10 };
        //    Console.WriteLine(rats.Info);
        //    Animals mice = new() { Description = "Mice", Size = 40 };
        //    Console.WriteLine(mice.Info);
        //    Animals cats = new() { Description = "Cats" }; // cats.Size == 3
        //    Console.WriteLine(cats.Info);
    }


    // Copied function
    static void Lab3a()
    {
        Creature c = new() { Name = "   Shrek    ", Level = 20 };
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new("  ", -5);
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new("  donkey ") { Level = 7 };
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new("Puss in Boots – a clever and brave cat.");
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new("a                            troll name", 5);
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        var a = new Animals() { Description = "   Cats " };
        Console.WriteLine(a.Info);

        a = new() { Description = "Mice           are great", Size = 40 };
        Console.WriteLine(a.Info);
    }
}