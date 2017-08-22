using System;
/*
 * Write a program, that reads from the console an array of N integers and an integer K,
 * sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 
 */
class BinSearch
{
    static void Main()
    {
        //the input
        Console.Write("Enter length of the array: ");
        int N = int.Parse(Console.ReadLine());
        int[] arrayOfIntegers = new int[N];
        Console.WriteLine("Enter the array: ");
        for (int i = 0; i < N; i++)
        {
            arrayOfIntegers[i] = int.Parse(Console.ReadLine());
        }
        Console.Write("Enter the integer K: ");
        int K = int.Parse(Console.ReadLine());

        //sorting...
        Array.Sort(arrayOfIntegers);

        //linear searching
        int kElement = Array.BinarySearch(arrayOfIntegers, K);
        int maxElem = 0;

        if (kElement > 0)
        {
            maxElem = arrayOfIntegers[kElement];
        }
        else
        {
            kElement = ~kElement;
            kElement--;
        }

        //Console.WriteLine("k element: " + kElement);
        //Console.WriteLine("bin: " + Convert.ToString(kElement, 2));

        //print
        Console.WriteLine("the sorted array: ");
        for (int i = 0; i < N; i++)
        {
            Console.Write(arrayOfIntegers[i] + "\t");
        }
        Console.WriteLine();
        Console.WriteLine("the max element(<= K) is: " + arrayOfIntegers[kElement]);
    }
}

