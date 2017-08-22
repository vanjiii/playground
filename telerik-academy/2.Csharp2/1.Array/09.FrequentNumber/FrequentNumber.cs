using System;
/*
 * Write a program that finds the most frequent number in an array. Example:
	{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)
 */
class FrequentNumber
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

        int localCounter = 0, maxCounter = 0;
        int maxNum = 0, localNum = 0;
        for (int j = 0; j < N; j++)
        {
            localCounter = 0;
            localNum = 0;
            for (int ii = j + 1; ii < N; ii++)
            {
                //check if current number is equal to the next
                //also checks if the checked element is != to int.MinValue
                if ((usingArray[j] == usingArray[ii]) && (usingArray[ii] != int.MinValue))
                {
                    //increase the counter of the current element
                    localCounter++;   
                    //remember which number we are working with                   
                    localNum = usingArray[j];
                    //making every his twins equal to int.MinValue, so we can skip them in further check
                    usingArray[ii] = int.MinValue;
                }
            }
            //check if the local counter(of the current number) is greater of the max one.
            if (localCounter > maxCounter)
            {
                maxCounter = localCounter;
                maxNum = usingArray[j];
            }
        }

        //output
        Console.WriteLine("counter: " + (maxCounter + 1));
        Console.WriteLine("maxnum: " + maxNum);
    }
}