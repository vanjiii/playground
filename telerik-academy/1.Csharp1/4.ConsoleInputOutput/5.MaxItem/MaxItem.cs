using System;
    class MaxItem
    {
        static void Main()
        {
            Console.Title = "Exercises 5.";

            int firstNumber, secondNumber;

            Console.Write("Enter number: ");
            string i = Console.ReadLine();
            int.TryParse(i, out firstNumber);

            Console.Write("Enter number: ");
            string j = Console.ReadLine();
            int.TryParse(j, out secondNumber);

            int maxNumber = Math.Max(firstNumber, secondNumber);

            Console.WriteLine("The max member among {0} and {1} is: {2}", firstNumber, secondNumber, maxNumber);

        }
    }
/*
Write a program that gets two numbers from the console and prints the greater of them. Don’t use if statements.
*/