using System;
class Program02
{
    static void Main()
    {
        string[] Input = Console.ReadLine().Split(',');
        int[] terrain = new int[Input.Length];
        for (int i = 0; i < Input.Length; i++)
        {
            terrain[i] = int.Parse(Input[i]);
        }
        int bestResult = 1;
        for (int i = 0; i < terrain.Length; i++)
        {
            for (int j = 1; j < terrain.Length; j++)
            {
                int result = Check(i, j, terrain);
                if (result > bestResult)
                {
                    bestResult = result;
                }
            }
        }
        Console.WriteLine(bestResult);
    }

    private static int Check(int startPosition, int step, int[] terrain)
    {
        int result = 0;
        int lastPositionNumber = int.MinValue;
        int currentPosition = startPosition;
        do
        {
            lastPositionNumber = terrain[currentPosition];
            result++;
            currentPosition += step;
            if (currentPosition >= terrain.Length)
            {
                currentPosition -= terrain.Length;
            }
        } while (terrain[currentPosition] > lastPositionNumber);
        return result;
    }
}