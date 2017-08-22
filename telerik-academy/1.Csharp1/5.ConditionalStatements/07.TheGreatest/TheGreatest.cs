using System;
class TheGreatest
{
    static void Main()
    {
        Console.Title = "Exercise 7";

        Console.Write("Enter the first number: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter the second number: ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Enter the third number: ");
        int c = int.Parse(Console.ReadLine());
        Console.Write("Enter the fourth number: ");
        int d = int.Parse(Console.ReadLine());
        Console.Write("Enter the fifth number: ");
        int e = int.Parse(Console.ReadLine());

        int number;
        if (a > b)
        {
            number = a;
        }
        else if (b > c)
        {
            number = b;
        }
        else if (c > d)
        {
            number = c;
        }
        else if (d > e)
        {
            number = d;
        }
        else
	    {
            number = e;
	    }
        Console.WriteLine("The biggest among them is: " + number);
    }
}
/*
Write a program that finds the greatest of given 5 variables.

*/