using System;

namespace AllPossibleTypesFloatingPointNumber
{
    class AllPossibleTypesFloatingPointNumber
    {
        static void Main(string[] args)
        {
            string numberInString = Console.ReadLine();
            decimal decimalNum = decimal.Parse(numberInString);
            double doubleNum = double.Parse(numberInString);
            float floatNum = float.Parse(numberInString);
            if (numberInString[0] == '-' || numberInString[0] == '+')
            {
                numberInString=numberInString.Remove(0, 1);
            }
            if (decimalNum - (decimal)floatNum == 0 && numberInString.Length < 9)
            {
                Console.WriteLine("decimal; double; float");
            }
            else if (decimalNum - (decimal)doubleNum == 0 && numberInString.Length < 17)
            {
                Console.WriteLine("decimal; double");
            }
            else
            {
                Console.WriteLine("decimal");
            }
            //Console.WriteLine(floatNum);
        }
    }
}
