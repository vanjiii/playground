using System;
using System.Linq;
/*
 * Write a program that finds the sequence of maximal sum in given array. Example:
	{2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
	Can you do it with only one loop (with single scan through the elements of the array)?

 */
class MaxSumOfSequence
{
    static void Main()
    {
        //---------------------using Kadane's algotirthm-----------------------

        //input the lenght of the array
        Console.Write("Enter lenght of the array: ");
        int N = int.Parse(Console.ReadLine());

        //input the array itself
        Console.WriteLine("Enter the array: ");
        int[] usingArray = new int[N];
        for (int i = 0; i < N; i++)
        {
            usingArray[i] = int.Parse(Console.ReadLine());
        }


        int localSum = 0;
        int maxSum = 0;
        int beginningBit = 0, endingBit = 0;

        for (int ii = 0; ii < N; ii++)
        {
            //the sum of the current subarray
            localSum += usingArray[ii];

            //if that sum is below 0, then we reset the local counter and mark next bit to be the "first bit"
            if (localSum < 0)
            {
                localSum = 0;
                beginningBit = ii + 1;
            }

            //if the local sum is greater than the current max sum, then we make the max sum equal to the local one mark the current bit as "ending"
            if (localSum > maxSum)
            {
                maxSum = localSum;
                endingBit = ii;
            }
        }
        //case if all the array's members are negatives
        //Then we actually looking for the local min
        if (maxSum == 0)
        {
            Console.WriteLine("Your array consists only negatives numbers !");
        }
        else
        {
            //print the result...
            for (int j = beginningBit; j <= endingBit; j++)
            {
                Console.Write(usingArray[j] + " ");
            }
            Console.WriteLine();
            //Console.WriteLine("first bit: " + beginningBit);
            //Console.WriteLine("last bit : " + endingBit);
            Console.WriteLine("The max sum is: " + maxSum);
        }
       
    }
}
