using System;
using System.Text.RegularExpressions;
/*
 * Write a program that extracts from a given text all dates that match the format DD.MM.YYYY.
 * Display them in the standard date format for Canada.
 */
class ExtractDates
{
    static void Main()
    {
        Console.Write("Enter text: ");
        string text = Console.ReadLine();

        string pattern = @"\b\d{2}.\d{2}.\d{4}\b";
        foreach (var email in Regex.Matches(text, pattern))
        {
            Console.WriteLine(email);
        }
    }
}