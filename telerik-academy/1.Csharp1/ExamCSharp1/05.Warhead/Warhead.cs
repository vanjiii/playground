using System;

class Warhead
{
    static void Main()
    {
        //enter the matrix
        string currentSymbol = "";
        string[,] matrix = new string[16, 16];

        for (int i = 0; i < 16; i++)
        {
            currentSymbol = Console.ReadLine();

            for (int col = 0; col < 16; col++)
            {
                matrix[i, col] = currentSymbol[col].ToString();
            }
            
        }

        //input the different command
        string inputCommand = Console.ReadLine();
        int XCoordinate = int.Parse(Console.ReadLine());
        int YCoordinate = int.Parse(Console.ReadLine());

        //hover command
        if (inputCommand == "hover")
        {
            if (matrix[XCoordinate, YCoordinate] == "0")
            {
                Console.WriteLine("-");
            }
            else
            {
                Console.WriteLine("*");
            }
        }

        //operate command
        if (inputCommand == "operate")
        {
            if (matrix[XCoordinate,YCoordinate] == "1")
            {
                Console.WriteLine("BOOM");
            }
            else
            {
                for (int k = XCoordinate; k < XCoordinate + 7; k++)
                {
                      
                }
            }
        }

        //output
        //Console.WriteLine("this is the output: ");
        //for (int row = 0; row < 16; row++)
        //{
        //    for (int col = 0; col < 16; col++)
        //    {
        //        Console.Write(matrix[row,col]);
        //    }
        //    Console.WriteLine();
        //}
    }
}

