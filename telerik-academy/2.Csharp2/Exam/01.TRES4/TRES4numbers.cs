using System;
using System.Numerics;
/*
 LON+	0
VK-	1
*ACAD	2
^MIM	3
ERIK|	4
SEY&	5
EMY>>	6
/TEL	7
<<DON	8

 * */

class TRES4Numbers
{
    static void Main()
    {
        string input = Console.ReadLine();
        string result = DecimalToNineBaseConvert(input);
        TRES4(result);
        //Console.WriteLine("in 9 base - " + result);
    }

    private static void TRES4(string result)
    {
        string res = string.Empty;
        for (int i = 0; i < result.Length; i++)
        {
            char currentChar = result[i];
            switch (currentChar)
            {
                case '0': res += "LON+"; break;
                case '1': res += "VK-"; break;
                case '2': res += "*ACAD"; break;
                case '3': res += "^MIM"; break;
                case '4': res += "ERIK|"; break;
                case '5': res += "SEY&"; break;
                case '6': res += "EMY>>"; break;
                case '7': res += "/TEL"; break;
                case '8': res += "<<DON"; break;
                default:
                    break;
            }
        }
        Console.WriteLine(res);
    }

    private static string DecimalToNineBaseConvert(string input)
    {
        BigInteger intInput = BigInteger.Parse(input);
        string numString = string.Empty;
        string res = string.Empty;

        BigInteger carry = 0;

        //convert
        do
        {
            carry = intInput % 9;
            intInput = intInput / 9;
            numString += carry;
        } while (intInput != 0);

        for (int i = numString.Length - 1; i >= 0; i--)
        {
            res += numString[i];
        }

        return res;
    }
}