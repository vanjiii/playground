using System;
/*
 * * Write a program that shows the internal binary representation of given 32-bit signed floating-point number in IEEE 754 format (the C# type float).
 * Example: -27,25  sign = 1, exponent = 10000011, mantissa = 10110100000000000000000.
 */
class FloatingPointRepresentation
    {
        static void Main()
        {
            Console.Write("Enter a float number: ");
            decimal originalNumber = decimal.Parse(Console.ReadLine());

            Console.WriteLine(FloatRepresentation(originalNumber));
        }

        private static string FloatRepresentation(decimal num)
        {
            int sign = 0;
            string mantissa = string.Empty;
            string exponent = string.Empty;
            decimal doublePart = 0;
            int wholePart = 0;
            string mantissaDouble, mantissaWhole;

            if (num < 0)
            {
                //Gets the sign of the number
                sign = 1;
                num *= (-1);
            }

            //get only the fraction
            doublePart = num % 1;

            //get the whole part of the number
            wholePart = (int)num;

            //get the binary representation of each part
            mantissaWhole = DecimalToBinary(wholePart);
            mantissaDouble = DecimalToBinaryFraction(doublePart);

            //create the mantissa
            if (mantissaWhole != "0")
            {
                for (int i = 1; i < mantissaWhole.Length; i++)
                {
                    mantissa += mantissaWhole[i];
                }
                exponent = Convert.ToString((mantissaWhole.Length - 1) + 127, 2);
                mantissa += mantissaDouble;
            }
            else
            {
                //mantissa.length == 0 -> there are no whole part, only fraction
                int length = new int();
                for (int i = 0; i < mantissaDouble.Length; i++)
                {
                    if (mantissaDouble[i] == '0')
                    {
                        length++;
                    }
                    else
                    {
                        length++;
                        break;
                    }
                }
                exponent = Convert.ToString(127 - length, 2);
                for (int jj = length + 1; jj < mantissaDouble.Length; jj++)
                {
                    mantissa += mantissaDouble[jj];
                }
            }
            return sign + " | " + exponent.PadLeft(8, '0') + " | " + mantissa.PadRight(23, '0');
        }

        private static string DecimalToBinaryFraction(decimal doublePart)
        {
            int index = 0;
            string manitssaFraction = string.Empty;
            do
            {
                doublePart *= 2;
                if (doublePart > 1)
                {
                    manitssaFraction += "1";
                    doublePart -= 1;
                }
                else if (doublePart == 1)
                {
                    manitssaFraction += "1";
                }
                else
                {
                    manitssaFraction += "0";
                }
                index++;
                if (index == 23)
                {
                    break;
                }
            } while (doublePart != 1);
            return manitssaFraction;
        }
        static string DecimalToBinary(int num)
        {
            string numString = string.Empty;
            int carry = 0;
            bool isPositiveNumber = true;
            //checks if the number is negative
            //if (num < 0)
            //{
            //    num = num ^ int.MaxValue;
            //    num += 1;
            //    isPositiveNumber = false;
            //}
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
            //else
            //{
            //    realNum = realNum.PadLeft(32, '0');
            //}
            return realNum;
        }
    }