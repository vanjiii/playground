using System;
using System.Linq;
/*
 * Write a program that finds the maximal sequence of equal elements in an array.
		Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.
 */
class MaxSequence
{
    
    static void Main()
    {
        
        //Enter the sequence
        Console.Write(@"Enter a sequence of numbers, separating them 
        by comma, point or blank space: ");
        var enterSequence = Console.ReadLine().Split(' ', ',', '.');
        double[] digits = enterSequence.Select(d => Convert.ToDouble(d)).ToArray();


        int countFirstNumber = 1, countSecondNumber = 0 ;
        double firstNum = digits[0], midNum = digits[0];

        for (int ii = 1; ii < digits.Length; ii++)
        {
            if (firstNum == digits[ii])
            {
                countFirstNumber ++;
            }
            else
            {
                firstNum = digits[ii];
                if (countFirstNumber > countSecondNumber)
                {
                    countSecondNumber = countFirstNumber;
                    midNum = digits[ii - 1];
                }
                countFirstNumber = 1;
            }

        }
        //output
        Console.WriteLine("the new sequence is: ");
        for (int j = 0; j < countSecondNumber; j++)
        {
            Console.Write(midNum + ",");
        }
        Console.Write("\b");
        Console.Write(" ");
        Console.WriteLine();
    }
}