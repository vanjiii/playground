using System;
    class CorrectBit
    {
        static void Main()
        {
            //Initialize a,v,p
            Console.WriteLine("Enter a number to correct: ");
            string strN = Console.ReadLine();
            int v, n, p;
            int.TryParse(strN, out n);
            Console.WriteLine("Enter a position: ");
            string strP = Console.ReadLine();
            int.TryParse(strP, out p);
            Console.WriteLine("Enter a value: ");
            string strV = Console.ReadLine();
            int.TryParse(strV, out v);

            if (v == 1)
            {
                v = 1 << (p - 1);
                int newNumber = v | n;
                Console.WriteLine("The new number is: " + newNumber);
                Console.WriteLine(Convert.ToString(newNumber, 2).PadLeft(32, '0'));
            }
            else
            {
                v = 1 << (p - 1);
                int newNumber = v ^ n;
                Console.WriteLine("The new number is: " + newNumber);
                Console.WriteLine(Convert.ToString(newNumber, 2).PadLeft(32, '0'));
            }
           
        }
    }
/*
We are given integer number n, value v (v=0 or 1) and a position p. Write a sequence of operators that modifies n to hold the value v at the position p from the binary representation of n.
Example: n = 5 (00000101), p=3, v=1  13 (00001101)
n = 5 (00000101), p=2, v=0  1 (00000001)

*/