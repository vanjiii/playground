using System;

namespace Triangle
{
    class Triangle
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 1; i <= N; i++)
            {
                string spaces = new string(' ', N  - i);
                string symbols = new string('@', 2*i-1);
                Console.Write(spaces);
                Console.WriteLine(symbols);
            }
        }
    }
}