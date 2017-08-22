using System;
    class IntegerDividedBy5Or7
    {
        static void Main()
        {
            Console.WriteLine("Enter a number: ");
            string randomNumber = Console.ReadLine();
            int randomInteger;
            int.TryParse(randomNumber, out randomInteger);
            if (randomInteger % 5 == 0 && randomInteger % 7 == 0 )
            {
                Console.WriteLine("You won!");
            }
            else
            {
                Console.WriteLine("This number can not be divided by 5 and 7 at the same time!");
            }
        }
    }
/*
 Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.
 */