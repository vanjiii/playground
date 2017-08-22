using System;
using System.Text.RegularExpressions;
/*
 * Write a program for extracting all email addresses from given text.
 * All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails.

 */
class ExtractEmail
{
    static void Main()
    {
        Console.Write("Enter text: ");
        string text = Console.ReadLine();

        string pattern = @"\w+@\w+\.\w+";
        foreach (var email in Regex.Matches(text, pattern))
        {
            Console.WriteLine(email);
        }
    }
}