using System;
/*
 * * Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.).
 * Use generic method (read in Internet about generic methods in C#).
 */
class GenericMultiTask
    {
        static T Add<T>(T[] arr)
        {
            dynamic resultAdd = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                resultAdd += arr[i];
            }

            Console.Write("The sum is: " + resultAdd);
            return resultAdd;
        }
        static T Product<T>(T[] arr)
        {
            dynamic resultProd = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                resultProd *= arr[i];
            }
            Console.Write("The product is: " + resultProd);
            return resultProd;
        }
        static T MaxElement<T>(T[] arr)
        {
            dynamic max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                }
            }
            Console.Write("The max element is: " + max);
            return max;
        }
        static T MinElement<T>(T[] arr)
        {
            dynamic minElement = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (minElement > arr[i])
                {
                    minElement = arr[i];
                }
            }
            Console.Write("The min element is: " + minElement);
            return minElement;
        }
        static T Average<T>(T[] arr)
        {
            dynamic count = arr.Length;
            dynamic result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                result += arr[i];
            }
            Console.WriteLine("The average is " + (result / count));
            return result / count;
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