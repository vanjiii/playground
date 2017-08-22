using System;
class PlusOrMinus
{
    static void Main()
    {
        Console.Title = "Exercise 2.";

        Console.Write("Enter the first number: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter the second number: ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Enter the third number: ");
        int c = int.Parse(Console.ReadLine());

        if (a == 0 || b == 0 || c == 0)
        {
            Console.WriteLine("The result is zero.");
        }
        else if (a < 0 || b < 0 || c < 0)
        {
            Console.WriteLine("The result is negative.");
        }
        else
        {
            Console.WriteLine("The result is positive.");
        }
    }
}
/*
Write a program that shows the sign (+ or -) of the product of three real numbers without calculating it. Use a sequence of if statements.

*/