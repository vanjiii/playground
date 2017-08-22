using System;

namespace Swaps
{
    class Swaps
    {
        static void Main(string[] args)
        {
            int fistNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int tempNumber = fistNumber;
            fistNumber = secondNumber;
            secondNumber = tempNumber;
            Console.WriteLine(fistNumber);
            Console.WriteLine(secondNumber);

        }
    }
}
