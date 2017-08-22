using System;
using System.Text;

//Write a program to convert decimal numbers to their binary representation.

class DecimalToBinary
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter decimal number: ");
        int enteredNumber = int.Parse(Console.ReadLine());

        Console.WriteLine(enteredNumber);
        string binaryNumber = ConvertToBinary(enteredNumber);
        Console.WriteLine(binaryNumber);

    }

    private static string ConvertToBinary(int enteredNumber)
    {
        int length = Convert.ToString(enteredNumber, 2).Length;
        int mask;
        int result;
        StringBuilder binary = new StringBuilder();
        for (int i = length - 1; i >= 0; i--)
        {   
            mask = 1 << i;
            result = (enteredNumber & mask) >> i;
            binary.Append(result);
        }

        return binary.ToString();
    }
}
