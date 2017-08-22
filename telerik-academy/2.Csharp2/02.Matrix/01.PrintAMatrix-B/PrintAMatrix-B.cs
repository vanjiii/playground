using System;
/*
 *  _ _ _ _ _
 * |1 8 9  16|
 * |2 7 10 15|
 * |3 6 11 14|
 * |4 5 12 13|
 *  - - - - - 
 */
class PrintAMatrix
{
    static void Main()
    {
        Console.Title = "B";

        Console.Write("Enter size of the matrix: ");
        int N = int.Parse(Console.ReadLine());

        int[,] spiral = new int [N, N];

        int row = 0;
        int coll = 1;

        do
        {
            if (row % 2 == 1)
            {
                for (int i = 0; i < N; i++)
                {
                    spiral[row, i] = (coll + N) - (i + 1);
                }
            }
            else
            {
                for (int i = 0; i < N; i++)
                {
                    spiral[row, i] = coll + i;
                }
            }

            coll += N;
            row++;
        } while (row < N);

        //print
        for ( row = 0; row < N; row++)
        {
            for (int col = 0; col < N; col++)
            {
                Console.Write( spiral[col, row] + "\t" );
            }
            Console.WriteLine();
        }
    }
}

