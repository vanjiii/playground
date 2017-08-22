using System;
using System.Numerics;

class TheSecretsNumbers
{
    static void Main()
    {
        //first line of the input
        BigInteger N = BigInteger.Parse(Console.ReadLine());
        if (N < 0)
        {
            N *= (-1);
        }
        BigInteger sum = 0;
        BigInteger rezult = N;

        //count the digits of the numbers
        BigInteger num = N;
        int count = 0;
        while (num != 0)
        {
            num /= 10;
            count++;
        }

        for (int i = 1; i <= count; i++)
        {
            if (i % 2 != 0)
            {
                sum += (N % 10) * (BigInteger)Math.Pow(i, 2);
                N /= 10;
            }
            else
            {
                BigInteger digit = N % 10;
                string stringdigits = Convert.ToString(digit);
                int digits = int.Parse(stringdigits);
                sum += (BigInteger)Math.Pow(digits, 2) * i;
                N /= 10;
            }
        }
        BigInteger R = sum % 26;
        string alphaSequence = "";

        BigInteger numbersOfLetters = sum % 10;
        for (int i = 1; i <= numbersOfLetters; i++)
        {
            R++;
            while (R > 26)
            {
                R -= 26;
            }
            switch ((int)R)
            {
                case 1:
                    {
                        alphaSequence += "A";
                        break;
                    }
                case 2:
                    {
                        alphaSequence += "B";
                        break;
                    }
                case 3:
                    {
                        alphaSequence += "C";
                        break;
                    }
                case 4:
                    {
                        alphaSequence += "D";
                        break;
                    }
                case 5:
                    {
                        alphaSequence += "E";
                        break;
                    }
                case 6:
                    {
                        alphaSequence += "F";
                        break;
                    }
                case 7:
                    {
                        alphaSequence += "G";
                        break;
                    }
                case 8:
                    {
                        alphaSequence += "H";
                        break;
                    }
                case 9:
                    {
                        alphaSequence += "I";
                        break;
                    }
                case 10:
                    {
                        alphaSequence += "J";
                        break;
                    }
                case 11:
                    {
                        alphaSequence += "K";
                        break;
                    }
                case 12:
                    {
                        alphaSequence += "L";
                        break;
                    }
                case 13:
                    {
                        alphaSequence += "M";
                        break;
                    }
                case 14:
                    {
                        alphaSequence += "N";
                        break;
                    }
                case 15:
                    {
                        alphaSequence += "O";
                        break;
                    }
                case 16:
                    {
                        alphaSequence += "P";
                        break;
                    }
                case 17:
                    {
                        alphaSequence += "Q";
                        break;
                    }
                case 18:
                    {
                        alphaSequence += "R";
                        break;
                    }
                case 19:
                    {
                        alphaSequence += "S";
                        break;
                    }
                case 20:
                    {
                        alphaSequence += "T";
                        break;
                    }
                case 21:
                    {
                        alphaSequence += "U";
                        break;
                    }
                case 22:
                    {
                        alphaSequence += "V";
                        break;
                    }
                case 23:
                    {
                        alphaSequence += "W";
                        break;
                    }
                case 24:
                    {
                        alphaSequence += "X";
                        break;
                    }
                case 25:
                    {
                        alphaSequence += "Y";
                        break;
                    }
                case 26:
                    {
                        alphaSequence += "Z";
                        break;
                    }


            }
        }

        Console.WriteLine(sum);
        if ((sum % 10) != 0)
        {
            Console.WriteLine(alphaSequence);
        }
        else
        {
            Console.WriteLine("{0} has no secret alpha-sequence", rezult);
        }
        
    }
}

