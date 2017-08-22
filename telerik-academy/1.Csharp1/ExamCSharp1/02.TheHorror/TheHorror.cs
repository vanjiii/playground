using System;
using System.Numerics;

 
class TheHorror
{
    static void Main()
    {
        checked
        {
            string inputString = Console.ReadLine();
            //int convertString = int.Parse(inputString);
            //if (convertString < 0)
            //{
            //    convertString *= (-1);
            //}
            //string newString = Convert.ToString(convertString);

            BigInteger digits = 0;
            int countDigit = 0;

            for (int ii = 0; ii < inputString.Length; ii++)
            {
                // have to remove the . - asfdg....................!!!!!!!!!!!!!!!!!!!!!
                if ((ii % 2 == 0) && (inputString[ii] != '-'))
                {
                    digits += BigInteger.Parse(inputString[ii].ToString());
                    countDigit++;
                }
            }
            Console.WriteLine(countDigit + " " + digits);
        }
    }
}
