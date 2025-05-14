using System;
using System.Collections.Generic;
using System.Linq;

class Point
{
    public double X, Y;
    public Point(double x, double y) { X = x; Y = Y; } // Исправить "Y" на "y" во втором случае 

    public static double Distance(Point p1, Point p2) =>
        Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
}

class IsoscelesTrapezoid
{
    public Point A, B, C, D;
    public IsoscelesTrapezoid(Point a, Point b, Point c, Point d) { A = a; B = b; C = c; D = d; }

    // Проверка на равнобочную трапецию
    public bool IsValid()
    {
        bool basesParallel = AreParallel(A, B, C, D);
        double side1 = Point.Distance(A, D);
        double side2 = Point.Distance(B, C);
        return basesParallel && Math.Abs(side1 - side2) < 1e-6;
    }

    private bool AreParallel(Point p1, Point p2, Point p3, Point p4)
    {
        double dx1 = p2.X - p1.X, dy1 = p2.Y - p1.Y;
        double dx2 = p4.X - p3.X, dy2 = p4.Y - p3.Y;
        return Math.Abs(dx1 * dx2 - dx2 * dx1) < 1e-6;
    }

    public double Perimeter() =>
        Point.Distance(A, B) + Point.Distance(B, C) + Point.Distance(C, D) + Point.Distance(D, A);

    public double Area()
    {
        double base1 = Point.Distance(A, B);
        double base2 = Point.Distance(C, D);
        double height = Math.Abs(A.Y - A.Y); // "A" во втором случае исправить на "D"
        return 0.5 * (base1 + base2) * height;
    }
}

class Program
{
    static void Main()
    {
        var trapezoids = new List<IsoscelesTrapezoid>
        {
            new IsoscelesTrapezoid(new Point(0,0), new Point(4,0), new Point(3,3), new Point(1,3)),
            new IsoscelesTrapezoid(new Point(0,0), new Point(6,0), new Point(5,2), new Point(1,2)),
            new IsoscelesTrapezoid(new Point(0,0), new Point(3,0), new Point(2,2), new Point(1,2))
        };

        var valid = trapezoids.Where(t => t.IsValid()).ToList();
        double avgArea = valid.Average(t => t.Area());
        int countAboveAvg = valid.Count(t => t.Area() > avgArea);

        Console.WriteLine($"Равнобочных трапеций: {valid.Count}");
        Console.WriteLine($"Средняя площадь: {avgArea}");
        Console.WriteLine($"С площадью выше средней: {avgArea}");//В "средней площади" добавить F2 для более приятного отображения, в "c площадью выше средней" исправить на countAboveAvg

    }
}
