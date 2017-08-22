using System;
    class IntegerBetween
    {
        static void Main()
        {
            Console.Title = "Exercises 4.";

            uint firstNumber, secondNumber;
            int count = 0;

            Console.Write("Enter first number: ");
            string fir = Console.ReadLine();
            uint.TryParse(fir, out firstNumber);

            Console.Write("Enter second number : ");
            string sec = Console.ReadLine();
            uint.TryParse(sec, out secondNumber);

            while (firstNumber <= secondNumber)
            {
                if (firstNumber % 5 == 0)
                {
                    count++;
                }
                firstNumber++;
            }
            Console.WriteLine("p({0}, {1}) = {2}", fir, secondNumber, count);
        }
    }
/*
Write a program that reads two positive integer numbers and prints how many numbers p exist between them such that the reminder of the division by 5 is 0 (inclusive). Example: p(17,25) = 2.
*/