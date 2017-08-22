using System;
using System.Globalization;
/*
 * Write a program that reads two dates in the format: day.month.year and calculates the number of days between them. 
 * Example:

        Enter the first date: 27.02.2006
        Enter the second date: 3.03.2004
        Distance: 4 days

 
 */
class DaysBetweenDate
    {
        static void Main()
        {
            Console.Write("Enter first date: ");
            DateTime dateFirst = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.InvariantCulture);
            Console.Write("Enter second date: ");
            DateTime dateSecond = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine((dateSecond - dateFirst).TotalDays);
        }
    }