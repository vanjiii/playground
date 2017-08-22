using System;
    class ExchangeValuesOfNumbers
    {
        static void Main()
        {
            byte firstNumber = 5;
            byte secondNumber = 10;
            byte helpfulNumber;
            Console.WriteLine(new string ('*',50) +
                "\nBefore the exchange\n" +
                new string ('*',50));
            Console.WriteLine("The first number: " + firstNumber);
            Console.WriteLine("The second number: " + secondNumber);

            helpfulNumber = firstNumber;
            firstNumber = secondNumber;
            secondNumber = helpfulNumber;

            Console.WriteLine(new string('*', 50) +
                "\nAfter the exchange\n" +
                new string('*', 50));
            Console.WriteLine("The first number: " + firstNumber);
            Console.WriteLine("The second number: " + secondNumber);

        }
    }
    /*
     Declare  two integer variables and assign them with 5 and 10 and after that exchange their values.

     */