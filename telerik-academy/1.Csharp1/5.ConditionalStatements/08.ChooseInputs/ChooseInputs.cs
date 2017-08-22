using System;
class ChooseInputs
{
    static void Main()
    {
        Console.Title = "Exercise 8. ";

        Console.WriteLine(@"What type of variables want to input - integer, double or string?
                                        Typed it so we can begin :) 
                                        integer , double or string.");
        Console.Write("Your desire: ");
        string enterWord = Console.ReadLine();

        switch (enterWord)
        {
            case "integer":
                {
                    Console.Write("Enter your number: ");
                    int number = int.Parse(Console.ReadLine());
                    number++;
                    Console.WriteLine("The answer is: " + number);
                    break;
                }
            case "double":
                {
                    Console.Write("Enter your number: ");
                    double number = double.Parse(Console.ReadLine());
                    number++;
                    Console.WriteLine("The answer is: " + number);
                    break;
                }
            case "string":
                    {
                        Console.WriteLine("Enter a string: ");
                        string str = Console.ReadLine();
                        Console.WriteLine("Your string will be: " + str + "*");
                        break;
                    }
            default:
                {
                    Console.WriteLine("Next time don't cheat!");
                    break;
                }
                
        }
    }
}
/*
Write a program that, depending on the user's choice inputs int, double or string variable. If the variable is integer or double, increases it with 1. If the variable is string, appends "*" at its end. The program must show the value of that variable as a console output. Use switch statement.

*/