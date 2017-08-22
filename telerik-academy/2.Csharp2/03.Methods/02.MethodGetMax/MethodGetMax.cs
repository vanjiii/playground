using System;
/*
 * Write a method GetMax() with two parameters that returns the bigger of two integers.
 * Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().
 */

namespace MethodGetMax
{
    class MethodGetMax
    {
        //the method itself
        //it finds the biggest number without real comparing
        static double GetMax(double firstNumber, double secondNumber)
        {
            double averageNum = (firstNumber + secondNumber) / 2;
            double diffNum = Math.Abs((firstNumber - secondNumber) / 2);
            return averageNum + diffNum;
        }
        static void Main()
        {
            // input
            Console.Write("enter first number: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("enter the second number: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("enter the third number: ");
            int c = int.Parse(Console.ReadLine());
            //the comparison
            double maxNum = GetMax(GetMax(a, c), b);
            //output
            Console.WriteLine("the max among the {0}, {1} and {2} is {3}", a, b, c, maxNum);
        }
    }
}
