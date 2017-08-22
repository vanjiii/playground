using System;
    class ExchangeBitsAll
    {
        private static string firstNumber;
        static void Main()
        {
            Console.WriteLine("Enter a number, how many bits to work with, the number of the first P bit and Q bit ...");
            Console.WriteLine("Enter number to work with: ");
            string i = Console.ReadLine();
            int inputNumber;
            int bitToChangeP, bitToChangeQ, bitNumber;
            int.TryParse(i, out inputNumber);
            Console.WriteLine("Enter how many bits u want to exchange: ");
            string j = Console.ReadLine();
            int.TryParse(j, out bitNumber);
            Console.WriteLine("Enter position of P bit : ");
            string k = Console.ReadLine();
            int.TryParse(k, out bitToChangeP);
            Console.WriteLine("Enter position of Q bit : ");
            string l = Console.ReadLine();
            int.TryParse(l, out bitToChangeQ);

            int masksP, maskQ, maskNew;
            masksP = 65536 >> (16 - (bitNumber));
            maskNew = masksP << (bitToChangeP - 1);
            maskQ = masksP << bitToChangeQ;
            inputNumber = inputNumber & maskNew;
            inputNumber = inputNumber | maskQ;
            Console.WriteLine("The new number is: " + inputNumber);
        }
    }
/*
 * Write a program that exchanges bits {p, p+1, …, p+k-1) with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.
 */