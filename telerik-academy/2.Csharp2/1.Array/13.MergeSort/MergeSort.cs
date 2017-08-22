using System;
/*
 *   * Write a program that sorts an array of integers using the merge sort algorithm (find it in Wikipedia).
 */
class MergeSort
{
    static void Main()
    {
        //enter the length of the array
        Console.WriteLine("You have to enter only the length of the array!");
        Console.Write("N = ");
        int N = int.Parse(Console.ReadLine());

        //initializing the array
        int[] arrayToSort = new int[N];
        
        //generate random members of the array
        Random randNum = new Random();
        for (int i = 0; i < N; i++)
        {
            arrayToSort[i] = randNum.Next(0, 100);
        }

        //print the original array
        Console.WriteLine("the unsorted array: ");
        for (int l = 0; l < arrayToSort.Length; l++)
        {
            Console.Write(arrayToSort[l] + "    ");
        }
        Console.WriteLine();

        //call the merge function
        int[] result = MergeSorting(arrayToSort);

        //print the array
        Console.WriteLine("sorted array: ");
        for (int j = 0; j < arrayToSort.Length; j++)
        {
            Console.Write(arrayToSort[j] + "    ");
        }
        Console.WriteLine();


    }

    //--------------------- Merge function ---------------------
    static int[] MergeSorting(int[] arrayToSort)
    {
        //checks is the number of the subarray is equal to one
        if (arrayToSort.Length == 1)
        {
            return arrayToSort;
        }

        //initialize the auxiliary arrays
        int middleIndex = arrayToSort.Length / 2;
        int[] leftSubarray = new int[middleIndex];
        int[] rightSubarray = new int[arrayToSort.Length - middleIndex];

        //element, with index = 0...N/2 -> in the left subarray
        for (int ii = 0; ii < middleIndex; ii++)
        {
            leftSubarray[ii] = arrayToSort[ii];
        }

        //element, with index = N/2...N -> in the right subarray
        for (int jj = 0; jj < arrayToSort.Length - middleIndex; jj++)
        {
            rightSubarray[jj] = arrayToSort[jj + middleIndex];
        }

        //here the function call itself until the subarrays have one element left
        leftSubarray = MergeSorting(leftSubarray);
        rightSubarray = MergeSorting(rightSubarray);

        //auxiliary indexes
        int leftptr = 0;
        int rightptr = 0;

        //new "sorted" array
        int[] sortedArray = new int[arrayToSort.Length];
        
        for (int k = 0; k < arrayToSort.Length; k++)
        {
            //boundary checker
            if ( (leftptr < leftSubarray.Length) && (rightptr < rightSubarray.Length) )
            {
                //which element of the subarray is lower
                //he is equalize to the "sorted" array
                if (leftSubarray[leftptr] > rightSubarray[rightptr])
	            {
                    sortedArray[k] = rightSubarray[rightptr];
                    rightptr++;
                }
                else
                {
                    sortedArray[k] = leftSubarray[leftptr];
                    leftptr++;
                }
            }
            else
            {
                //which elemets left unsorted(greater) and append to the new array
                if (leftptr < leftSubarray.Length)
                {
                    sortedArray[k] = leftSubarray[leftptr];
                    leftptr++;
                }
                else
                {
                    sortedArray[k] = rightSubarray[rightptr];
                    rightptr++;
                }
            }
            
            
        }

        //equalize the new and the original array
        for (int t = 0; t < sortedArray.Length; t++)
        {
            arrayToSort[t] = sortedArray[t];
        }

        return sortedArray;
    }
}