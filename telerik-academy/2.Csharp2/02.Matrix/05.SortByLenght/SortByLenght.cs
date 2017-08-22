using System;
/*
 * You are given an array of strings.
 * Write a method that sorts the array by the length of its elements (the number of characters composing them).
 */
class SortByLenght
    {
        static void Main()
        {
            //input
            Console.WriteLine("Enter lenght of the array: ");
            int N = int.Parse(Console.ReadLine());
            string[] someStrings = new string[N];
            for (int i = 0; i < N; i++)
            {
                someStrings[i] = Console.ReadLine();
            }

            //body
            string moveString = null;
            int index = 0;
            for (int i = 0; i < N; i++)
            {
                string currentElement = someStrings[i];

                for (int j = (i + 1); j < N; j++)
                {
                    if (currentElement.Length > someStrings[j].Length)
                    {
                        currentElement = someStrings[j];
                        index = j;
                    }
                }
                if (currentElement != someStrings[i])
                {
                    moveString = someStrings[i];
                    someStrings[i] = currentElement;
                    someStrings[index] = moveString;
                    index = 0;
                }    
            }
            
            //output
            for (int j = 0; j < N; j++)
            {
                Console.Write(someStrings[j] + "\t");
            }
        }
    }
