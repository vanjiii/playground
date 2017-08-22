using System;
using System.Linq;

namespace HexToDec
{
    class HexToDec
    {
        static void Main(string[] args)
        {
            string hex = Console.ReadLine();
            int num = Convert.ToInt32(hex, 16);
            Console.WriteLine(num);
        }
    }
}
