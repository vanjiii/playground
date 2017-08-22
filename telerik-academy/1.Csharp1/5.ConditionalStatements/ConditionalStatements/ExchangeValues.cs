using System;
    class ExchangeValues
    {
        static void Main()
        {
            Console.Title = "Exercise 1.";

            Console.Write("Enter The first number a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter the second number b: ");
            int b = int.Parse(Console.ReadLine());

            int c = b;

            if (a > b)
            {
                b = a;
                a = c;
                Console.WriteLine("a: " + a);
                Console.WriteLine("b: " + b);
            }
            else
            {
                Console.WriteLine("a: " + a);
                Console.WriteLine("b: " + b);
            }
        }
    }
/*
Write an if statement that examines two integer variables and exchanges their values if the first one is greater than the second one.
*/