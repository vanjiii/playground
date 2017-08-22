using System;
using System.Linq;

class Doge
{
    static void Main()
    {
        //matrix size
        int[] firstRow = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToArray();
        int colMatrix = firstRow[0];
        int rowMatrix = firstRow[1];

        //food
        firstRow = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToArray();
        int colFood = firstRow[1];
        int rowFood = firstRow[0];

        //enemies
        int numberEnemy = int.Parse(Console.ReadLine());
        int[,] enemies = new int[numberEnemy, 2];
        for (int i = 0; i < numberEnemy; i++)
        {
            firstRow = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToArray();
            enemies[i, 0] = firstRow[0];
            enemies[i, 1] = firstRow[1];
        }

        char[,] lab = new char[rowMatrix, colMatrix];
        for (int row = 0; row < rowMatrix; row++)
        {
            for (int col = 0; col < colMatrix; col++)
            {
                for (int i = 0; i < enemies.GetLength(0); i++)
			    {
			        if ((row == enemies[i, 0]) )
                    {
                        if ((col == enemies[i, 1]))
                        {
                            lab[row, col] = '*';
                        }
                    }
                    else
                    {
                        lab[row, col] = ' ';
                    }
			    }
                
            }
        }
        lab[rowMatrix - 1, colMatrix - 1] = 'e';

        FindPath(0, 0, lab);
    }

    static void FindPath(int row, int col, char[,] lab)
    {
        

        if ((col < 0) || (row < 0) ||
        (col >= lab.GetLength(1)) || (row >= lab.GetLength(0)))
        {
            // We are out of the labyrinth
            return;
        }
        // Check if we have found the exit
        if (lab[row, col] == 'е')
        {
            Console.WriteLine("Found the exit!");
        }
        if (lab[row, col] != ' ')
        {
            // The current cell is not free
            return;
        }
        // Mark the current cell as visited
        lab[row, col] = 's';
        // Invoke recursion to explore all possible directions
        FindPath(row, col - 1, lab); // left
        FindPath(row - 1, col, lab); // up
        FindPath(row, col + 1, lab); // right
        FindPath(row + 1, col, lab); // down
        // Mark back the current cell as free
        lab[row, col] = ' ';
    }

}
