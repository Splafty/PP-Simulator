using SimConsole;
using Simulator.Maps;
using Simulator;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        //RunSimulation1();
        //Console.WriteLine("\nPress any key to run another simulation...\n");
        //Console.ReadKey(true);
        //RunSimulation2();
        //Console.WriteLine("\nPress any key to run another simulation...\n");
        //Console.ReadKey(true);
        //RunSimulation3();

        //RunSimulation4();
        //Console.WriteLine("\nPress any key to run another simulation - ONLY FLYING BIRDS...\n");
        //Console.ReadKey(true);

        // Testing flying birds movement on bouncy map
        //RunSimulation5();
        //Console.WriteLine("\nPress any key to run another simulation - ONLY NON FLYING BIRDS...\n");
        //Console.ReadKey(true);

        // Testing non flying birds movement on bouncy map
        //RunSimulation6();

        RunSimulation7();
    }

    static void RunSimulation1()
    {
        SmallSquareMap map = new(5);
        List<IMappable> mappables = new() { new Orc("Gorbag"), new Elf("Elandor") };
        List<Point> points = new() { new(2, 2), new(3, 1) };
        string moves = "dlrludl";

        RunSimulation(map, mappables, points, moves);
    }

    static void RunSimulation2()
    {
        SmallSquareMap map = new(6);
        List<IMappable> mappables = new() { new Orc("Ugluk"), new Elf("Galadriel"), new Elf("Elrond") };
        List<Point> points = new() { new(0, 0), new(5, 5), new(2, 3) };
        string moves = "uldrddrl";

        RunSimulation(map, mappables, points, moves);
    }

    static void RunSimulation3()
    {
        SmallTorusMap map = new(8, 6);
        List<IMappable> mappables = new() { new Orc("Ugluk"), new Elf("Galadriel"), new Animals("Rabbits", 6), new Birds("Eagles", 3, true), new Birds("Ostrich", 8, false) };
        List<Point> points = new() { new(0, 0), new(5, 5), new(2, 3), new(4, 2), new(1, 1) };
        string moves = "uldrddrlrrululr";

        RunSimulation(map, mappables, points, moves);
    }

    static void RunSimulation4()
    {
        BigBounceMap map = new(8, 6);
        List<IMappable> mappables = new() { new Orc("Ugluk"), new Elf("Galadriel"), new Animals("Rabbits", 6), new Birds("Eagles", 3, true), new Birds("Ostriches", 8, false) };
        List<Point> points = new() { new(0, 0), new(5, 5), new(2, 3), new(4, 2), new(7, 5) };
        string moves = "lrududuldrllludlrlld";

        RunSimulation(map, mappables, points, moves);
    }

    // Testing flying birds movement on bouncy map
    static void RunSimulation5()
    {
        BigBounceMap map = new(6, 6);
        List<IMappable> mappables = new() { new Birds("Eagles", 3, true) };
        List<Point> points = new() { new(3, 3) };
        string moves = "urudlrruudddlulrr";

        RunSimulation(map, mappables, points, moves);
    }

    // Testing non flying birds movement on bouncy map
    static void RunSimulation6()
    {
        BigBounceMap map = new(5, 5);
        List<IMappable> mappables = new() { new Birds("Ostriches1", 8, false), new Birds("Ostriches2", 8, false), new Birds("Ostriches3", 8, false), new Birds("Ostriches4", 8, false) };
        List<Point> points = new() { new(0, 1), new(1, 4), new(4, 3), new(3, 0) };
        string moves = "urudlrruudddlulrrr";

        RunSimulation(map, mappables, points, moves);
    }

    // Testing logs
    static void RunSimulation7()
    {
        BigBounceMap map = new(8, 6);
        List<IMappable> mappables = new() { new Orc("Ugluk"), new Elf("Galadriel"), new Animals("Rabbits", 6), new Birds("Eagles", 3, true), new Birds("Ostriches", 8, false) };
        List<Point> points = new() { new(0, 0), new(5, 5), new(2, 3), new(4, 2), new(7, 5) };
        string moves = "lrududuldrllludlrlld";

        RunSimulationHistory(map, mappables, points, moves);
    }


    // Function to run simulations
    static void RunSimulation(Map map, List<IMappable> mappables, List<Point> points, string moves)
    {
        Simulation simulation = new(map, mappables, points, moves);
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

            Console.Write($"{simulation.CurrentMappable.ToString()} {simulation.CurrentMappable.Position} goes {simulation.CurrentMoveName}:\n");
            simulation.Turn();

            mapVisualizer.Draw();
            Console.WriteLine("Press any key to continue...\n");
        }

        Console.WriteLine("Simulation finished!");
    }


    //Function to run simulation history
    static void RunSimulationHistory(Map map, List<IMappable> mappables, List<Point> points, string moves)
    {
        Simulation simulation = new(map, mappables, points, moves);

        SimulationHistory simulationHistory = new(simulation);
        LogVisualizer logVisualizer = new(simulationHistory);

        Console.WriteLine("[LOGS] SIMULATION LOGS!\n");
        Console.WriteLine("[LOGS] Starting positions:");

        logVisualizer.Draw(0);
        Console.WriteLine("Press any key to continue...\n");

        Console.ReadKey(true);
        logVisualizer.Draw(4);
        Console.WriteLine("Press any key to continue...\n");

        Console.ReadKey(true);
        logVisualizer.Draw(9);
        Console.WriteLine("Press any key to continue...\n");

        Console.ReadKey(true);
        logVisualizer.Draw(14);
        Console.WriteLine("Press any key to continue...\n");

        Console.ReadKey(true);
        logVisualizer.Draw(19);
        Console.WriteLine("Press any key to continue...\n");
    }
}