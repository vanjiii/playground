using System;
using System.Linq;
/*
 Write a program that reads two integer numbers N and K and an array of N elements from the console. 
 * Find in the array those K elements that have maximal sum.
 */
class SumInArray
{
    static void Main()
    {
        Console.Write("Enter array's length: ");
        int N = int.Parse(Console.ReadLine());
        Console.Write("K elements: ");
        int K = int.Parse(Console.ReadLine());

        int[] intArray = new int[N];
        Console.WriteLine("The array: ");
        for (int ii = 0; ii < N; ii++)
        {
            intArray[ii] = int.Parse(Console.ReadLine());
        }

        //int[] sortArray = new int[K];
        Array.Sort(intArray);

        Console.WriteLine("The numbers are: ");
        for (int i = N - 1; i > (N - K -1); i--)
        {
            Console.Write(intArray[i] + " ");
        }
        
    }
}
