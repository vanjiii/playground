using System;
    class PrintInterval
    {
        static void Main()
        {
            Console.Title = "Exercises 8.";

            uint n;

            Console.Write("Enter the end of the sequence: ");
            string j = Console.ReadLine();

            if (uint.TryParse(j, out n))
            {
                Console.WriteLine("This is the inteval: ");

                for (uint i = 0; i < n; i++)
                {
                    Console.WriteLine(i + 1);
                }
            }
            else
            {
                Console.WriteLine("This is not a positive number.");
            }
          
        }
    }
/*
 Write a program that reads an integer number n from the console and prints all the numbers in the interval [1..n], each on a single line.
*/