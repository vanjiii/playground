using System;
    class Program
    {
        static void Main()
        {
            Console.Title = "Exercise 10.";
            double sumSeq = 1, j = 0;

            for (int i = 1; i < 1000; i++)
            {
                j = i;
                sumSeq += (1 / j);
            }
            Console.WriteLine("{0:0.000}", sumSeq);
        }
    }
/*
 * Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...
*/