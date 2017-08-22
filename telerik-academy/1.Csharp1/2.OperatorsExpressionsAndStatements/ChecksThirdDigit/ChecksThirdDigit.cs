using System;
    class ChecksThirdDigit
    {
        static void Main()
        {
            Console.WriteLine("Enter a digit for check...");
            string num = Console.ReadLine();
            int numberInteger, i;
            int.TryParse(num, out numberInteger);
            i = numberInteger / 100;
            if (i % 10 == 7)
            {
                Console.WriteLine("The Third digit of \"{0}\" is 7",numberInteger);
            }
            else
            {
                Console.WriteLine("No, it's not!");
            }
        }
    }
/*
 Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732  true.
 */