using System;
    class SumOfNumbers
    {
        static void Main()
        {
            Console.Title = "Exercises 7.";

            int sum = 0, i, o = 0;

            while (true)
            { 
                Console.Write("Enter a number to handle with: ");
              
                string j = Console.ReadLine();
                int.TryParse(j, out i);

                while (i > 0)
                {
                    string k = Console.ReadLine();
                    int.TryParse(k, out o);
                    i--;
                }
                sum += o;
                
                Console.WriteLine("The sum is: " + sum);
              
            }
            
        }
    }
/*
Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum. 
*/