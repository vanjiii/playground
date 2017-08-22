using System;

class TrailingZeors
{
    static void Main()
    {
        Console.Title = "Trailing zeros. ";

        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());

        int count = 0;

        while (n >= 5)
        {
            n -= 5;
            count++;
        }
        if (count == 0)
        {
            Console.WriteLine("We have NO zeros");
        }
        else
        {
            Console.WriteLine("Number of the zeros are: " + count);
        }
        
    }
}

/*
Write a program that calculates for given N how many trailing zeros present at the end of the number N!. Examples:
N = 10  N! = 3628800  2
N = 20  N! = 2432902008176640000  4
Does your program work for N = 50 000?
Hint: The trailing zeros in N! are equal to the number of its prime divisors of value 5. Think why!
*/