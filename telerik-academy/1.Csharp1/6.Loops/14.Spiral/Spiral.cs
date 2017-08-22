using System;

class Spiral
{
    static void Main()
    {
        Console.Title = "The Spiral";

        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n,n];

        int counter = 0;
        int row = 0,rowBig = n-1;
        int column = n - 1,  columnSmall = 0;
        
        do
        {
            for (int i = columnSmall; i <= column; i++)
            {
                counter++;
                matrix[row,i] = counter;                               //right
            }
            row++;
            for (int i = row; i <= rowBig; i++)
            {
                counter++;
                matrix[i, column] = counter;                             //down
            }
            column--;
            for (int i = column; i >= columnSmall; i--)
            {
                counter++;
                matrix[rowBig, i] = counter;                             //right
            }
            rowBig--;
            for (int i = rowBig; i >= row; i--)
            {
                counter++;
                matrix[i, columnSmall] = counter;                             //up
            }

            columnSmall++;
        } while (counter < n * n);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i,j] + "\t");
            }
            Console.WriteLine();
        }

    }
}

/*
* Write a program that reads a positive integer number N (N < 20) from console and outputs in the console the numbers 1 ... N numbers arranged as a spiral.
Example for N = 4
*/