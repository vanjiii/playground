using System;

    class ReadAgePrintPlus10
    {
        static void Main()
        {
            string Age;
            decimal RealAge;
            Console.Title = "Age";
            Console.WriteLine("Please enter your age: ");
            Age = Console.ReadLine();
            RealAge = System.Convert.ToDecimal(Age);
            Console.WriteLine("Your age in 10 years will be: " + (RealAge + 10));
        }
    }
