﻿using SimConsole;
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
        RunSimulation3();
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
        SmallTorusMap map = new(8,6);
        List<IMappable> mappables = new() { new Orc("Ugluk"), new Elf("Galadriel"), new Animals("Rabbits", 6), new Birds("Eagle", 3, true), new Birds("Ostrich", 8, false) };
        List<Point> points = new() { new(0, 0), new(5, 5), new(2, 3), new (4, 2), new (1, 1)};
        string moves = "uldrddrlrrululr";

        RunSimulation(map, mappables, points, moves);
    }

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
}