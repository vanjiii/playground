using System;
using System.Collections.Generic;
using System.IO;
/*
 * Write a program that reads a list of words from a file words.txt and finds how many times each of the words is contained in another file test.txt.
 * The result should be written in the file result.txt and the words should be sorted by the number of their occurrences in descending order.
 * Handle all possible exceptions in your methods.
 */
class WordsOccurrence
{
    static void Main()
    {
        try
        {

            string text = string.Empty;
            string tempText = string.Empty;
            List<int> index = new List<int>();
            List<string> pattern = new List<string>();

            //read
            using (StreamReader rdr = new StreamReader(@"..\..\Files\pattern.txt"))
            {
                int i = 0;
                tempText = rdr.ReadLine();
                index.Add(i);
                pattern.Add(tempText);
                while (tempText != null)
                {
                    tempText = rdr.ReadLine();
                    index.Add(i);
                    pattern.Add(tempText);
                }
            }
        
            int[] numberOfElements = new int[index.Count];
            string[] elements = new string[index.Count];

            numberOfElements = index.ToArray();
            elements = pattern.ToArray();

            using (StreamReader str = new StreamReader(@"..\..\Files\vpn.txt"))
            {
                text = str.ReadToEnd();
            }

            //count equal elements
            for (int j = 0; j < elements.Length - 1; j++)
            {
                int k = text.IndexOf(elements[j],0);
                while (k != -1)
                {
                    k = text.IndexOf(elements[j], k + 1);
                    numberOfElements[j]++; 
                }
            }

            //sort
            for (int jj = 0; jj < numberOfElements.Length - 1; jj++)
		    {
                string tempStr = string.Empty;
                int indexOfElement = jj;
                int maxElement = numberOfElements[jj];
                for (int i = 1; i < index.Count - 1; i++)
                {
                    if (maxElement < numberOfElements[i])
                    {
                        indexOfElement = i;
                    }
                    else
                    {
                        continue;
                    }
                }

                numberOfElements[jj] ^= numberOfElements[indexOfElement];
                numberOfElements[indexOfElement] ^= numberOfElements[jj];
                numberOfElements[jj] ^= numberOfElements[indexOfElement];

                tempStr = elements[jj];
                elements[jj] = elements[indexOfElement];
                elements[indexOfElement] = tempStr;
		    }

            using (StreamWriter wrt = new StreamWriter(@"..\..\Files\output.txt"))
            {
                for (int ii = 0; ii < elements.Length; ii++)
                {
                    wrt.WriteLine(elements[ii]);
                }
            }
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }

        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }

        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }

        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}