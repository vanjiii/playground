using System;

namespace ConcatWordsInObject
{
    class ConcatWordsInObject
    {
        static void Main(string[] args)
        {
            string word1 = Console.ReadLine();
            string word2 = Console.ReadLine();
            object word1PlusWord2 = word1 + " " + word2;
            Console.WriteLine(word1PlusWord2);
        }
    }
}
