using SimConsole;
using Simulator.Maps;
using Simulator;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        RunSimulation1();
        Console.WriteLine("\nPress any key to run another simulation...\n");
        Console.ReadKey(true);
        RunSimulation2();
    }

    static void RunSimulation1()
    {
        SmallSquareMap map = new(5);
        List<Creature> creatures = new() { new Orc("Gorbag"), new Elf("Elandor") };
        List<Point> points = new() { new(2, 2), new(3, 1) };
        string moves = "dlrludl";

        RunSimulation(map, creatures, points, moves);
    }

    static void RunSimulation2()
    {
        SmallSquareMap map = new(6);
        List<Creature> creatures = new() { new Orc("Ugluk"), new Elf("Galadriel"), new Elf("Elrond") };
        List<Point> points = new() { new(0, 0), new(5, 5), new(2, 3) };
        string moves = "uldrddrl";

        RunSimulation(map, creatures, points, moves);
    }

    static void RunSimulation(Map map, List<Creature> creatures, List<Point> points, string moves)
    {
        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        Console.WriteLine("SIMULATION!\n");
        Console.WriteLine("Starting positions:");
        mapVisualizer.Draw();
        Console.WriteLine("Press any key to continue...\n");

        int round = 1;
        while (!simulation.Finished)
        {
            Console.ReadKey(true);
            Console.WriteLine($"Turn {round}");
            round++;

            Console.Write($"{simulation.CurrentCreature.ToString()} {simulation.CurrentCreature.Position} goes {simulation.CurrentMoveName}:\n");
            simulation.Turn();

            mapVisualizer.Draw();
            Console.WriteLine("Press any key to continue...\n");
        }

        Console.WriteLine("Simulation finished!");
    }
}