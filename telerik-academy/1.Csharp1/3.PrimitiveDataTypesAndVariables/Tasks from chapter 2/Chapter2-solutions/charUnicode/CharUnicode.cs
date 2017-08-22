using System;

namespace CharUnicode
{
    class CharUnicodes
    {
        static void Main(string[] args)
        {
            string unicodeSymbol = Console.ReadLine();
            int numInHex = Convert.ToInt32(unicodeSymbol, 16);
            char ch = (char)numInHex;
            Console.WriteLine(ch);
        }
    }
}
