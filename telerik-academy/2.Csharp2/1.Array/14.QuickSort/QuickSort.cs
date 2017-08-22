using System;
/*
 * Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).
 */
class QuickSort
{
    static void Main()
    {
        //enter the array
        Console.Write("enter length:");
        int N = int.Parse(Console.ReadLine());
        string[] unsortedChars = new string[N];
        for (int i = 0; i < N; i++)
        {
            Console.WriteLine("Enter a char to sort: ");
            unsortedChars[i] = Console.ReadLine();

        }

        //sort the array
        QuickSortImpl(unsortedChars, 0, unsortedChars.Length - 1);

        //print the array
        for (int i = 0; i < unsortedChars.Length; i++)
        {
            Console.Write(unsortedChars[i] + " ");
        }
        Console.WriteLine();

    }

    static void QuickSortImpl(string[] elements, int left, int right)
    {
        //choose a pivot
        string pivot = elements[(left + right) / 2];
        
        string tempChar;
        int i = left, j = right;

        while (i <= j)
        {
            while ((pivot.CompareTo(elements[i]) == 1) )
            {
                i++;
            }
            while ((pivot.CompareTo(elements[j]) == -1) )
            {
                j--;
            }
            if (i <= j)
            {
                tempChar = elements[i];
                elements[i] = elements[j];
                elements[j] = tempChar;
                j--;
                i++;
            }
        }

        //recursive calls
        if (left < j)
        {
            QuickSortImpl(elements, left, j);
        }

        if (i < right)
        {
            QuickSortImpl(elements, i, right);
        }
    }
}





//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Quicksort
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Create an unsorted array of string elements
//            string[] unsorted = { "z", "e", "x", "c", "m", "q", "a" };

//            // Print the unsorted array
//            for (int i = 0; i < unsorted.Length; i++)
//            {
//                Console.Write(unsorted[i] + " ");
//            }

//            Console.WriteLine();

//            // Sort the array
//            Quicksort(unsorted, 0, unsorted.Length - 1);

//            // Print the sorted array
//            for (int i = 0; i < unsorted.Length; i++)
//            {
//                Console.Write(unsorted[i] + " ");
//            }

//            Console.WriteLine();

//            Console.ReadLine();
//        }

//        public static void Quicksort(IComparable[] elements, int left, int right)
//        {
//            int i = left, j = right;
//            IComparable pivot = elements[(left + right) / 2];

//            while (i <= j)
//            {
//                while (elements[i].CompareTo(pivot) < 0)
//                {
//                    i++;
//                }

//                while (elements[j].CompareTo(pivot) > 0)
//                {
//                    j--;
//                }

//                if (i <= j)
//                {
//                    // Swap
//                    IComparable tmp = elements[i];
//                    elements[i] = elements[j];
//                    elements[j] = tmp;

//                    i++;
//                    j--;
//                }
//            }

//            // Recursive calls
//            if (left < j)
//            {
//                Quicksort(elements, left, j);
//            }

//            if (i < right)
//            {
//                Quicksort(elements, i, right);
//            }
//        }

//    }
//}