using System;
using System.Text.RegularExpressions;
/*
 * Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).
		Example: The target substring is "in". The text is as follows:

 * We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.

 * The result is: 9.

 */
class NumberOfSubstrings
{
    static void Main()
    {
        Console.Write("Enter string: ");
        string text = Console.ReadLine();
        Console.Write("Enter substring to search: ");
        string subStr = Console.ReadLine();

        Console.WriteLine("Times: " + ContainingOfSubstring(text, subStr));
    }

    private static int ContainingOfSubstring(string text, string subStr)
    {
        text = text.ToLower();
        int index = text.IndexOf(subStr, 0);
        int count = 0;
        while (index != -1)
        {
            count++;
            index = text.IndexOf(subStr, index + 1);
        }
        //return Regex.Matches(text,subStr,RegexOptions.IgnoreCase).Count;
        return count;
    }
}