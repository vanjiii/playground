using System;
/*  _ _ _ 
 * |1 4 7|
 * |2 5 8|
 * |3 6 9|
 *  - - -
 */
class PrintAMatrix
{
    static void Main()
    {
        Console.Write("Enter size of the matrix: ");
        int N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            for (int j = 1; j <= N * N; j+=N)
            {
                Console.Write(j + i + "\t");
            }
            Console.WriteLine();
        }
    }
}
