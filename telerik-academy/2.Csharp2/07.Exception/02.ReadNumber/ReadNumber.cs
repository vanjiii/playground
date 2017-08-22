using System;
/*
 * Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end].
 * If an invalid number or non-number text is entered, the method should throw an exception.
 * Using this method write a program that enters 10 numbers:
			a1, a2, … a10, such that 1 < a1 < … < a10 < 100

 */
class ReadNum
{
    private static int ReadNumber(string start, string end)
    {
        Random rnd = new Random();
        try
        {
            int s = int.Parse(start);
            int e = int.Parse(end);
            return rnd.Next(s, e);
        }
        catch (System.FormatException)
        {
            throw new Exception ("Some of the arguments are not a number! ");
        }
        catch (System.OverflowException)
        {
            throw new Exception ("Enter smaller number! ");
        }
        catch(ArgumentOutOfRangeException)
        {
            throw new Exception("The first num must lesser! ");
        }
    }
    static void Main()
    {
        Console.Write("Start num: ");
        string first = Console.ReadLine();
        Console.Write("End num: ");
        string second = Console.ReadLine();

        Console.WriteLine(ReadNumber(first, second));
    }
}