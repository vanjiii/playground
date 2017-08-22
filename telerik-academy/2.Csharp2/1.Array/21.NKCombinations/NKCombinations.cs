using System;
using System.Text;
/*
 * Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N]. Example:
	N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}

*/

class NKCombinations
{
    static void Comb(int[] arr, int k)
    {
        StringBuilder str = new StringBuilder();
        for (int i = 1; i <= Math.Pow(2, arr.Length) - 1; i++)
        {
            string temp = Convert.ToString(i, 2).PadLeft(arr.Length, '0');
            for (int j = 0; j < temp.Length; j++)
            {
                if (temp[j] == '1')
                {
                    str.Append(arr[j] + " ");
                }
            }
            string[] split = str.ToString().Split(null as string[], StringSplitOptions.RemoveEmptyEntries);
            if (split.Length == k)
            {
                Console.WriteLine(str.ToString());
            }
            str.Clear();
            Array.Clear(split, 0, split.Length);
        }
    }
    static void Main(string[] args)
    {
        int n;
        bool isN = int.TryParse(Console.ReadLine(), out n);
        if (isN)
        {
            int k = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = i + 1;
            }
            Comb(arr, k);
        }
    }
}