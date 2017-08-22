using System;

namespace CastObjectToString
{
    class CastObjectToString
    {
        static void Main(string[] args)
        {
            string word1 = Console.ReadLine();
            string word2 = Console.ReadLine();
            object word1PlusWord2 = word1 + " " + word2;
            string word1PlusWord2String = (string)word1PlusWord2;
            Console.WriteLine(word1PlusWord2String);
        }
    }
}
