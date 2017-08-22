using System;
    class QuadraticEquation
    {
        static void Main()
        {
            Console.Title = "Exercises 6.";

            int coeffA, coeffB, coeffC, diss;
            double x1, x2;

            Console.Write("Enter a: ");
            string a = Console.ReadLine();

            Console.Write("Enter b: ");
            string b = Console.ReadLine();

            Console.Write("Enter c: ");
            string c = Console.ReadLine();

            int.TryParse(a, out coeffA);
            int.TryParse(b, out coeffB);
            int.TryParse(c, out coeffC);

            diss = (coeffB * coeffB) - (4 * coeffA * coeffC);

            if (diss >= 0)
            {
                x1 = (-coeffB - Math.Sqrt(diss)) / (2 * coeffA);
                x2 = (-coeffB + Math.Sqrt(diss)) / (2 * coeffA);
                Console.WriteLine("x1: " + x1 + "; \n\rx2" + x2);
            }
            else
            {
                Console.WriteLine("The equation have no real roots!!!");
            }
        }
    }
/*
Write a program that reads the coefficients a, b and c of a quadratic equation ax2+bx+c=0 and solves it (prints its real roots).
*/