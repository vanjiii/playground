using System;
    class BoleanExpr
    {
        static void Main()
        {
            Console.WriteLine("Enter a number: ");
            string i = Console.ReadLine();
            int numberInteger,numberPosiotion;
            int.TryParse(i, out numberInteger);
            Console.WriteLine("Enter a position to check: ");
            string j = Console.ReadLine();
            int.TryParse(j,out numberPosiotion);

            int bitAtRight = numberInteger >> (numberPosiotion - 1);
            int bit = bitAtRight & 1;
            if (bit == 1)
            {
                Console.WriteLine("Yes, the {0}'th is 1.", numberPosiotion);
                Console.WriteLine(Convert.ToString(numberInteger, 2).PadLeft(32, '0'));
            }
            else
            {
                Console.WriteLine("No, the {0}'th is 0.", numberPosiotion);
                Console.WriteLine(Convert.ToString(numberInteger, 2).PadLeft(32, '0'));
            }   
        }
    }
/*
Write a boolean expression that returns if the bit at position p (counting from 0) in a given integer number v has value of 1. Example: v=5; p=1  false.

*/