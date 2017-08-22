using System;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        //initialize
        char blank = '.';
        char fire = '#';
        char leftTorch = '\\';
        char rightTorch = '/';
        char topBody = '-';

        //Print the upper body of the flame
        for (int i = 0; i < N / 2; i++)
        {
            Console.Write(new string(blank, (N / 2) - i - 1));
            Console.Write(new string(fire,1));
            Console.Write(new string(blank, i * 2));
            Console.Write(new string (fire, 1));
            Console.WriteLine(new string (blank, (N / 2) - i - 1));
        }

        //Lower part of the  flame
        for (int i = 0; i < N / 4; i++)
        {
            Console.Write(new string(blank,i));
            Console.Write(new string (fire, 1));
            Console.Write(new string(blank, N - ((i + 1) * 2)));
            Console.Write(new string(fire,1));
            Console.WriteLine(new string(blank, i));
        }

        //Print the top body of the torch
        Console.WriteLine(new string(topBody, N));

        // The torch itself
        for (int i = 0; i < N / 2; i++)
        {
            Console.Write(new string(blank,i));
            Console.Write(new string(leftTorch,(N / 2) - i));
            Console.Write(new string(rightTorch,(N / 2) - i));
            Console.WriteLine(new string(blank, i));
        }
    }
}

/*
 * print on the console a torch of fire with width N following the examples below.
 */


//For optimisation, it can be used "stringBuilder" from system.Text
//StringBuilder picture = new StringBuilder();
//Console.Write = picture.Append
//Console.WriteLine = picture.AppendLine
