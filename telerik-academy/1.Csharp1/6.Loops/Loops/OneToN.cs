using System;
class OneToN
{
    static void Main()
    {
        Console.Title = "One to N.";
        int n;
        do
        {
            Console.Write("Enter positive n: ");
            n = int.Parse(Console.ReadLine());
        } while (n < 0);

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(i + 1);
        }
    }
}

/*
Write a program that prints all the numbers from 1 to N.
*/