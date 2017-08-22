using System;
/*
 * We are given a matrix of strings of size N x M. 
 * 'Sequences in the matrix' we define as sets of several neighbor elements located on the same line, column or diagonal. 
 * Write a program that finds the longest sequence of equal strings in the matrix. 
 */
class SequenceInMatrix
    {
        static void Main()
        {
            //input
            Console.WriteLine("Enter dimensions of the matrix...");
            Console.Write("row (N): ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("collumn (M): ");
            int M = int.Parse(Console.ReadLine());

            string[,] matrix = new string[N, M];

            Console.WriteLine("Enter the matrix itself: ");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    matrix[i, j] = Console.ReadLine();
                }
            }

            //body
            string currentElement = null;
            int currentRow = 0, currentCol = 0, currentNumber = 0;
            int index = 0;
            int left = 1, diagonal = 1, down = 1;
            int maxLength = 0;
            string stringMaxLength = null;

            //loop
            do
            {
                currentElement = matrix[currentRow, currentCol];

                //compare to the left neighbour
                if (((currentCol + left) < M) && (currentElement == matrix[currentRow, (currentCol + left)]))
                {
                    currentNumber++;
                    left++;
                }//compare to the diagonal neighbour
                else if (  ((currentRow + diagonal) < N)                                                &&
                           ((currentCol + diagonal) < M)                                                &&
                           (currentElement == matrix[(currentRow + diagonal), (currentCol + diagonal)])     )
                {
                    currentNumber++;
                    diagonal++;
                }//compare to the down neighbour
                else if (((currentRow + down) < N) && (currentElement == matrix[(currentRow + down), currentCol])) 
                {
                    currentNumber++;
                    down++;
                }
                else
                {
                    //change currentElement

                    if (currentNumber > maxLength)
                    {
                        maxLength = currentNumber;
                        stringMaxLength = matrix[currentRow, currentCol];
                    }

                    if (currentCol < M - 1)
                    {
                        currentCol++;
                    }
                    else
                    {
                        currentCol = 0;
                        currentRow++;
                    }

                    currentNumber = 0;
                    down = 1;
                    left = 1;
                    diagonal = 1;
                }

                index++;
            } while (index < M * N);

            //print
            Console.WriteLine();
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < M; col++)
                {
                    Console.Write(matrix[row, col] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("length: " + (maxLength + 1));
            Console.WriteLine("string: " + stringMaxLength);
        }
    }
