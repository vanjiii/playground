using System;

namespace IsMale
{
    class IsMale
    {
        static void Main(string[] args)
        {
            bool isMale = bool.Parse(Console.ReadLine());
            if (isMale == true)
            {
                Console.WriteLine("You are male");
            }
            else
            {
                Console.WriteLine("You are female");
            }
        }
    }
}
