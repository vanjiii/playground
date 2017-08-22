using System;
class CalculateSum
{
    static void Main()
    {
        Console.Title = "Damn long sum.";

        //input
        Console.Write("X: ");
        int x = int.Parse(Console.ReadLine());
        Console.Write("N: ");
        int n = int.Parse(Console.ReadLine());
        //transform the equation(sum) with less common divisor
        //the sum become => (1*x^n + 1!*x^n-1 + ...) / x^n
        double sum, divisor = Math.Pow(x,n), dividend = 0;
        int factorial = 1 ;

        //dividend =  1!*x^n-1 + ...
        for (int i = (n - 1); i >= 0; i--)
        {
            for (int j = 1; j <= (n - i); j++)
            {
                factorial *= j;
              
            }
            dividend += factorial * Math.Pow(x, (i));
        }
        //at the end add the missing 'x^n' to the nominator and divide
        sum = (dividend + Math.Pow(x,n))/ divisor;
        Console.WriteLine("The sum is: " + sum);

    }
}
/*
Write a program that, for a given two integer numbers N and X, calculates the sumS = 1 + 1!/X + 2!/X2 + … + N!/XN
*/