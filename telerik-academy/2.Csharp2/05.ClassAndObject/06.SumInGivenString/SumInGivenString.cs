using System;
using System.Collections.Generic;
/*
 * You are given a sequence of positive integer values written into a string, separated by spaces.
 * Write a function that reads these values from given string and calculates their sum. 
 * Example:
		string = "43 68 9 23 318"  result = 461
 */
class SumInGivenString
{
    static void Main()
    {
        Console.Write("Enter the value of strings: ");
        string inputValue = Console.ReadLine();

        List<int> num = new List<int>();
        string localNum = string.Empty;

        //push every string in local string 'till gets space
        //then parse this local string to int and add to a list and reinitalize this local string
        for (int i = 0; i < inputValue.Length; i++)
        {
            if (inputValue[i] == ' ')
            {
                num.Add(int.Parse(localNum));
                localNum = "";
                continue;
            }
            localNum += inputValue[i];
        }
        //because it does not get space at the end of the string
        //we miss the last num...and :
        num.Add(int.Parse(localNum));

        int sum = 0;
        //adds all the elements in the list
        foreach (var item in num)
        {
            sum += item;
        }

        Console.WriteLine("The sum is: " + sum);
    }
}