using System;
    class TrapezoidArea
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a: ");
            string a = Console.ReadLine();
            Console.WriteLine("Enter b: ");
            string b = Console.ReadLine();
            Console.WriteLine("Enter height: ");
            string h = Console.ReadLine();

            double sideA, sideB, height, trapArea;
            double.TryParse(a, out sideA);
            double.TryParse(b, out sideB);
            double.TryParse(h, out height);

            trapArea = (sideA + sideB) * height * 0.5;
            Console.WriteLine("The area of trapezoid with a: {0} , b: {1} and h: {2}  is: {3}", sideA, sideB, height, trapArea);
        }
    }
/*
 Write an expression that calculates trapezoid's area by given sides a and b and height h.
 */