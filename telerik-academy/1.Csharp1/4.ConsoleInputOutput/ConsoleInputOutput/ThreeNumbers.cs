using System;
class ThreeNumbers
    {
        static void Main()
        {
            Console.Title = "Exercices 1";                      
            int firstNumber, secondNumber, thirdNumber;
            Console.Write("Enter the first number: ");
            string fN = Console.ReadLine();
            Console.Write("Enter the second number: ");
            string sN = Console.ReadLine();
            Console.Write("Enter the third number: ");
            string tN = Console.ReadLine();
            int.TryParse(fN, out firstNumber);
            int.TryParse(sN, out secondNumber);
            int.TryParse(tN, out thirdNumber);
            Console.WriteLine("The sum of {0}, {1} and {2} is: {3}", firstNumber, secondNumber, thirdNumber, firstNumber + secondNumber + thirdNumber);
        }
    }
/*
Write a program that reads 3 integer numbers from the console and prints their sum.
*/