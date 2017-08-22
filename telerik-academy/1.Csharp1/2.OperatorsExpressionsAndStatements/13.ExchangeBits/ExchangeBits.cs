using System;
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter number: ");
            string i = Console.ReadLine();
            uint unsNumber;
            uint.TryParse(i, out unsNumber);

            uint numberSmall = unsNumber & 56;
            uint numberBig = unsNumber & 58720256;
            uint numberSmallMove = numberSmall << 20;
            uint numberBigMove = numberBig >> 20;
            unsNumber = unsNumber & 4177526727;
            unsNumber = numberBigMove | unsNumber;
            unsNumber = numberSmallMove | unsNumber;
            Console.WriteLine("The new number is: " + unsNumber);
        }
    }
/*
 Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.
 */ 