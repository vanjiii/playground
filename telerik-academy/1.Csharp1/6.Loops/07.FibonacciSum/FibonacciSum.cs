using System;

class FibonacciSum
{
    static void Main()
    {
        Console.Title = "The Fibonacci sum";

        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            double sqrt5 = Math.Sqrt(5.0);
            double phi = (1 + sqrt5) / 2;
            sum += (int)((Math.Pow(phi, i + 1) - Math.Pow(1 - phi, i + 1)) / sqrt5);
        }
        Console.WriteLine(sum);        
    }
}

/*
Write a program that reads a number N and calculates the sum of the first N members of the sequence of 
Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
*/