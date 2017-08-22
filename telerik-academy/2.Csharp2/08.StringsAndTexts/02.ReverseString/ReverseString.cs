using System;
using System.Collections.Generic;
using System.Text;
/*
 * Write a program that reads a string, reverses it and prints the result at the console.
 * Example: "sample"  "elpmas".
 */
class ReverseString
{
    static void Main()
    {
        Console.Write("Enter string: ");
        string text = Console.ReadLine();

        Console.WriteLine(InvertString(text));
    }

    private static string InvertString(string str)
    {
        StringBuilder strb = new StringBuilder();

        for (int i = 0; i < str.Length; i++)
        {
            strb.Append(str[str.Length - (1 + i)]);
        }

        return strb.ToString();
    }
}