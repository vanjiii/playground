using System;
/*
 * Write a program that creates an array containing all letters from the alphabet (A-Z).
 * Read a word from the console and print the index of each of its letters in the array.
 */
class ReadWord
{
    static void Main()
    {
        //the array of letters
        char[] charArray = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        
        //enter the word to check
        Console.WriteLine("Enter a word, ");
        Console.Write("You can use upper and lower cases: ");
        string iputWord = Console.ReadLine();

        //local variables
        int highestLocation = charArray.Length;
        int lowerLocation = 0;
        int currentLocation = (highestLocation + lowerLocation) / 2;

        //we use the loop 'for', 'cause we might looking for more thah one char(letter)
        //i.e. compare every lettre og the given word
        for (int i = 0; i < iputWord.Length; i++)
        {
            //we reset here the variables, so they can be ready for the next lettre
            highestLocation = charArray.Length;
            lowerLocation = 0;
            currentLocation = (highestLocation + lowerLocation) / 2;

            //look for the char
            while (iputWord[i] != charArray[currentLocation])
            {
                // is it below the current?
                if (charArray[currentLocation] > iputWord[i])
                {
                    highestLocation = currentLocation - 1;
                }
                //or greater thane the greater
                else if (charArray[currentLocation] < iputWord[i])
                {
                    lowerLocation = currentLocation + 1;
                }
                //recompute the current index
                currentLocation = (highestLocation + lowerLocation) / 2; 
            }
            //output + 1 because the array count starts with 0
            Console.Write((currentLocation + 1) + " ");
        }
        Console.WriteLine();
    }
}
