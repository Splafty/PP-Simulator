using System.Security.Cryptography.X509Certificates;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab5a();
        Console.ReadLine();
    }

    static void Lab5a()
    {
        Console.WriteLine("\n[TEST] CREATING RECTANGLES WITH LOOSE COORDINATES");
        Rectangle rect1 = new Rectangle(10, 5, 20, 15);
        Console.WriteLine("Created rectangle: " + rect1);

        Rectangle rect2 = new Rectangle(20, 15, 10, 5);
        Console.WriteLine("Created rectangle: " + rect2);

        try
        {
            Rectangle rect3 = new Rectangle(10, 5, 10, 5);
            Console.WriteLine("Created rectangle: " + rect3);

        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
        }

        try
        {
            Rectangle rect4 = new Rectangle(1, 1, 2, 2);
            Console.WriteLine("Created rectangle: " + rect4);

        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
        }


        Console.WriteLine("\n[TEST] CREATING RECTANGLES WITH POINTS");
        Point p1 = new Point(10, 5);
        Point p2 = new Point(20, 15);
        Rectangle rect5 = new Rectangle(p1, p2);
        Console.WriteLine("Created rectangle: " + rect5);

        Rectangle rect6 = new Rectangle(p2, p1);
        Console.WriteLine("Created rectangle: " + rect6);

        try
        {
            Rectangle rect7 = new Rectangle(p1, p1);
            Console.WriteLine("Created rectangle: " + rect7);

        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
        }

        Point p3 = new Point(1, 1);
        Point p4 = new Point(2, 2);
        try
        {
            Rectangle rect7 = new Rectangle(p3, p4);
            Console.WriteLine("Created rectangle: " + rect7);

        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
        }

        Point p5 = new Point(25, 25);
        Console.WriteLine($"Rectangle {rect1} contains point {p5}: {rect1.Contains(p5)}");

        Point p6 = new Point(10, 10);
        Console.WriteLine($"Rectangle {rect1} contains point {p6}: {rect1.Contains(p6)}");
    }
}