using System;
/*
 * Write a program to convert binary numbers to their decimal representation.
 */
class BinaryToDecimalRepresantation
    {
    static int BinaryToDecimal(string num)
    {
        int numInt = 0;
        string negativeBin = string.Empty;
        bool isNegative = false;
        //positive number
        if (num[0] == '0')
	    {
		    for (int i = num.Length - 1; i >= 1; i--)
			{
                if (num[i] == '1')
	            {
		            numInt += (int)Math.Pow(2,num.Length - (i + 1));
	            }
			}
	    }
        else
	    {//negative number
            isNegative = true;
            for (int i = 1; i < num.Length; i++)
            {
                if (num[i] == '0')
                {
                    negativeBin += "1";
                }
                else
                {
                    negativeBin += "0";
                }
            }
            for (int ii = negativeBin.Length - 1; ii >= 0; ii--)
            {
                if (negativeBin[ii] == '1')
                {
                    numInt += (int)Math.Pow(2, negativeBin.Length - (ii + 1));
                }
            }
            numInt += 1;
	    }
        if (isNegative)
        {// add '-' if necessary
            numInt *= -1;
        }
        return numInt;
    }
        static void Main()
        {
            Console.Write("Enter a binary number: ");
            string binNum = Console.ReadLine();

            Console.WriteLine("The decimal representation is: " + BinaryToDecimal(binNum));
        }
    }
