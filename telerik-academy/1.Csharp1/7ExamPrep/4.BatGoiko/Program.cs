using System;

class Program
{
    static void Main()
    {
        //enter the height of the tower
        byte towerHeight = byte.Parse(Console.ReadLine());

        //initialize
        char blank = '.';
        char leftSide = '/';
        char rightSide = '\\';
        char crossBeam = '-';
        bool IsNeedCrossbeam = false;
        int countCrossBeam = 1;
        int difference = 2;

        //build

        //the top
       

        
        for (int i = 0; i < towerHeight; i++)
        {
            if (countCrossBeam == i)
            {
                IsNeedCrossbeam = true;
                countCrossBeam = difference + i;
                difference++;
            }
            if (IsNeedCrossbeam)
            {
                Console.Write(new string(blank, (towerHeight - i) - 1));
                Console.Write(leftSide);
                Console.Write(new string(crossBeam, (i * 2)));
                Console.Write(rightSide);
                Console.WriteLine(new string(blank, (towerHeight - i) - 1));
            }
            else
            {
                Console.Write(new string(blank, (towerHeight - i) - 1));
                Console.Write(leftSide);
                Console.Write(new string(blank, (i * 2)));
                Console.Write(rightSide);
                Console.WriteLine(new string(blank, (towerHeight - i) - 1));
            }

            IsNeedCrossbeam = false;
            //crossBeam--;

        }
    }
}
