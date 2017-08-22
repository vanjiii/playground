using System;
using System.Text;
/*
 * Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings. Sample input:
    Hi!
 * Expected output:
\u0048\u0069\u0021
 */
class UnicodeChars
{
    static void Main()
    {
        Console.WriteLine("Enter the string: ");
        string res = Console.ReadLine();

        Console.WriteLine(new string('-', 10) + "Result" + new string('-', 10));
        Console.WriteLine(UnicodeTransform(res));
    }

    private static string UnicodeTransform(string res)
    {
        StringBuilder strBuilder = new StringBuilder();

        for (int i = 0; i < res.Length; i++)
        {
            strBuilder.AppendFormat("\\u{0:X4}", (int)res[i]);
        }
        return strBuilder.ToString();
    }
}