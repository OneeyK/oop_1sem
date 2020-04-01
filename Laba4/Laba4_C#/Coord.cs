using System;
namespace Laba4
{
    public class Coord
    {
        double x, y;
        public Coord()
        {
        }

        public Coord(double start, double end)
        {
            x = start;
            y = end;
        }

        public Coord(Coord previousCoord)
        {
            x = previousCoord.x;
            y = previousCoord.y;
        }

        public double GetLength()
        {
            return Math.Abs(this.y) - Math.Abs(this.x);
        }

        public void GetInfo()
        {
            Console.WriteLine($"X-position is {this.x} and Y-position is {this.y}");
        }

        public static Coord operator + (Coord L1, Coord L2)
        {
            Coord result = new Coord();
            result.x = L1.x + L2.x;
            result.y = L1.y + L2.y;
            return result;
        }

        public static Coord operator *(Coord L1, int a)
        {
            Coord result = new Coord();
            result.x = L1.x * a;
            result.y = L1.y * a;
            return result;
        }
    }
}
