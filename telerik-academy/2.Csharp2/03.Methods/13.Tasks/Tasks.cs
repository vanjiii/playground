using System;
/*
 * Write a program that can solve these tasks:
    * Reverses the digits of a number
    * Calculates the average of a sequence of integers
    * Solves a linear equation a * x + b = 0
Create appropriate methods.
Provide a simple text-based menu for the user to choose which task to solve.
Validate the input data:
    * The decimal number should be non-negative
    * The sequence should not be empty
    * a should not be equal to 0

 */
class Tasks
{
    static int ReversedNumber(int num)
    {
        if (num < 0)
        {
            Console.WriteLine("please this is not valid input!");
            return -1;
        }
        string result = Convert.ToString(num);
        string res = "";
        for (int i = 0; i < result.Length; i++)
        {
            res += result[result.Length - (1 + i)];
        }
        int intResult = Convert.ToInt32(res);
        return intResult;
    }
    static decimal Average(decimal[] array)
    {
        decimal result;
        decimal numberMembers = array.Length;
        decimal sumOfArray = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sumOfArray += array[i];
        }
        result = sumOfArray / (decimal)numberMembers;
        return result;
    }
    static decimal Equation(decimal a, decimal b)
    {
        decimal x = -b / a;
        return x;
    }
    static void Main()
    {
        Console.WriteLine("What do you want to do...");
        int choice = new int();
        do
        {
             Console.WriteLine(@" Please Enter your choice:
    1 - Reverses the digits of a number
    2 - Calculates the average of a sequence of integers
    3 - Solves a linear equation a * x + b = 0
    0 - Exit");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter the number: ");
                    int num = int.Parse(Console.ReadLine());
                    int resRev = ReversedNumber(num);
                    if (resRev == -1)
                    {
                        break;
                    }
                    Console.WriteLine("The new number is: " + resRev);
                    Console.WriteLine();
                    break;
                case 2:
                    Console.Write("How big do you wanna be your sequence(length of the array :P): ");
                    int arrayLength = int.Parse(Console.ReadLine());
                    if (arrayLength == 0)
                    {
                        Console.WriteLine("The sequence should not be empty!");
                        break;
                    }
                    decimal[] array = new decimal[arrayLength];
                    Console.WriteLine("Enter the sequence: ");
                    for (int i = 0; i < arrayLength; i++)
                    {
                        Console.Write("Member  " + (i + 1) + ": ");
                        array[i] = int.Parse(Console.ReadLine());
                    }
                    decimal resAver = Average(array);
                    Console.WriteLine("The average of the given sequence is: {0:0.000}", resAver);
                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine("Solving a * x + b = 0...");
                    Console.Write("Enter a: ");
                    decimal a = decimal.Parse(Console.ReadLine());
                    if (a == 0)
                    {
                        Console.WriteLine("a should nto be equal to 0!!!");
                        break;
                    }
                    Console.Write("Enter b: ");
                    decimal b = decimal.Parse(Console.ReadLine());
                    decimal resultEq = Equation(a, b);
                    Console.WriteLine("X = {0:0.00}", resultEq);
                    Console.WriteLine();
                    break;
                case 0:  
                    Console.WriteLine("GoodBye :)");
                    Console.WriteLine();
                    break;
                default: Console.WriteLine("Please enter your VALID choice!!!!");
                    break;
            }
        } while (choice != 0);
    }
}

