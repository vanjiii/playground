using System;
/*Write a method that returns the index of the first element in array that is bigger than its neighbors, or -1, if there’s no such element.
 * Use the method from the previous exercise.
 */
class TheFirstBiggerNeighbour
{
    static int GetBigNeighbour(int[] arr)
    {
        for (int currentPosition = 0; currentPosition < arr.Length; currentPosition++)
        {
            if (currentPosition == 0)
            {
                if ((arr[currentPosition] > arr[currentPosition + 1]))
                {
                    return currentPosition;
                }
            }
            else if (currentPosition == arr.Length - 1)
            {
                if ((arr[currentPosition] > arr[currentPosition - 1]))
                {
                    return currentPosition;
                }
            }
            else
            {
                if ((arr[currentPosition] > arr[currentPosition - 1]) && (arr[currentPosition] > arr[currentPosition + 1]))
                {
                    return currentPosition;
                }
            }
        }
        return -1;
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

        //Console.Write("Enter a position: ");
        //int pos = int.Parse(Console.ReadLine());

        int res = GetBigNeighbour(myArr);
        if (res != -1)
        {
            Console.WriteLine("the winner is: " + myArr[res]);
        }
        else
        {
            Console.WriteLine("there is no such element!");
        }
        
    }
}

