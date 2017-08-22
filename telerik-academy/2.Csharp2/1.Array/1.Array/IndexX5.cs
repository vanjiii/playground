using System;

/*
 * Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5. Print the obtained array on the console.
 */
class IndexX5
{
    static void Main()
    {
        int[] myArray = new int[20];

        for (int i = 0; i < 20; i++)
        {
            myArray[i] = (i + 1) * 5;
        }

        for (int j = 0; j < 20; j++)
        {
            Console.WriteLine("Element {0}: {1}", j + 1, myArray[j]);
        }
    }
}
