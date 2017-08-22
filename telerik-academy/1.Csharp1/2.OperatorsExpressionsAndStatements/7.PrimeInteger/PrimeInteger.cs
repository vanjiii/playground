using System;
    class PrimeInteger
    {
        static void Main()
        {
            Console.WriteLine("Enter a positive integer: ");
            string i = Console.ReadLine();
            int positiveNumber; 
            int.TryParse(i, out positiveNumber);

            if (positiveNumber % 2 != 0 && positiveNumber % 3 != 0 && positiveNumber % 5 != 0 && positiveNumber % 7 != 0)
            {
                Console.WriteLine("The number is prime");
            }
            else
            {
                Console.WriteLine("the number is NOT prime");
            }
        }
    }
/*
 Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.
 */