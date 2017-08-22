using System;
    class FibonacciSequence
    {
        static void Main()
        {
            Console.Title = "Exercises 9.";

            decimal j;
            
            for (int i = 0; i < 100; i++)
            {
                //This is Binet's formula.
                double sqrt5 = Math.Sqrt(5.0);
                double phi = (1 + sqrt5) / 2;
                j = (int)((Math.Pow(phi, i + 1) - Math.Pow(1 - phi, i + 1)) / sqrt5);

                Console.WriteLine("{0:0}", j);
            }
            
        }
    }
/*
 * Write a program to print the first 100 members of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
*/