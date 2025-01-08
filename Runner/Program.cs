using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;
using Simulator.Maps;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Starting Simulator!\n");
        //Lab5a();
        //Lab5b();
        //Console.ReadLine();


        // SERIALIZATION ORCS/ELFS
        //var jsonOptions = new JsonSerializerOptions { WriteIndented = true };

        //Orc o1 = new("Gorbag", 3, 5);
        //string json = JsonSerializer.Serialize(o1, jsonOptions);
        //Console.WriteLine(json);

        //Orc? o2 = JsonSerializer.Deserialize<Orc>(json);
        //Console.WriteLine(o2);


        // SERIALIZATION POINT
        //Point p1 = new(2, 4);
        //string json = JsonSerializer.Serialize(p1);
        //Console.WriteLine(json); // {}

        //Point p2 = JsonSerializer.Deserialize<Point>(json);
        //Console.WriteLine(p2);

        // SERIALIZATION 2 SAME + preserve
        //var options = new JsonSerializerOptions
        //{
        //    WriteIndented = true,
        //    ReferenceHandler = ReferenceHandler.Preserve
        //};

        //Orc o1 = new("Gorbag", 3, 5);
        //Orc o2 = new("Morgash", 2, 7);

        //List<Orc> orcs = new() { o1, o2, o1 };
        //Console.WriteLine(orcs[0] == orcs[2]); // True

        //string json = JsonSerializer.Serialize(orcs, options);
        //Console.WriteLine("\nJSON:");
        //Console.WriteLine(json);

        //List<Orc> deserialized =
        //    JsonSerializer.Deserialize<List<Orc>>(json, options)!;

        //Console.Write("\nReference preserved:");
        //Console.WriteLine(deserialized[0] == deserialized[2]);

        // SERIALIZATION POLIOMORFIC
        //var options = new JsonSerializerOptions { WriteIndented = true };

        //List<Creature> creatures = [
        //    new Orc("Gorbag", 3, 5),
        //    new Elf("Legolas", 2, 7)
        //];
        //string json = JsonSerializer.Serialize(creatures, options);
        //Console.WriteLine("\nJSON:");
        //Console.WriteLine(json);

        //List<Creature> deserialized =
        //    JsonSerializer.Deserialize<List<Creature>>(json, options)!;

        //Console.WriteLine("\nPolimorfic OK:");
        //Console.WriteLine(deserialized[0] is Orc);
        //Console.WriteLine(deserialized[1] is Elf);

        // SERIALIZATION CD
        var options = new JsonSerializerOptions { WriteIndented = true };

        List<IMappable> mapables = [
            new Orc("Gorbag", 3, 5),
            new Elf("Elandor", 2, 7),
            new Animals { Description = "Rasbbits", Size = 10 },
            new Birds { Description = "Eagles", Size = 15 },
            new Birds { Description = "Emu", Size = 8, CanFly = false }
        ];

        string json = JsonSerializer.Serialize(mapables, options);
        Console.WriteLine("\nJSON:");
        Console.WriteLine(json);

        List<IMappable> deserialized =
            JsonSerializer.Deserialize<List<IMappable>>(json, options)!;
    }

    static void Lab5a()
    {
        Console.WriteLine("\n[TEST] CREATING RECTANGLES WITH LOOSE COORDINATES");
        Rectangle rect1 = new Rectangle(10, 5, 20, 15);
        Console.WriteLine("Created rectangle with coordinates in right order: " + rect1);

        Rectangle rect2 = new Rectangle(20, 15, 10, 5);
        Console.WriteLine("Created rectangle with coordinates in wrong order: " + rect2);

        try
        {
            Rectangle rect3 = new Rectangle(10, 5, 10, 5);
            Console.WriteLine("Created rectangle: " + rect3);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
        }

        // Part 2 of the given exercise (SmallSquareMap) checks the minimum size,
        //try
        //{
        //    Rectangle rect4 = new Rectangle(1, 1, 2, 2);
        //    Console.WriteLine("Created rectangle: " + rect4);
        //}
        //catch (ArgumentException ex)
        //{
        //    Console.WriteLine("Exception caught: " + ex.Message);
        //}


        Console.WriteLine("\n[TEST] CREATING RECTANGLES WITH POINTS");
        Point p1 = new Point(10, 5);
        Point p2 = new Point(20, 15);
        Rectangle rect5 = new Rectangle(p1, p2);
        Console.WriteLine("Created rectangle with points in right order: " + rect5);

        Rectangle rect6 = new Rectangle(p2, p1);
        Console.WriteLine("Created rectangle with points in wrong order: " + rect6);

        try
        {
            Rectangle rect7 = new Rectangle(p1, p1);
            Console.WriteLine("Created rectangle: " + rect7);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
        }

        // Part 2 of the given exercise (SmallSquareMap) checks the minimum size,
        //Point p3 = new Point(1, 1);
        //Point p4 = new Point(2, 2);
        //try
        //{
        //    Rectangle rect7 = new Rectangle(p3, p4);
        //    Console.WriteLine("Created rectangle: " + rect7);
        //}
        //catch (ArgumentException ex)
        //{
        //    Console.WriteLine("Exception caught: " + ex.Message);
        //}

        Point p5 = new Point(25, 25);
        Console.WriteLine($"Rectangle {rect1} contains point {p5}: {rect1.Contains(p5)}");

        Point p6 = new Point(10, 10);
        Console.WriteLine($"Rectangle {rect1} contains point {p6}: {rect1.Contains(p6)}");
    }


    static void Lab5b()
    {
        int size = 12;
        Console.WriteLine($"\n[TEST] CREATING SMALLSQUAREMAP WITH SIZE {size}x{size}");
        SmallSquareMap map = new SmallSquareMap(size);


        Console.WriteLine($"Exist method:");
        Point p1 = new Point(-1, -1);
        Console.WriteLine($"Does point {p1} exist: {map.Exist(p1)}");
        Point p2 = new Point(6, 6);
        Console.WriteLine($"Does point {p2} exist: {map.Exist(p2)}");
        Point p3 = new Point(11, 11);
        Console.WriteLine($"Does point {p3} exist: {map.Exist(p3)}");
        Point p4 = new Point(12, 12);
        Console.WriteLine($"Does point {p4} exist: {map.Exist(p4)}");


        Console.WriteLine("\nNext method:");
        foreach (Direction direction in Enum.GetValues(typeof(Direction)))
        {
            Console.WriteLine($"Next point from {p2} in '{direction}' direction: {map.Next(p2, direction)}");
        }

        Console.WriteLine($"Next point from {p3} in 'Up' direction (edge): {map.Next(p3, Direction.Up)}");
        Console.WriteLine($"Next point from {p3} in 'Right' direction (edge): {map.Next(p3, Direction.Right)}");

        
        Console.WriteLine("\nNextDiagonal method:");
        foreach (Direction direction in Enum.GetValues(typeof(Direction)))
        {
            Console.WriteLine($"Next diagonal point from {p2} in '{direction}' direction: {map.NextDiagonal(p2, direction)}");
        }

        Console.WriteLine($"Next diagonal point from {p3} in 'Up' direction (edge): {map.NextDiagonal(p3, Direction.Up)}");
        Console.WriteLine($"Next diagonal point from {p3} in 'Right' direction (edge): {map.NextDiagonal(p3, Direction.Right)}");


        Console.WriteLine("\nSmallSquareMap creation:");
        try
        {
            SmallSquareMap map1 = new SmallSquareMap(4);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
        }

        try
        {
            SmallSquareMap map2 = new SmallSquareMap(21);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
        }
    }
}