using System;
/*
 * Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. 
 * Use variable number of arguments.
 */
class MultiTask
{
    static void Add(decimal[] arr)
    {
        decimal resultAdd = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            resultAdd += arr[i];
        }

        Console.Write("The sum is: " + resultAdd);
    }
    static void Product(decimal[] arr)
    {
        decimal resultProd = 1;
        for (int i = 0; i < arr.Length; i++)
        {
            resultProd *= arr[i];
        }
        Console.Write("The product is: " + resultProd);
    }
    static void MaxElement(decimal[] arr)
    {
        decimal max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (max < arr[i])
            {
                max = arr[i];
            }
        }
        Console.Write("The max element is: " + max);
    }
    static void MinElement (decimal[] arr)
    {
        decimal minElement = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (minElement > arr[i])
            {
                minElement = arr[i];
            }
        }
        Console.Write("The min element is: " + minElement);
    }
    static void Average(decimal[] arr)
    {
        decimal count = arr.Length;
        decimal result = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            result += arr[i];
        }
        Console.WriteLine("The average is " + (result / count));
    }
    static void Main()
    {
        Console.Write("Enter length of the array: ");
        int N = int.Parse(Console.ReadLine());

        decimal[] arr = new decimal[N];
        Console.WriteLine("Enter the array: ");
        for (int i = 0; i < N; i++)
        {
            arr[i] = decimal.Parse(Console.ReadLine());
        }
        Console.WriteLine();
        Add(arr);
        Console.WriteLine();
        Product(arr);
        Console.WriteLine();
        MaxElement(arr);
        Console.WriteLine();
        MinElement(arr);
        Console.WriteLine();
        Average(arr);
        Console.WriteLine();
    }
}