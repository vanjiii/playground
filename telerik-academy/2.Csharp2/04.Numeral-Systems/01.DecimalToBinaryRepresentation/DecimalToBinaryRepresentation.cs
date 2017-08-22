using System;
/*
 * Write a program to convert decimal numbers to their binary representation.
 */
class DecimalToBinaryRepresentation
{
    static string DecimalToBinary(int num)
    {
        string numString = string.Empty;
        int carry = 0;
        bool isPositiveNumber = true;
        //checks if the number is negative
        if (num < 0)
        {
            num = num ^ int.MaxValue;
            num += 1;
            isPositiveNumber = false;
        }
        //converts binary to decimal -> 1*2^(index)
        //and decrease the original number to zero
        do
        {
            carry = num % 2;
            num /= 2;
            if (carry == 0)
            {
                numString += "0";
            }
            else
            {
                numString += "1";
            }
        } while (num != 0);
        string realNum = string.Empty;
        //swap the positions of the chars of the string
        for (int i = 0; i < numString.Length; i++)
        {
            realNum += numString[numString.Length - (1 + i)];
        }
        //add if need '0' or '1'
        if (!isPositiveNumber)
        {
            realNum = realNum.PadLeft(32, '1');
        }
        else
        {
            realNum = realNum.PadLeft(32, '0');
        }
        return realNum;
    }
    static void Main()
    {
        Console.Write("Enter a decimal number: ");
        int decimalNumber = int.Parse(Console.ReadLine());

        //call the method
        string result = DecimalToBinary(decimalNumber);
        Console.WriteLine(result);
    }
}

