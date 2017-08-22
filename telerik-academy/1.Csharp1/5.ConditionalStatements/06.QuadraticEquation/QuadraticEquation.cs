using System;
class QuadraticEquation
{
    static void Main()
    {
        Console.Title = "Exercise 6.";

        Console.Write("Enter a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter c: ");
        double c = double.Parse(Console.ReadLine());

        double discr, x1 = 0, x2 = 0;

        discr = (b * b) - (4 * a * c);
        if (discr < 0)
        {
            Console.WriteLine("We have no real roots!");
        }
        else if (discr > 0)      
        {
            x1 = (-b + Math.Sqrt(discr)) / (2 * a);
            x2 = (-b - Math.Sqrt(discr)) / (2 * a);
            Console.WriteLine("a: {0}, b: {1}", x1, x2);
        }
        else
        {
            x1 = x2 = -b / (2 * a);
            Console.WriteLine("x1 = x2 = " + x1);
        }
        
    }
}
/*
Write a program that enters the coefficients a, b and c of a quadratic equation
a*x2 + b*x + c = 0
and calculates and prints its real roots. Note that quadratic equations may have 0, 1 or 2 real roots.

*/