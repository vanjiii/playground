using System;

//Write a program that finds the maximal sequence of equal elements in an array.

class MaxSequence
{
    static void Main()
    {
        Console.Write("Input the length of the array:"); 
        int n = int.Parse(Console.ReadLine());          //Inputting the lenght of the array
        int maxSequence = 0;                            //Defining a variable to determine what is the maxsequence of numbers
        int numbersInSequence = 0;                      //Defining a variable to help us know how many numbers are in the in the sequnce. If there are 2 equal sequences 
                                                        //for example {2,2,3,3,1} the max sequence is 2, and the numbers in sequence are 4 
        int[] array = new int[n];                       //Defining an array to store the numbers
        int[] arrayEqual = new int[n];                  //Defining an array to store for every number how many equal to it there are in the first array. For example:
                                                        //1 Array: {2,3,2,2,2}     2 Array:{3,0,3,3,3}  

        for (int i = 0; i < n; i++)                     //Filling the first array
        {
            Console.Write("Input {0} number:",i+1);
            array[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < n; i++)                     //Filling the second array and determing what is the max sequence
        {
            for (int j = 0; j < n; j++)
            {
                if((array[i]==array[j])&&i!=j)
                {
                    arrayEqual[i]++;
                }
            }

            if(arrayEqual[i]>maxSequence)
            {
                maxSequence = arrayEqual[i];
            }
        }

        for (int i = 0; i < n; i++)                     //Determine how many numbers are in max sequence
        {
            if(arrayEqual[i]==maxSequence)
            {
                numbersInSequence++;
            }
        }

        int numbersOfMaxSequences= numbersInSequence/(maxSequence+1); //Calculating how many max sequences there are. For example {2,2,3,3,4,4,1,1,} - max sequence:2 
                                                                                                                                                 //number of sequences:4
        int currentNumberInSequence = 0;                              //Defining a variable to help us know for which number we are printing information

        if (maxSequence > 0)                                          //If there is a max sequence bigger than 0 then we should print them out 
        {
            Console.WriteLine("The maximal sequence of equal elements is {0} elements",maxSequence + 1); //First we print how many numbers contains the max sequance

            if ((numbersInSequence / (maxSequence + 1)) > 1)                        //If the sequances are more than 1, we print how many there are 
            {
                Console.WriteLine("There are {0} sequences", numbersInSequence / (maxSequence + 1));
                
            }

            for (int i = 0; i < numbersOfMaxSequences; i++)                         //We run the code for printing a sequance for every max sequance
            {
                for (int j = 0; j < n; j++)                                         //We find the first number which is in max sequance for example in array {2,2,3,3,1,1}
                {                                                                   //The first number in max sequance is 2
                    if(arrayEqual[j]==maxSequence && array[j]!=currentNumberInSequence && array[j]!=0) //We also check if the number is not "0", later I'll explain why
                    {
                        currentNumberInSequence = array[j];                         //We assign "2" to the variable "currentNumberInSequence"
                        break;
                    }
                }
                Console.Write("The element indexes of the {0} sequence are: ",i+1); //Now we print out the indexes of all the numbers which are in this max sequance
                for (int j = 0; j < n; j++)
                {
                    if (arrayEqual[j] == maxSequence && array[j]==currentNumberInSequence) // We print out every number that is in max sequance and that is in the sequance 
                    {                                                                      //that we print. From the last example: {2,2,3,3,1,1,} all the numbers are in  
                        Console.Write(j + " ");                                            //max sequance but I want to print only the indexes of the "2"
                    }
                }
                Console.WriteLine();                        
                Console.Write("The elements are: ");                                        //Now we print the value of this numbers 
                for (int j = 0; j < n; j++)
                {
                    if (arrayEqual[j] == maxSequence && array[j]==currentNumberInSequence)
                    {
                        Console.Write(array[j] + " ");
                    }
                }
                Console.WriteLine();

                for (int j = 0; j < n; j++)                                             //After we have printed that numbers, we dont need to use them anymore 
                {                                                                       //and we replace them with "0". If we leave them their original value, when we search 
                    if(array[j]==currentNumberInSequence)                               //for the second max sequance numbers it will be harder
                    {
                        array[j] = 0;
                    }
                }
            }
        }

        else //maxSequence=0
        {
            Console.WriteLine("All numbers are different, there are {0} sequences of 1 number",n); //if maxsequance is "0" then this means that none of the numbers has 
        }                                                                                          //another number equal to it

        Console.WriteLine();
    }
}