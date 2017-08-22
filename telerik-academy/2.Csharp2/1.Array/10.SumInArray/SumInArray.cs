using System;
/*
 * Write a program that finds in given array of integers a sequence of given sum S (if present). 
 * Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}
*/
class SumInArray
{
    static void Main()
    {
        //enter the length of the array
        int N = int.Parse(Console.ReadLine());

        //input the array
        int[] usingArray = new int[N];
        for (int i = 0; i < N; i++)
        {
            usingArray[i] = int.Parse(Console.ReadLine());
        }

        //input the chekced sum
        int sum = int.Parse(Console.ReadLine());

        int localSum = 0;
        int firstBit = 0;
        int lastBit = 0;
        for (int i = 0; i < N; i++)
        {
            //subarray 
            localSum = usingArray[i];
            for (int j = i + 1; j < N; j++)
            {
                //sum the elements, starting form element 'i' and adding every 'j' (next) element of the array
                localSum += usingArray[j];
                if (localSum == sum)
                {
                    //if the subarray sum is equal to the given we exit the loop;
                    //and remember the number of the starting bit and ending one
                    firstBit = i;
                    lastBit = j;
                    continue;
                }
                    //if the sum exceeds the given we exit the loop again
                    //and start another sum starting with the number with position 'i + 1'
                else if (localSum > sum)
                {
                    continue;
                }
                
            }

            //reset the sum 
            localSum = 0;
        }

        //print only the numbers that we care about
        for (int ii = firstBit; ii <= lastBit; ii++)
        {
            Console.Write(usingArray[ii] + " ");
        }
        //Console.WriteLine("first bit: " + firstBit);
       // Console.WriteLine("last bit: " + lastBit);
    }
}
