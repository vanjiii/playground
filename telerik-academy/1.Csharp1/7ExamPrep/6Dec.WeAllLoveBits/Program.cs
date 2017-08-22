using System;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        string currentNumberToBinary = "";
        
        
        for (int i = 0; i < N; i++)
        {
            int currentNumber = int.Parse(Console.ReadLine());

            currentNumberToBinary = Convert.ToString(currentNumber, 2);
            string[] newNumber = new string [currentNumberToBinary.Length];

            for (int ii = 0; ii < currentNumberToBinary.Length; ii++)
            {
                int currentIndex = currentNumberToBinary.Length;
                newNumber[currentIndex - ii] = currentNumberToBinary[ii].ToString(); 
            }

            for (int j = 0; j < currentNumberToBinary.Length; j++)
            {
                Console.WriteLine(newNumber[j]);
                
            }
            
        }

        
    }
}
