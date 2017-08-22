using System;

class PrintCurrentTimeDate
{
    static void Main()
    {
        DateTime timenow = DateTime.Now;
        Console.Title = "Current Time";
        Console.WriteLine(timenow);
    }
}
