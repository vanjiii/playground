using System;
/*
 * Write a method that returns the last digit of given integer as an English word.
 * Examples: 512  "two", 1024  "four", 12309  "nine".
 */
namespace LastDigit
{
    class LastDigit
    {
        //the method itself
        static string LastDigitFromANumber(int num)
        {
            num = num % 10;
            switch (num)
            {
                case 0: return "zero"; break;
                case 1: return "one"; break;
                case 2: return "two"; break;
                case 3: return "three"; break;
                case 4: return "four"; break;
                case 5: return "five"; break;
                case 6: return "six"; break;
                case 7: return "seven"; break;
                case 8: return "eight"; break;
                case 9: return "nine"; break;
                default: return "ERROR! :P";
                    break;
            }
        }
        static void Main()
        {
            //input
            Console.Write("Enter a number: ");
            int a = int.Parse(Console.ReadLine());
            //calling the method
            string res = LastDigitFromANumber(a);
            //output
            Console.WriteLine("result: " + res);
        }
    }
}
