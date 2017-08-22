using System;
using System.Text.RegularExpressions;
/*
 * Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".
 */
class Polindromes
{
    static void Main()
    {
        Console.Write("Enter text: ");
        string text = Console.ReadLine();

        string firstHalf = string.Empty;
        string secondHalf = string.Empty;
        string pattern = @"\w+";
        foreach (var email in Regex.Matches(text, pattern))
        {
            for (int i = 0; i < email.ToString().Length / 2; i++)
            {
                firstHalf += email.ToString()[i];
                secondHalf += email.ToString()[email.ToString().Length - 1 - i];
            }
            
            if (firstHalf == secondHalf)
            {
               Console.WriteLine(email); 
            }
            firstHalf = string.Empty;
            secondHalf = string.Empty;
        }
    }
}