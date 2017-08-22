using System;
class BiggestInteger
{
    static void Main(string[] args)
    {
        Console.Title = "Exercise 3.";

        Console.Write("Enter the first number: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter the second number: ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Enter the third number: ");
        int c = int.Parse(Console.ReadLine());

        int maxNumber = a;
        if (a < b)
        {
            maxNumber = b;
        }
        else if ( maxNumber < c )
        {
            maxNumber = c;
        }
        Console.WriteLine("The max number among them is: " + maxNumber);
    }
}
/*
 Write a program that finds the biggest of three integers using nested if statements.

 */