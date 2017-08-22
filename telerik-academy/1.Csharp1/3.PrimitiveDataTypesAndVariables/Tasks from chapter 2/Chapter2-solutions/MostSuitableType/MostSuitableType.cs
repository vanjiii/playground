using System;
using System.Linq;

namespace MostSuitableType
{
    class MostSuitableType
    {
        static void Main(string[] args)
        {
            char sign = char.Parse(Console.ReadLine());

            if (sign == '+')
            {
                ulong inputNumber = ulong.Parse(Console.ReadLine());
                if (inputNumber <= 127)
                {
                    Console.WriteLine("sbyte");
                }
                else if (inputNumber <= 255)
                {
                    Console.WriteLine("byte");
                }
                else if (inputNumber <= 32767)
                {
                    Console.WriteLine("short");
                }
                else if (inputNumber <= 65535)
                {
                    Console.WriteLine("ushort");
                }
                else if (inputNumber <= 2147483647)
                {
                    Console.WriteLine("int");
                }
                else if (inputNumber <= 4294967295)
                {
                    Console.WriteLine("uint");
                }
                else if (inputNumber <= 9223372036854775807)
                {
                    Console.WriteLine("long");
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
                    Console.WriteLine("sbyte");
                }
                else if (inputNumber >= -32768)
                {
                    Console.WriteLine("short");
                }
                else if (inputNumber >= -2147483648)
                {

                    Console.WriteLine("int");
                }
                else if (inputNumber >= -9223372036854775808)
                {
                    Console.WriteLine("long");
                }
            }
        }
    }
}
