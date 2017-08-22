using System;
    class PointInTheCircle
    {
        static void Main()
        {
            Console.WriteLine("Enter X coordinate: ");
            string X = Console.ReadLine();
            Console.WriteLine("Enter Y coordinate: ");
            string Y = Console.ReadLine();
            double coorX, coorY, circleRadius = 5;
            double.TryParse(X, out coorX);
            double.TryParse(Y, out coorY);
            if ((Math.Pow (coorX,2) + Math.Pow(coorY, 2)) <= Math.Pow(circleRadius,2))
            {
                Console.WriteLine("The point is in the circle.");
            }
            else
            {
                Console.WriteLine("It's outside the circle");
            }
        }
    }
/*
Write an expression that checks if given point (x,  y) is within a circle K(O, 5).
*/