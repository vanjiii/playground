using System;
using System.IO;
using System.Text;
/*
 * Write a program that reads a text file containing a square matrix of numbers and finds in the matrix an area of size 2 x 2 with a maximal sum of its elements. The first line in the input file contains the size of matrix N. Each of the next N lines contain N numbers separated by space. The output should be a single number in a separate text file. Example:
4
2 3 3 4
0 2 3 4	 ->  17
3 7 1 2
4 3 3 2

 */
class SubsumOfMatrix
{
    static void Main()
    {
        StreamReader inputText = new StreamReader(@"..\..\Files\matrix.txt");

        int size = new int();


        using (inputText)
        {
            string line = inputText.ReadLine();
            size = int.Parse(line);
            int[,] matrix = new int[size, size];
            line = inputText.ReadLine();
            int row = 0;

            while (line != null)
            {
                string[] elements = line.Split(' ');
                for (int i = 0; i < size; i++)
                {
                    matrix[row, i] = int.Parse(elements[i]);
                }
                line = inputText.ReadLine();
                row++;
            }


            int sum = 0;
            int localSum = 0;

            for (row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (row + 1 < size && col + 1 < size)
                    {
                        localSum = localSum + matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    }
                    if (localSum > sum)
                    {
                        sum = localSum;
                    }
                    localSum = 0;
                }
            }
            Console.WriteLine(sum + "\t");
        }
       
    }
}