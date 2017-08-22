using System;
/*
 * Write a program that reverses the words in given sentence.
	Example: "C# is not C++, not PHP and not Delphi!"  "Delphi not and PHP, not C++ not is C#!".
*/
class ReverseSentence
{
    static void Main()
    {
        Console.Write("Enter a sentence: ");
        string sentence = Console.ReadLine();

        ReverseWordsInSentence(sentence);
    }

    private static void ReverseWordsInSentence(string sentence)
    {
        sentence = sentence.Trim(' ', '"', '.', '!', '?');
        string[] words = sentence.Split(' ');

        for (int i = words.Length - 1; i >= 0; i--)
        {
            Console.Write(words[i] + " ");
        }
    }
}