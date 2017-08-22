using System;

class patt
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        long[,] matrix = new long[size, size];
        for (int row = 0; row < size; row++)
        {
            string[] rowStr = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            for (int col = 0; col < size; col++)
			{
                matrix[row, col] = int.Parse(rowStr[col]);
			}
        }
        SearchForPattern(matrix);
    }

    private static void SearchForPattern(long[,] matrix)
    {
        long sum = new long();
        long currentEl = new long();
        long winner = long.MinValue;

        for (int row = 0; row <= matrix.GetLength(0) - 3; row++)
        {
            for (int col = 0; col <= matrix.GetLength(0) - 5; col++)
            {
                currentEl = matrix[row, col];
                if ( currentEl + 1 == matrix[row, col + 1]  &&
                     currentEl + 2 == matrix[row, col + 2]  &&
                     currentEl + 3 == matrix[row + 1, col + 2]  &&
                     currentEl + 4 == matrix[row + 2, col + 2]  &&
                     currentEl + 5 == matrix[row + 2, col + 3]  &&
                     currentEl + 6 == matrix[row + 2, col + 4]     )
                {
                    sum = currentEl + matrix[row, col + 1] +
                                      matrix[row, col + 2] +
                                      matrix[row + 1, col + 2] +
                                      matrix[row + 2, col + 2] +
                                      matrix[row + 2, col + 3] +
                                      matrix[row + 2, col + 4];
                }
                if (winner < sum)
                {
                    winner = sum;
                }
                sum = 0;
            }
        }

        //No
        if (winner == 0)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                winner += matrix[i, i];
            }
            Console.WriteLine("NO {0}", winner);
        }
        else
        {
            Console.WriteLine("YES {0}", winner);
        }
        
    }
}