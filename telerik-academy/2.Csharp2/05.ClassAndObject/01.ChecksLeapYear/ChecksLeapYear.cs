using System;
/*
 * Write a program that reads a year from the console and checks whether it is a leap.
 * Use DateTime.
 */
class ChecksLeapYear
{
    static void Main()
    {
        Console.Write("Enter a year: ");
        int year = int.Parse(Console.ReadLine());

        bool isLeapYear = DateTime.IsLeapYear(year);

        Console.WriteLine("The year is leap ? :" + isLeapYear);
    }
}

