using System;
/*
 *Write methods that calculate the surface of a triangle by given:
 *  Side and an altitude to it; Three sides; Two sides and an angle between them. 
 * Use System.Math.
 */
class SurfaceOfTriangle
    {
        static void Main()
        {
            Console.Write("Enter a: ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Enter b: ");
            double b = double.Parse(Console.ReadLine());

            Console.Write("Enter c: ");
            double c = double.Parse(Console.ReadLine());

            Console.Write("Enter h: ");
            double h = double.Parse(Console.ReadLine());

            Console.Write("Enter angle (in degree): ");
            double angle = double.Parse(Console.ReadLine());

            SurfaceBySideAndAltitude(a, h);
            SurfaceByThreeSides(a, b, c);
            SurfaceByAngleAndTwoSides(a, b, angle);
        }

        private static void SurfaceByAngleAndTwoSides(double a, double b, double angle)
        {
            double ang = Convert.ToDouble(Math.PI * angle / 180);

            Console.WriteLine("Angle and two sides: " + (a * b * ang) / 2);
        }

        private static void SurfaceByThreeSides(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            double surface = Convert.ToDouble(Math.Sqrt(p * (p - a) * (p - b) * (p - c)));
            Console.WriteLine("Three sides: " + surface);
        }

        private static void SurfaceBySideAndAltitude(double a, double h)
        {
            double suurface = (a * h) / 2; 
            Console.WriteLine("Side and angle: " + suurface);
        }
    }