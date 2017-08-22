using System;

namespace OperatorsExpressionsAndStatements
{
    class OddOrEven
    {
        static void Main()
        {
            Console.WriteLine("Enter an integer: ");
            string randomString = Console.ReadLine();
            int randomInteger;
            int.TryParse(randomString, out randomInteger);
            if (randomInteger % 2 == 0)
            {
                Console.WriteLine("The number is even.");
            }
            else
            {
                Console.WriteLine("The number is odd");
            }
        }
    }
}
/*
 Write an expression that checks if given integer is odd or even.
 */