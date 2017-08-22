using System;

class GreatestCommonDivisor
{
    static void Main()
    {
        Console.Title = "Euclidiean algorithm";

        Console.WriteLine("Enter the two numbers..");
        Console.Write("Enter max number: ");
        int maxNum = int.Parse(Console.ReadLine());
        Console.Write("Enter min number: ");
        int minNum = int.Parse(Console.ReadLine());

        int helpNum;

        while (minNum != maxNum)
        {
            if (minNum > maxNum)
            {
                helpNum = minNum;
                minNum = maxNum;
                maxNum = helpNum;
            }
            maxNum = maxNum - minNum;
        }
        Console.WriteLine(maxNum);
    }
}

/*
Write a program that calculates the greatest common divisor (GCD) of given two numbers. Use the Euclidean algorithm (find it in Internet).
*/