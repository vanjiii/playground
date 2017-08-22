using System;
/*
 * Write a method that asks the user for his name and prints “Hello, <name>” (for example, “Hello, Peter!”).
 * Write a program to test this method.
 */
namespace ProgramHello
{
    public class HelloPeter
    {
        static void Main()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            PrintName(name);
        }

        public static string PrintName(string a)
        {
            Console.WriteLine("Hello, {0}", a);
            return "Hello, " + a;
        }
    }
}

