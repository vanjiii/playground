using System;

class TheMatrix
{
    static void Main()
    {
        Console.Title = "The matrix";

        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());

        int endLine = n;

        for (int i = 1; i <= n; i++)
        {
            for (int j = i; j <= endLine; j++)
            {
               Console.Write(j + "    ");
               
            }
            Console.WriteLine();
            endLine++;            
        }
    }
}

/*
Write a program that reads from the console a positive integer number N (N < 20) and outputs a matrix like the following:
*/