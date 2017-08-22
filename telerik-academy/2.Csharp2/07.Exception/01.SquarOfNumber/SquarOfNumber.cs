using System;
/*
 *Write a program that reads an integer number and calculates and prints its square root.
 *If the number is invalid or negative, print "Invalid number". In all cases finally print "Good bye". Use try-catch-finally.
 */
class SquarOfNumber
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        string str = Console.ReadLine();
        try
        {
            int num = int.Parse(str);
            int result = SquareRoot(num);
            Console.WriteLine("The square of {0} is: {1}", num, result);
        }
        catch (System.FormatException)
        {
            Console.WriteLine("Invalid Number!");
        }
        catch(System.OverflowException)
        {
            Console.WriteLine("Invalid Number!");
        }
        finally
        {
            Console.WriteLine("Good-Bye");
        }
    }

    private static int SquareRoot(int num)
    {
        return num * num;
    }
}