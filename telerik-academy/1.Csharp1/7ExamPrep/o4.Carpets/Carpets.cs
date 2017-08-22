using System;

class Carpets
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int[,] matrix = new int[N, N];

        int startSlash = N / 2 - 1;
        int endSlash = N / 2 - 1;

        bool isSlash = true;

        for (int row = 0; row < N / 2; row++)
        {
            for (int col = 0; col < N / 2; col++)
            {
                if (startSlash <= col && col <= endSlash)
                {
                    if (isSlash)
                    {
                        matrix[row, col] = 2;
                        matrix[row, N - 1 - col] = 3;
                        matrix[N - 1 - row, col] = 3;
                        matrix[N - 1 - row, N - 1 - col] = 2;
                        isSlash = false;
                    }
                    else
                    {
                        matrix[row, col] = 1;
                        matrix[row, N - 1 - col] = 1;
                        matrix[N - 1 - row, col] = 1;
                        matrix[N - 1 - row, N - 1 - col] = 1;
                        isSlash = true;
                    }
                }
            }

            isSlash = true;
            startSlash--;
        }

        // printing
        for (int row = 0; row < N; row++)
        {
            for (int col = 0; col < N; col++)
            {
                if (matrix[row, col] == 0)
                {
                    Console.Write('.');
                }
                else if (matrix[row, col] == 1)
                {
                    Console.Write(' ');
                }
                else if (matrix[row, col] == 2)
                {
                    Console.Write('/');
                }
                else if (matrix[row, col] == 3)
                {
                    Console.Write('\\');
                }
            }

            Console.WriteLine();
        }
    }
}