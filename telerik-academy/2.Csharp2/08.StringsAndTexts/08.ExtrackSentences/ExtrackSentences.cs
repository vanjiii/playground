using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
/*
 * Write a program that extracts from a given text all sentences containing given word.
		Example: The word is "in". The text is:

 *      We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.


		The expected result is:

 *      We are living in a yellow submarine.
We will move out of it in 5 days.
quiet

		Consider that the sentences are separated by "." and the words – by non-letter symbols.

 */
class ExtrackSentences
{
    static void Main()
    {
        Console.Write("Enter text: ");
        string text = Console.ReadLine();
        Console.Write("Enter key word: ");
        string key = Console.ReadLine();

        ExtrSentences(text, key);
    }

    private static void ExtrSentences(string text, string key)
    {
        string[] sentences = text.Split('.');
        List<string> output = new List<string>();
        string pattern = " " + key + " ";
        for (int i = 0; i < sentences.Length; i++)
        {
            Match mt = Regex.Match(sentences[i], pattern, RegexOptions.IgnoreCase);
            if (mt.Success)
            {
                output.Add(sentences[i].Trim() + '.');
            }
        }
        Console.WriteLine("The result : ");
        foreach (var item in output)
        {
            Console.WriteLine(item);
        }
    }
}