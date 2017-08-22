using System;
/*
 * Write a method that reverses the digits of given decimal number.
 * Example: 256  652
 */
class Digits
{
    static string ReverseDigits(int inputNumber)
    {
        string reversedNumber = "";
        do
        {
            int currentDigit = inputNumber % 10;
            reversedNumber = reversedNumber + Convert.ToString(currentDigit);
            inputNumber = inputNumber / 10;
        } while (inputNumber != 0);
        return reversedNumber;
    }
    static void Main()
    {
        Console.Write("Enter the number: ");
        int N = int.Parse(Console.ReadLine());

        string res = ReverseDigits(N);
        Console.WriteLine("the result: " + res);
    }
}