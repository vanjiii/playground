using System;
using System.Numerics;
/*
 * Write a program to calculate n! for each n in the range [1..100].
 * Hint: Implement first a method that multiplies a number represented as array of digits by given integer number. 
 */
class Factorial
{
    static int MultipliesNumberByArray(int[] someArr, int num)
    {
        //method that multiplies a number represented as array of digits by given integer number
        int factor = 1;
        string stringFactor = "";
        int remainder = 0;
        for (int i = someArr.Length - 1; i >= 0; i--)
        {
            factor = (num * someArr[i]) % 10;
            factor += remainder;
            remainder = (num * someArr[i]) / 10;
            stringFactor += Convert.ToString(factor);
        }

        string tempString = "";
        for (int ii = 0; ii < stringFactor.Length; ii++)
        {
            tempString += stringFactor[stringFactor.Length - (ii + 1)];
        }
        return Convert.ToInt32(tempString);
    }
    static BigInteger FactorialN (BigInteger number)
    {
        BigInteger fac = 1;
        for (int i = 1; i <= number; i++)
        {
            fac *= i;
        }
        return fac;
    }
    static void Main()
    {
        //initializing
        int[] n = new int[100];
        for (int i = 0; i < n.Length; i++)
        {
            n[i] = i + 1;
            Console.WriteLine(FactorialN(n[i]));
        }

        /*
        Console.Write("Given number: ");
        int givenNumber = int.Parse(Console.ReadLine());

        
        int res = MultipliesNumberByArray(n, givenNumber);
        Console.WriteLine("result: " + res);
        */
    }
}