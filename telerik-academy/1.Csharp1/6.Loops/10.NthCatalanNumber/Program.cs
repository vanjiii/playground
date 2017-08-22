using System;

class Program
{
    static void Main()
    {
        Console.Title = "Nth Catalan number";

        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());

        int dividend = 1, divisor = 1;

        for (int i = n + 2; i <= 2 * n; i++)
        {
            dividend *= i;
        }
        for (int j = 1; j <= n; j++)
        {
            divisor *= j;
        }

        Console.WriteLine("C" + n + ": " + dividend/divisor);

    }
}

/*
Write a program to calculate the Nth Catalan number by given N.
 * 
 *      for N = 3 we have
 *      C3 = (2*3)! / (3+1)!*3!  =  5
 *      
 *      for N = 4 => C4 = 14;
*/