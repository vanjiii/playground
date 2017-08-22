using System;
using System.Linq;
/*
 Sorting an array means to arrange its elements in increasing order. Write a program to sort an array. Use the "selection sort" algorithm:
 * Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.
 */
class SelectionSort
{
    static void Main()
    {
        Console.Write("Enter array's length: ");
        int N = int.Parse(Console.ReadLine());

        int[] intArray = new int[N];
        Console.WriteLine("Enter the elements of the array: ");
        for (int i = 0; i < N; i++)
        {
            intArray[i] = int.Parse(Console.ReadLine());
        }

        //int localSmallestElement = 0;
        for (int i = 0; i < N; i++)
        {
            //localSmallestElement = intArray[i];
            for (int j = i + 1; j < N; j++)
            {
                if (intArray[i] > intArray[j])
                { 
                    //swap the elements
                    intArray[j] ^= intArray[i];
                    intArray[i] ^= intArray[j];
                    intArray[j] ^= intArray[i];
                }
            }
        }
        Console.WriteLine("The sorted array: ");
        for (int ii = 0; ii < N; ii++)
        {
            Console.WriteLine(intArray[ii]);
        }

    }
}
