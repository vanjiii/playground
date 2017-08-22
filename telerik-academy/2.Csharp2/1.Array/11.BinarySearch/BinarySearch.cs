using System;
/*
 * Write a program that finds the index of given element in a sorted array of integers by using the binary search algorithm (find it in Wikipedia).
 */
class BinarySearch
{
    static void Main()
    {
        Console.WriteLine("Please be sure that the entered array is sorted");

        //input the length of the array
        int N = int.Parse(Console.ReadLine());

        //input the array
        int[] usingArray = new int[N];
        for (int i = 0; i < N; i++)
        {
            usingArray[i] = int.Parse(Console.ReadLine());
        }

        //input the number we are looking for
        int givenNumber = int.Parse(Console.ReadLine());

        //local variables....
        int localNumber = 0;
        int lowestLocation = 0;
        int highestLocation = N;
        int currentLocation = (lowestLocation / 2) + (highestLocation / 2);

        while (localNumber != givenNumber)
        {
            //take the middle element
            localNumber = usingArray[currentLocation];
            
            //compare the local number to the given
            if (localNumber > givenNumber)
            {
                //change the upper board
                highestLocation = currentLocation + 1;
            }
            else if (localNumber < givenNumber)
            {
                //change the lower board
                lowestLocation = currentLocation - 1;
            }

            //after the chages in high/low location, change and the current, which is the index of the element indeed
            currentLocation = (lowestLocation / 2) + (highestLocation / 2);
        }
        //+ 1 'cause the array in C# begins with 0
        Console.WriteLine("The index of the given number is: " + (currentLocation + 1));
    }
}

