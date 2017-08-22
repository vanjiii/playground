using System;

namespace Romb
{
    class Romb
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            

            for (int i = 1; i <= N; i++)
            {
                string spaces = new string(' ', N  - i);
                string onLeft = new string('/', i);
                string onRight = new string('\\', i);
                Console.Write(spaces);
                Console.Write(onLeft);
                Console.WriteLine(onRight);
            }

            for (int i = N; i > 0; i--)
            {
                string spaces = new string(' ', N - i);
                string onLeft = new string('/',  i);
                string onRight = new string('\\', i);
                Console.Write(spaces);
                Console.Write(onRight);
                Console.WriteLine(onLeft);
                
            }
        }
    }
}
