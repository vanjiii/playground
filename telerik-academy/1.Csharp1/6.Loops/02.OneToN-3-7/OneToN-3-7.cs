using System;

class OneToN
{
    static void Main()
    {
        Console.Title = "One to N, NOT devided by 3, 7";

        int n;
        do
        {
            Console.Write("Enter positive n: ");
            n = int.Parse(Console.ReadLine());
        } while (n < 0);

        for (int i = 1; i <= n; i++)
        {
            if (!(i % 3 == 0) && !(i % 7 == 0))
            {
               Console.WriteLine(i);
            }
            
        }
    }
}
/*
Write a program that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time.
*/