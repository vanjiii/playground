using System;

class XExpression
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        //initialize
        char blank = '.';
        char border = '*';

        //top
        int widthTop = ((N * 2 + 1) - N) / 2;
        Console.Write(new string(blank, widthTop));
        Console.Write(new string(border, N));
        Console.WriteLine(new string(blank, widthTop));

        //upper body
        for (int ii = 0; ii < widthTop - 1; ii++)
        {
            Console.Write(new string (blank, widthTop - 1 - ii));
            Console.Write(border);
            Console.Write(new string(blank, widthTop - 1 + ii));
            Console.Write(border);
            Console.Write(new string(blank, widthTop - 1 + ii));
            Console.Write(border);
            Console.WriteLine(new string(blank, widthTop - 1 - ii));
        }

        //middle
        Console.WriteLine(new string(border, (N * 2) + 1));

        //the body
        for (int j = 0; j < N - 1; j++)
        {
            Console.Write(new string(blank, 1 + j));
            Console.Write(border);
            Console.Write(new string(blank, N - 2 - j));
            Console.Write(border);
            Console.Write(new string (blank, N - 2 - j));
            Console.Write(border);
            Console.WriteLine(new string(blank, 1 + j));
        }

        //bottom
        Console.Write(new string(blank, N));
        Console.Write(new string(border, 1));
        Console.WriteLine(new string(blank, N));
    }
}
