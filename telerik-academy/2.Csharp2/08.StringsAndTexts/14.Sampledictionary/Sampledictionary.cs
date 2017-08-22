using System;
/*
 * A dictionary is stored as a sequence of text lines containing words and their explanations. Write a program that enters a word and translates it by using the dictionary. Sample dictionary:
 

.NET – platform for applications from Microsoft
CLR – managed execution environment for .NET
namespace – hierarchical organization of classes

 */
class Sampledictionary
{
    static void Main()
    {
        Console.Write("Enter a word: ");
        string word = Console.ReadLine();

        Dictionary(word);
    }

    private static void Dictionary(string word)
    {
        string[] dict = {".net", "clr", "namespace", "programmer" };
        switch (word.ToLower())
        {
            case ".net": Console.WriteLine(".NET – platform for applications from Microsoft");
                break;
            case "clr": Console.WriteLine("CLR – managed execution environment for .NET");
                break;
            case "namespace": Console.WriteLine("namespace – hierarchical organization of classes");
                break;
            case "programmer": Console.WriteLine("programmer – machine that converts coffee into code");
                break;
            default: Console.WriteLine("The dictionary do not contain that word!");
                break;
        }
    }
}