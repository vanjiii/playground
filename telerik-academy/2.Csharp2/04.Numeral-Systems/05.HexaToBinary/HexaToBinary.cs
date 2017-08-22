using System;
/*
 * Write a program to convert hexadecimal numbers to binary numbers (directly).
 */
class HexaToBinary
    {
        private static string HexaToBinary(string hexaNum)
        {
            //simple convert hexadecimal to binary
            string binary = string.Empty;
            char tempChar = new char();
            for (int i = 0; i < hexaNum.Length; i++)
            {
                tempChar = hexaNum[i];
                switch (tempChar)
                {
                    case 'A':
                        binary += "1010";
                        break;
                    case 'B':
                        binary += "1011";
                        break;
                    case 'C':
                        binary += "1100";
                        break;
                    case 'D':
                        binary += "1101";
                        break;
                    case 'E':
                        binary += "1110";
                        break;
                    case 'F':
                        binary += "1111";
                        break;
                    default:
                        int numBin = (int)(tempChar - '0');
                        binary += Convert.ToString(numBin, 2);
                        break;
                }
            }
            
           
            return binary;
        }
        static void Main()
        {
            Console.Write("Enter your hexanum: ");
            string num = Console.ReadLine();

            Console.WriteLine("The binary repres: " + HexaToBinary(num));
        }
    }