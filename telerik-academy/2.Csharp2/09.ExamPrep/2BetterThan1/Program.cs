using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program05
{
    static void Main(string[] args)
    {
        int result1 = Task1();
        int result2 = Task2();
        Console.WriteLine(result1);
        Console.WriteLine(result2);
    }

    private static int Task2()
    {
        string[] Input = Console.ReadLine().Split(',');
        int percentile = int.Parse(Console.ReadLine());
        int[] array = new int[Input.Length];
        for (int i = 0; i < Input.Length; i++)
        {
            array[i] = int.Parse(Input[i]);
        }
        Array.Sort(array);
        return array[(percentile * Input.Length - 1) / 100];
    }

    private static int Task1()
    {
        string[] Input = Console.ReadLine().Split(' ');
        int result = 0;
        if (Input[1].Length == Input[0].Length)
        {
            result += CheckAB(2, Input[0], Input[1]);
        }
        else
        {
            result += CheckAB(1, Input[0]);//only A
            result += CheckAB(3, "", Input[1]);//only B
            for (int i = Input[0].Length + 1; i < Input[1].Length; i++)
            {
                result += (1 << ((i + 1) / 2));
            }
        }
        return result;
    }

    private static int CheckAB(int mode, string A = "", string B = "")
    {
        int length = Math.Max(A.Length, B.Length);
        string C;
        int result = 0;
        long longA = 0, longB = 0, longC;
        if (mode < 3)
        {
            longA = long.Parse(A);
        }
        if (mode > 1)
        {
            longB = long.Parse(B);
        }
        StringBuilder palindrome = new StringBuilder();
        for (int i = 0; i < (1 << ((length + 1) / 2)); i++)
        {
            palindrome.Clear();
            int mask = 1 << (length + 1) / 2;
            for (int j = 0; j < (length + 1) / 2; j++)
            {
                mask >>= 1;
                if ((i & mask) == 0)
                {
                    palindrome.Append('3');
                }
                else
                {
                    palindrome.Append('5');
                }
            }
            for (int j = 0; j < (length + 1) / 2; j++)
            {
                if ((length % 2 == 0) || (j > 0))
                {
                    if ((i & mask) == 0)
                    {
                        palindrome.Append('3');
                    }
                    else
                    {
                        palindrome.Append('5');
                    }
                }
                mask <<= 1;
            }
            C = palindrome.ToString(0, length);
            longC = long.Parse(C);
            if (((mode > 2) || (longC >= longA)) && ((mode < 2) || (longC <= longB)))
            {
                result++;
            }
        }
        return result;
    }
}