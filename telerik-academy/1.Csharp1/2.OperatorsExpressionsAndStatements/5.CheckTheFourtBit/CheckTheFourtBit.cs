using System;
    class CheckTheFourtBit
    {
        static void Main()
        {
            Console.WriteLine("Enter a number: ");
            string i = Console.ReadLine();
            int numberInteger, p = 3;
            int.TryParse(i, out numberInteger);
            int bitAtRight = numberInteger >> p;
            int bit = bitAtRight & 1;
            if (bit == 1)
            {
                 Console.WriteLine("The third bit is 1.");
                 Console.WriteLine(Convert.ToString(numberInteger, 2).PadLeft(32, '0'));
            }
            else
            {
                  Console.WriteLine("the third bit is 0.");
                  Console.WriteLine(Convert.ToString(numberInteger, 2).PadLeft(32, '0'));               
            }           
        }
    }
/*
 Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.
 */