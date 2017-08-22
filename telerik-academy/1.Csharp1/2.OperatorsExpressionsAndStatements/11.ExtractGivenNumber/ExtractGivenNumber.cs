using System;
    class ExtractGivenNumber
    {
        static void Main()
        {
            Console.WriteLine("Enter a number: ");
            string i = Console.ReadLine();
            int numberInteger, numberPosiotion;
            int.TryParse(i, out numberInteger);
            Console.WriteLine("Enter a position to check: ");
            string j = Console.ReadLine();
            int.TryParse(j, out numberPosiotion);

            int bitAtRight = numberInteger >> (numberPosiotion - 1);
            int bit = bitAtRight & 1;
            if (bit == 1)
            {
                Console.WriteLine("The search bit is 1");
                Console.WriteLine(Convert.ToString(numberInteger, 2).PadLeft(32, '0'));
            }
            else
            {
                Console.WriteLine("The search bit is 0");
                Console.WriteLine(Convert.ToString(numberInteger, 2).PadLeft(32, '0'));
            }   
        }
    }
/*
Write an expression that extracts from a given integer i the value of a given bit number b. Example: i=5; b=2  value=1.

*/