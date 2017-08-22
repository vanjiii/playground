using System;

namespace NumberPrecision
{
    class NumberPrecision
    {
        static void Main(string[] args)
        {

            decimal p = decimal.Parse(Console.ReadLine());
            decimal q = decimal.Parse(Console.ReadLine());
            decimal sum = p + q;
            Console.WriteLine(sum);
        }
    }
}