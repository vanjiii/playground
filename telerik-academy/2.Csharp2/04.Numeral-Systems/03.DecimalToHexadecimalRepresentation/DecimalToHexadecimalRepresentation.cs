using System;
/*
 * Write a program to convert decimal numbers to their hexadecimal representation.
 */
class DecimalToHexadecimalRepresentation
{
    static void Main()
    {
        Console.Write("Enter a decimal number: ");
        int num = int.Parse(Console.ReadLine());

        Console.WriteLine(DecimalToHex(num));
    }

    private static string DecimalToHex(int num)
    {
        string hexaNum = string.Empty;
        string tempBin = string.Empty;
        int localDecimal = 0;
        //convert to binary
        tempBin = DecimalToBinary(num);
        for (int i = 0; i < tempBin.Length; i+=4)
        {
            for (int j = i; j < i + 4; j++)
            {
                if (tempBin[j] == '1')
                {//calculate every four-to-four binary number to decimal  (**** ... **** 0101 ****)
                    localDecimal += (int)Math.Pow(2, ((3 + i) - j));
                }
            }
            //convert that num to hexadecimal
            switch (localDecimal)
            {
                case 10: hexaNum += "A";
                    break;
                case 11: hexaNum += "B";
                    break;
                case 12: hexaNum += "C";
                    break;
                case 13: hexaNum += "D";
                    break;
                case 14: hexaNum += "E";
                    break;
                case 15: hexaNum += "F";
                    break;
                default: hexaNum += Convert.ToString(localDecimal);
                    break;
            }
            localDecimal = 0;
        }
        return hexaNum;
    }

    static string DecimalToBinary(int num)
    {
        string numString = string.Empty;
        int carry = 0;
        bool isPositiveNumber = true;
        if (num < 0)
        {
            num = num ^ int.MaxValue;
            num += 1;
            isPositiveNumber = false;
        }
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
        int length = 0;
        for (int i = 0; i < numString.Length; i++)
        {
            realNum += numString[numString.Length - (1 + i)];
        }
        if (!isPositiveNumber)
        {
            realNum = realNum.PadLeft(32, '1');
        }
        else
        {//add '0' if necessary to .length % 4 = 0
            length = realNum.Length % 4;
            if (length != 0)
            {
                realNum = realNum.PadLeft((4 - length) + realNum.Length, '0');
            }
            
        }
        return realNum;
    }
}
