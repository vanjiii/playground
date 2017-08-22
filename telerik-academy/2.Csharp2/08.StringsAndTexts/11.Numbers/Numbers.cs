using System;
/*
 *Write a program that reads a number and prints it as a decimal number, hexadecimal number, percentage and in scientific notation. 
 *Format the output aligned right in 15 symbols.
 */
class Numbers
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int num = int.Parse(Console.ReadLine());

        ConvertNumber(num);
    }

    private static void ConvertNumber(int num)
    {
        Console.WriteLine("As a decimal: " + num);
        Console.WriteLine("As a hexadecimal: " + num.ToString("X15"));
        Console.WriteLine("As a percentage: " + num.ToString("P15"));
        Console.WriteLine("As a SN: " + num.ToString("E"));
    }
}