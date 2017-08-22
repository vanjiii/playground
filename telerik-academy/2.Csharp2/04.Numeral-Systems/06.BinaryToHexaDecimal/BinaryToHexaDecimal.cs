using System;
/*
 * Write a program to convert binary numbers to hexadecimal numbers (directly).
 */

class BinaryToHexaDecimal
    {
        static string BinaryToHexa(string num)
        {
            return Convert.ToString(Convert.ToInt32(num, 2), 16);
        }
        static void Main()
        {
            Console.Write("Enter a binary number: ");
            string binNum = Console.ReadLine();

            Console.WriteLine("Hexa: " + BinaryToHexa(binNum));
        }
    }