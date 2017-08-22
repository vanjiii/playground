using System;
    class Circle
    {
        static void Main()
        {
            Console.Title = "Exercises 2.";
            double radius, circleArea, circlePerimeter;
            Console.Write("Enter radius: ");
            string rad = Console.ReadLine();
            double.TryParse(rad, out radius);
            circleArea = Math.PI * radius * radius;
            circlePerimeter = 2 * Math.PI * radius;
            Console.WriteLine("The area of circle with radius {0:0.00} cm. is: {1:0.00}, and the perimeter is : {2:0.00}", radius, circleArea, circlePerimeter);
        }
    }
/*
Write a program that reads the radius r of a circle and prints its perimeter and area.

*/