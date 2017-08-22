using System;
/*
 * Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.
 */
class MaxSquareSum
{
    static void Main()
    {
        Console.WriteLine("Enter dimensions of the matrix...");
        Console.Write("row (N > 3): ");
        int N = int.Parse(Console.ReadLine());
        Console.Write("collumn (M > 3): ");
        int M = int.Parse(Console.ReadLine());

        int[,] matrix = new int[N, M];

        Console.WriteLine("Enter the matrix itself: ");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        int sum = int.MinValue;
        int localSum = 0;
        int firstElementRow = 0, firstElementCol = 0;
        int currentRow = 0, currentCol = 0;

        do
        {
            for (int row = currentRow; row <= currentRow + 2; row++)
            {
                for (int col = currentCol; col <= currentCol + 2; col++)
                {
                    localSum += matrix[row, col];
                }
            }

            if (localSum > sum)
            {
                sum = localSum;
                firstElementRow = currentRow;
                firstElementCol = currentCol;
            }

            if (currentCol + 3 >= M)
            {
                currentCol = 0;
                currentRow++;
            }
            else
            {
                currentCol++;
            }

            localSum = 0;
        } while (currentRow + 3 <= N);

        //print
        Console.WriteLine();
        Console.WriteLine("Result: ");
        for (int row = 0; row < N; row++)
        {
            for (int col = 0; col < M; col++)
            {
                Console.Write(matrix[row, col] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine("sum: " + sum);
        Console.WriteLine("First element: " + matrix[firstElementRow, firstElementCol]);
        Console.WriteLine("3 X 3: ");
        for (int row = firstElementRow; row <= firstElementRow + 2; row++)
        {
            for (int col = firstElementCol; col <= firstElementCol + 2; col++)
            {
                Console.Write(matrix[row, col] + "\t");
            }
            Console.WriteLine();
        }
    }
}
