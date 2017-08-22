using System;
/*
 * Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).
 */
class AnyBaseToAny
{
    // this program does not work for negative numbers, because it is not clear the representation of
    //that numbers in numeral system != 2,10,16 ( for instance 3,5,7,6,13, etc.)
    static void Main()
    {
        Console.Write("Enter the number (Please use upper case for hexa..): ");
        string numAnyBase = Console.ReadLine();

        Console.Write("Enter which is this base: ");
        int baseFrom = int.Parse(Console.ReadLine());

        Console.Write("Enter The base you want to converted to: ");
        int baseTo = int.Parse(Console.ReadLine());

        Console.WriteLine(" - > " + ConvertAnyBase(numAnyBase, baseFrom, baseTo));
    }

    private static string ConvertBase(string numAnyBase, byte baseFrom, byte baseTo)
    {// this is for base, based on 2 and 10 base numeral system (2,8,16 and 10)
        return Convert.ToString(Convert.ToInt32(numAnyBase, baseFrom), baseTo);
    }

    static string ConvertAnyBase(string numAnyBase, int baseFrom, int baseTo)
    {
        /*
                        base from -> decimal -> base to
        */



        //-------------base from -> decimal----------
        int decimalNumber = new int();

        if (baseFrom != 10)
        {
            decimalNumber = AnyBaseToDecimal(numAnyBase, baseFrom);
        }
        else
        {
            //baseFrom == 10
            decimalNumber = Convert.ToInt32(numAnyBase);
        }



        //-------------decimal -> base to -----------
        string finalNumber = string.Empty;
        if (baseTo > 10)
        {
            finalNumber = DecimalToAnyBase(decimalNumber, baseTo);
        }
        else
        {
            //base to == 10
            finalNumber = Convert.ToString(decimalNumber);
        }

        return finalNumber;
        
    }

    private static string DecimalToAnyBase(int decimalNumber, int baseTo)
    {
        int carry = 0;
        string tempString = string.Empty;
        string result = string.Empty;
        do
        {
            //char % base = remainder
            carry = decimalNumber % baseTo;
            decimalNumber /= baseTo;
            if (carry > 9)
            {
                switch (carry)
                {
                    case 10:
                        tempString += "A";
                        break;
                    case 11:
                        tempString += "B";
                        break;
                    case 12:
                        tempString += "C";
                        break;
                    case 13:
                        tempString += "D";
                        break;
                    case 14:
                        tempString += "E";
                        break;
                    case 15:
                        tempString += "F";
                        break;
                }
            }
            else
            {
                tempString += Convert.ToString(carry);
            }
            
        } while (decimalNumber != 0);

        for (int i = tempString.Length - 1; i >= 0; i--)
        {
            result += tempString[i]; 
        }
        return result;
    }

    private static int AnyBaseToDecimal(string numAnyBase, int baseFrom)
    {
        //base form < 10
             //  char * (base) ^ position

        int decimalNum = 0;
        for (int i = numAnyBase.Length - 1; i >= 0; i--)
        {
            if ((int)(numAnyBase[i] - '0') > 9)
            {
                decimalNum += (int)(numAnyBase[i] - '7') * ((int)Math.Pow(baseFrom, (numAnyBase.Length - (1 + i))));
            }
            else
            {
                decimalNum += (int)(numAnyBase[i] - '0') * (   (int)Math.Pow(baseFrom, (numAnyBase.Length - (1 + i)))    );
            }
        }
        return decimalNum;
    }
}