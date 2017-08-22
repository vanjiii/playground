using System;
class DescendeOrder
{
    static void Main()
    {
        Console.Title = "Exercise 4.";

        Console.Write("Enter the first number: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter the second number: ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Enter the third number: ");
        int c = int.Parse(Console.ReadLine());

        int helpNumber;

        if (a > b)
        {

        }
        else
        {
            helpNumber = b;
            b = a;
            a = helpNumber;
        }
        if (a > c)
        {

        }
        else
        {
            helpNumber = c;
            c = a;
            a = helpNumber;
        }
        if (b > c)
        {

        }
        else
        {
            helpNumber = c;
            c = b;
            b = helpNumber;
        }

        Console.WriteLine("The three numbers in descending order: " + a + ", " + b + ", " + c);
    }
}
/*
Sort 3 real values in descending order using nested if statements.
*/