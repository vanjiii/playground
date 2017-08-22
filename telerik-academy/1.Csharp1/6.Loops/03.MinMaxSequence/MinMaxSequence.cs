using System;

class MinMaxSequence
{
    static void Main()
    {
        Console.Title = "Min and max element of sequence";

        Console.WriteLine("Enter a sequence of numbers.");
        Console.Write("Please separate them with point or comma: ");
        string numbers = Console.ReadLine();

        char[] separators = new char[] { ' ', '.', ',' };
        string[] stringNumbers = numbers.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        int[] intNumbers= new int [stringNumbers.Length];
        int maxNum = 0, minNum = 0;

        for (int i = 0; i < intNumbers.Length; i++)
        {
            intNumbers[i] = int.Parse(stringNumbers[i]);
            if (maxNum < intNumbers[i])
            {
                maxNum = intNumbers[i];
            }
            if (minNum > intNumbers[i])
            {
                minNum  = intNumbers[i];
            }
        }

        Console.WriteLine("The min number is : " + minNum + ", and the max is:  " + maxNum);
    }
}
/*
Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.
*/