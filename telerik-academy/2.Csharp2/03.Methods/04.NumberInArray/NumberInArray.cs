using System;
/*
 * Write a method that counts how many times given number appears in given array. 
 * Write a test program to check if the method is working correctly.
 */
namespace Count
{
    public class NumberInArray
    {
        public static int Equal(int[] someArr, int givenNum)
        {
            int count = 0;
            for (int j = 0; j < someArr.Length; j++)
            {
                if (someArr[j] == givenNum)
                {
                    count++;
                }
            }
            return count;
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

            Console.Write("Enter a num to search");
            int numToCheck = int.Parse(Console.ReadLine());

            int res = Equal(myArr, numToCheck);
            Console.WriteLine("count: " + res);
        }
    }
}
