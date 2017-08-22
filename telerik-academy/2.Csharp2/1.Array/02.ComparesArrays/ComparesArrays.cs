using System;

/*
 Write a program that reads two arrays from the console and compares them element by element.
*/
class ComparesArrays
{
    static void Main()
    {
        //enter the lenght of the array
        Console.Write("Enter length of the array: ");
        int arrayLength = int.Parse(Console.ReadLine());

        //initialize the two arrays
        double[] firstArray = new double [arrayLength];
        double[] secondArray = new double[arrayLength];

        int count = 0;

        //enter array...
        for (int i = 0; i < arrayLength; i++)
        {
            //first array
            Console.Write("Enter the {0} element of the FIRST array: ", i + 1);
            firstArray[i] = int.Parse(Console.ReadLine());

            //second array
            Console.Write("Enter the {0} element of the SECOND array: ", i + 1);
            secondArray[i] = int.Parse(Console.ReadLine());
        }

        for (int ii = 0; ii < arrayLength; ii++)
        {
            if (firstArray[ii] == secondArray[ii])
	        {
		        count++;
	        }
        }
        Console.WriteLine("In the given arrays there are {0} similar elements(at the same position).", count);
    }
}
