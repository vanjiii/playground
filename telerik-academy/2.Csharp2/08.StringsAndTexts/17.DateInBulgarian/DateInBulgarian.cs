using System;
using System.Globalization;
/*
 * Write a program that reads a date and time given in the format: day.month.year hour:minute:second and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.

 */
class DateInBulgarian
{
    static void Main()
    {
        Console.Write("Enter date: ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        date = date.AddHours(6.5);

        Console.WriteLine(date.ToString(new CultureInfo("bg-BG")));
    }
}