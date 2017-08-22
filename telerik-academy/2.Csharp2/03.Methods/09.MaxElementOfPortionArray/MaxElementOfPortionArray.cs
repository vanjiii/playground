using System;
/*
 * Write a method that return the maximal element in a portion of array of integers starting at given index.
 * Using it write another method that sorts an array in ascending / descending order.
 */
class MaxElementOfPortionArray
{
    static int GetMaxElement(int[] arrayOfElements, int startingBit)
    {
        int maxElement = arrayOfElements[startingBit];
        for (int i = startingBit; i < arrayOfElements.Length; i++)
        {
            if (maxElement < arrayOfElements[i])
            {
                maxElement = arrayOfElements[i];
            }
        }
        return maxElement;
    }
    static int[] DescendingOrder(int[] arr)
    {
        //int[] sortedArray = new int[arr.Length];
        for (int index = 0; index < arr.Length; index++)
		{
            int localMax = GetMaxElement(arr, index);
            for (int jj = index; jj < arr.Length; jj++)
			{
                if (localMax == arr[jj])
	            {
                    if (index != jj)
                    {
                        arr[index] ^= arr[jj];
                        arr[jj] ^= arr[index];
                        arr[index] ^= arr[jj];
                    }
	            }
			}
            //sortedArray[index] = localMax;
		}
        return arr;
    }
    static void Main()
    {
        //input
        Console.Write("enter length of an array: ");
        int arrayLength = int.Parse(Console.ReadLine());
        //fill the array
        int[] arr = new int[arrayLength];
        Console.WriteLine("enter the array: ");
        for (int i = 0; i < arrayLength; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        //enter a startiting bit
        Console.Write("enter the beggining of the array: ");
        int index = int.Parse(Console.ReadLine());

        //finding the big in a portion of an array
        int res = GetMaxElement(arr, index);
        Console.WriteLine("The local max is: " + res);

        //descending sort
        int[] descendArr = DescendingOrder(arr);
        Console.WriteLine("Descending Order: ");
        for (int i = 0; i < descendArr.Length; i++)
        {
            Console.Write(descendArr[i] + "\t");
        }
        Console.WriteLine();

        //ascending order
        int[] ascendArr = DescendingOrder(arr);
        Console.WriteLine("ascending order");
        for (int i = ascendArr.Length - 1; i >= 0; i--)
        {
            Console.Write(ascendArr[i] + "\t");
        }
    }
}
