namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        Creature c = new Creature("Shrek", 7);
        c.SayHi();
        c.Level = 8;
        Console.WriteLine(c.Info);

        Creature d = new Creature("Fiona");
        d.SayHi();
        Console.WriteLine(d.Info);

        Creature e = new Creature();
        e.SayHi();
        Console.WriteLine(d.Info);

        Animals rats = new() { Description = "Rats", Size = 10 };
        Console.WriteLine(rats.Info);
        Animals mice = new() { Description = "Mice", Size = 40 };
        Console.WriteLine(mice.Info);
        Animals cats = new() { Description = "Cats" }; // cats.Size == 3
        Console.WriteLine(cats.Info);
    }
}