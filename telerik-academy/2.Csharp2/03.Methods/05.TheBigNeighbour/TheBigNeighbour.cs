using System;
/*
 * Write a method that checks if the element at given position in given array of integers is bigger than its two neighbors (when such exist).
 */
class TheBigNeighbour
{
    static bool GetBigNeighbour(int[] arr, int currentPosition)
    {
        if (currentPosition == 0)
        {
             if ((arr[currentPosition] > arr[currentPosition + 1]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (currentPosition == arr.Length - 1)
        {
            if ((arr[currentPosition] > arr[currentPosition - 1]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if ((arr[currentPosition] > arr[currentPosition - 1]) && (arr[currentPosition] > arr[currentPosition + 1]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
    static void Main()
    {
        Console.Write("Enter length of the array: ");
        int N = int.Parse(Console.ReadLine());

        Console.WriteLine("enter the array: ");
        int[] myArr = new int[N];

        for (int i = 0; i < N; i++)
        {
            myArr[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Enter a position: ");
        int pos = int.Parse(Console.ReadLine());

        bool res = GetBigNeighbour(myArr, pos - 1);
        Console.WriteLine("Is it the big: " + res);
    }
}

