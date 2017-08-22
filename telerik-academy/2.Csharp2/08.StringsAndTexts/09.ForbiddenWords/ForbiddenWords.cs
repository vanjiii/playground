using System;
using System.Text.RegularExpressions;
/*
 * We are given a string containing a list of forbidden words and a text containing some of these words. 
 * Write a program that replaces the forbidden words with asterisks. 
 * Example:

 *      Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.
		
 * Words: "PHP, CLR, Microsoft"	
 * The expected result:

 *      ********* announced its next generation *** compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in ***.

 */
class ForbiddenWords
{
    static void Main()
    {
        Console.Write("Enter the text: ");
        string text = Console.ReadLine();
        Console.Write("Enter the pattern: ");
        string words = Console.ReadLine();

        Console.WriteLine("The result -> " + RemoveForbiddenWords(text, words));
    }

    private static string RemoveForbiddenWords(string text, string words)
    {
        //string[] AllWords = text.Split(' ');
        words = words.Trim(' ', '"');
        string[] pattern = words.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < pattern.Length; i++)
		{
			 text = text.Replace(pattern[i], new string('*', pattern[i].Length));
		}
        return text;
    }
}