using System;
using System.Numerics;
/*
 * Write a method that adds two positive integer numbers represented as arrays of digits
 * (each array element arr[i] contains a digit; the last digit is kept in arr[0]).
 * Each of the numbers that will be added could have up to 10 000 digits.
 */
class AddsPositiveNumbers
{
    static string AddPositiveNumber(BigInteger number)
    {
        Random rnd = new Random();
        int firstArrayLength = rnd.Next(1, 10000);
        int secondArrayLength = rnd.Next(1, 10000);
        int[] firstArr = new int[firstArrayLength];
        int[] secondArr = new int[secondArrayLength];

        for (int i = 0; i < firstArrayLength; i++)
        {
            firstArr[i] = rnd.Next(10);
        }

        for (int j = 0; j < secondArrayLength; j++)
        {
            secondArr[j] = rnd.Next(10);
        }
        string newNum = Convert.ToString(number);

        for (int ii = firstArrayLength - 1; ii >= 0; ii--)
        {
            newNum = newNum + Convert.ToString(firstArr[ii]);
        }

        for (int jj = secondArrayLength - 1; jj >= 0; jj--)
        {
            newNum = newNum + Convert.ToString(secondArr[jj]);
        }
        return newNum;
    }
    static void Main()
    {
        Console.Write("enter a number to manupilate: ");
        int N = int.Parse(Console.ReadLine());

        string res = AddPositiveNumber(N);
        Console.WriteLine("result: ");
        Console.WriteLine(res);

    }
}