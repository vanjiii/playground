using System;
/*
 *  - - - - - - 
 * |01 12 11 10|
 * |02 13 16 09|
 * |03 14 15 08|
 * |04 05 06 07|
 *  - - - - - -
 */
class PrintAMatrix
{
    static void Main()
    {
        Console.Write("Enter size of the matrix: ");
        int N = int.Parse(Console.ReadLine());

        int[,] matrix = new int[N, N];
        int index = 1;
        int row = N - 1, col = 0;
        int upBoundary = N - 1, downBoundary = 0, leftBoundary = N - 1, rightBoundary = 1;
        int maxUpBoundary = 0, maxDownBoundary = N, maxLeftBoundary = 0, maxRightBoundary = N;

        do
        {
            //down
            for (int i = downBoundary; i < maxDownBoundary; i++)
            {
                matrix[i, col] = index;
                index++;
            }
            col = upBoundary;

            //right
            for (int i = rightBoundary; i < maxRightBoundary; i++)
            {
                matrix[row, i] = index;
                index++;
            }
            row = maxLeftBoundary;

            //up
            for (int i = upBoundary - 1; i >= maxUpBoundary; i--)
            {
                matrix[i, col] = index;
                index++;
            }
            
            //left
            for (int i = leftBoundary - 1; i > maxLeftBoundary; i--)
            {
                matrix[row, i] = index;
                index++;
            }
           
            //recalculate boubdaries
            downBoundary++;
            maxDownBoundary--;

            rightBoundary++;
            maxRightBoundary--;

            upBoundary--;
            maxUpBoundary++;

            leftBoundary--;
            maxLeftBoundary++;

            col = maxUpBoundary;
            row = upBoundary;
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
