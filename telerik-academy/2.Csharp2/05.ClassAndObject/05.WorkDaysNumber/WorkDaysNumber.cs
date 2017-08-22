using System;
/*
 * Write a method that calculates the number of workdays between today and given date, passed as parameter.
 * Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.
 */
class WorkDaysNumber
{
    static void Main()
    {
        //get the current day
        DateTime today = DateTime.Today;

        //get the last day
        Console.WriteLine("Enter date (DD-Mmm-YYYY): ");
        Console.Write("\"Mmm\" means the first three letters of the month name..");
        string finalDayAsString = Console.ReadLine();
        DateTime finalDay = DateTime.Parse(finalDayAsString);

        //how many days are there in this period
        int AllDaysBetween = (finalDay - today).Days;
        int countWorkingDays = 0;

        //initializing holidays
        //just some days, not the real ones :)
        DateTime[] holidays = {
                                  new DateTime(2014, 1, 1),
                                  new DateTime(2014, 3, 3),
                                  new DateTime(2014, 6, 2),
                                  new DateTime(2014, 9, 6),
                                  new DateTime(2014, 4, 7)
                              };

        for (int i = 0; i < AllDaysBetween; i++)
        {
            //if it is sutarday || sunday skip counting
            if (today.DayOfWeek == DayOfWeek.Saturday || today.DayOfWeek == DayOfWeek.Sunday)
            {
                today = today.AddDays(i);
                continue;
            }
            
            //if the day match with some of the holidays skip counting again
            foreach (var item in holidays)
            {
                if (today == item)
                {
                    continue;
                }
                
            }
            countWorkingDays++;
            today = today.AddDays(i);
        }

        Console.WriteLine("Working days: " + countWorkingDays);
    }
}