using System;
using System.Linq;

namespace AllTypeOfANumber
{
    class AllTypeOfANumber
    {
        static void Main(string[] args)
        {
            char sign = char.Parse(Console.ReadLine());

            if (sign == '+')
            {
                ulong inputNumber = ulong.Parse(Console.ReadLine());
                if (inputNumber <= 127)
                {
                    Console.WriteLine("byte, int, long, sbyte, short, uint, ulong, ushort");
                }
                else if (inputNumber <= 255)
                {
                    Console.WriteLine("byte, int, long, short, uint, ulong, ushort");
                }
                else if (inputNumber <= 32767)
                {
                    Console.WriteLine("int, long, short, uint, ulong, ushort");
                }
                else if (inputNumber <= 65535)
                {
                    Console.WriteLine("int, long, uint, ulong, ushort");
                }
                else if (inputNumber <= 2147483647)
                {
                    Console.WriteLine("int, long, uint, ulong");
                }
                else if (inputNumber <= 4294967295)
                {
                    Console.WriteLine("long, uint, ulong");
                }
                else if (inputNumber <= 9223372036854775807)
                {
                    Console.WriteLine("long, ulong");
                }
                else if (inputNumber <= 18446744073709551615)
                {
                    Console.WriteLine("ulong");
                }

            }
            else
            {
                long inputNumber = long.Parse(Console.ReadLine());
                if (inputNumber >= -128)
                {
                    Console.WriteLine("int, long, sbyte, short");
                }
                else if (inputNumber >= -32768)
                {
                    Console.WriteLine("int, long, short");
                }
                else if (inputNumber >= -2147483648)
                {

                    Console.WriteLine("int, long");
                }
                else if (inputNumber >= -9223372036854775808)
                {
                    Console.WriteLine("long");
                }
            }
        }
    }
}
