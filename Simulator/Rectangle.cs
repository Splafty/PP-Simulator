using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

internal class Rectangle
{
    // Properties
    public readonly int X1, Y1, X2, Y2;


    // Constructors
    public Rectangle(int x1, int y1, int x2, int y2)
    {
        if (x1 == x2 || y1 == y2)
        {
            throw new ArgumentException("Rectangle cannot have zero width or height.");
        }

        // I think that during the lesson we established that, in the created rectangle/map, we must be able to go in any given direction
        // So if we have a min 3x3 grid and the character "stands" in the middle of it, we have an option to test all the directions
        //if (Math.Abs(x1 - x2) < 3 || Math.Abs(y1 - y2) < 3)
        //{
        //    throw new ArgumentException("Rectangle has to be at least 3x3 in size.");
        //}
        // Part 2 of the given exercise (SmallSquareMap) checks the minimum size, commenting for now, may use later

        if (x1 > x2)
        {
            int valueholder = x1;
            x1 = x2;
            x2 = valueholder;
        }

        if (y1 > y2)
        {
            int valueholder = y1;
            y1 = y2;
            y2 = valueholder;
        }

        X1 = x1;
        Y1 = y1;
        X2 = x2;
        Y2 = y2;
    }

    public Rectangle(Point p1, Point p2) : this(p1.X, p1.Y, p2.X, p2.Y) { }


    // Methods
    public bool Contains(Point point)
    {
        if (point.X >= X1 && point.X <= X2 && point.Y >= Y1 && point.Y <= Y2)
        {
            return true;
        }
        return false;
    }

    public override string ToString() => $"({X1}, {Y1}):({X2}, {Y2})";
}
