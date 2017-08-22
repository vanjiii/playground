using System;

namespace CompanyEmploees
{
    class CompanyEmploees
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            byte age = byte.Parse(Console.ReadLine());
            string sex = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());
            bool isMale = true;
            if (sex == "female")
            {
                isMale = false;
            }

            Console.WriteLine(firstName + " -> string");
            Console.WriteLine(lastName + "  -> string");
            Console.WriteLine(age + "  -> byte");
            Console.WriteLine(isMale + "  -> bool");
            Console.WriteLine(number + "  -> int");
        }
    }
}
