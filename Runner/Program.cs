using System.Security.Cryptography.X509Certificates;
using Simulator.Maps;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab5a();
        Lab5b();
        Console.ReadLine();
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