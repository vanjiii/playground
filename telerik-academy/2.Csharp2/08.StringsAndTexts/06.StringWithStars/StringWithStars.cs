using System;
/*
 * Write a program that reads from the console a string of maximum 20 characters.
 * If the length of the string is less than 20, the rest of the characters should be filled with '*'.
 * Print the result string into the console.
 */
class StringWithStars
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string text = Console.ReadLine();

        if (text.Length > 20)
        {
            Console.WriteLine("The length is more than 20 symbols");
        }
        else if (text.Length == 20)
        {
            Console.WriteLine("Result: " + text);
        }
        else
        {
            Console.WriteLine("Result: " + text.PadRight(20, '*'));
        }

    }
}