using System;
/*
 * Write a program to convert hexadecimal numbers to their decimal representation.
 */
    class HexaDecimalToDecimal
    {//this method works for 32-bits numbers
        //there are methods used in other exercises :)
        static void Main()
        {
            Console.Write("Enter a hexadecimal number: ");
            string hexaNum = Console.ReadLine();

            Console.WriteLine("The decimal representation is: " + HexaToDecimal(hexaNum));
        }

        private static int HexaToDecimal(string hexaNum)
        {
            char tempChar = new char();
            string binNum = string.Empty;

            for (int i = 0; i < hexaNum.Length; i++)
            {// devide the number char by char and convert it to binary representation
                tempChar = hexaNum[i];
                binNum += HexaToBinary(tempChar);
            }
            if (binNum.Length < 32)
            {
                binNum = binNum.PadLeft(32, '0');
            }
            return BinaryToDecimal(binNum);
        }

        private static string HexaToBinary(char tempChar)
        {
            //simple convert hexadecimal to binary
            string binary = string.Empty;
            switch (tempChar)
            {
                case 'A':
                    binary = "1010";
                    break;
                case 'B':
                    binary = "1011";
                    break;
                case 'C':
                    binary = "1100";
                    break;
                case 'D':
                    binary = "1101";
                    break;
                case 'E':
                    binary = "1110";
                    break;
                case 'F':
                    binary = "1111";
                    break;
                default:
                    int numBin = (int)(tempChar - '0');
                    binary = Convert.ToString(numBin, 2);
                    break;
            }
            return binary;
        }
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
                        numInt += (int)Math.Pow(2, num.Length - (i + 1));
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
    }
