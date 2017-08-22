using System;
using System.Collections.Generic;
/*
 * Write a program to check if in a given expression the brackets are put correctly.
 * Example of correct expression: ((a+b)/5-d).
 * Example of incorrect expression: )(a+b)).(a+b))((5-b);(a+b)((5-b)
 */
class CorrectBrackets
{
    static void Main()
    {
        Console.Write("Enter string: ");
        string text = Console.ReadLine();

        Console.WriteLine("The brackets are in correct form: " + CheckBracket(text));
    }

    private static bool CheckBracket(string str)
    {
        if (str[0].CompareTo(')') == 0)
        {
            return false;
        }

        string strEnd = str;
        int startIndex = str.IndexOf('(', 0);
        int endIndex = strEnd.LastIndexOf(')');

        while (startIndex != -1 || endIndex != -1)
        {
            if (startIndex == -1 || endIndex == -1)
            {
                return false;
            }
            strEnd = strEnd.Substring(0, endIndex);
            startIndex = str.IndexOf('(', startIndex + 1);
            endIndex = strEnd.IndexOf(')');
        }
       
        return true;
    }
}