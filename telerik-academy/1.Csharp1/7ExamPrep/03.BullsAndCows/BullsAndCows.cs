using System;

class BullsAndCows
{
    static void Main()
    {
        int secretNumber = int.Parse(Console.ReadLine());
        int bulls = int.Parse(Console.ReadLine());
        int cows = int.Parse(Console.ReadLine());

        //separete the digits
        int[] secretNumberDigit = new int[4];
        int num = secretNumber;
        for (int i = 0; i < 4; i++)
        {
            secretNumberDigit[i] = num % 10;
            num /= 10;
        }

        if (bulls == 4)
        {
            Console.WriteLine(secretNumber);
        }
        else if (bulls == 3)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(secretNumberDigit[]); secretNumberDigit[j]
                }
            }
        }
    }
}