using System;
/*
 *   _ _ _
 *  |4 7 9|
 *  |2 5 8|
 *  |1 3 6|
 *   - - -
 */
class PrintAMatrix
{
    static void Main()
    {
        Console.Write("Enter size of the matrix: ");
        int N = int.Parse(Console.ReadLine());

        int[,] matrix = new int[N, N];
        int index = 1;
        int row = N - 1, rowNominal = N - 1;
        int col = 0;
        int rowIndex = 1, colIndex = 1; ;

        do
        {
            //are we in the boundary of the matrix
            if ((row < N) && (col < N))
            {
                matrix[row, col] = index;
                row++;
                col++;
                index++;
            }
            else
            {
                //restart 'row' with value = row - 1, of the last;
                row = rowNominal - rowIndex;
                col = 0;
                //if row gets negative or equal to '0'
                if ((row <= 0) && (matrix[0,col] != 0))
                {
                    //we are here: row = 0
                    col += colIndex;
                    row = 0;
                    colIndex++;
                }
                else
                {
                    //how we change 'row'
                    //after row gets value > N (out of boundary)
                    rowIndex++;
                }
            }
        } while (index <= N * N);

        //print
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
