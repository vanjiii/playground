using System;
    class StringsAndObjectVariables
    {
        static void Main()
        {
            string firtsString = "Hello", secondString = "world";
            object concatenation;
            concatenation = string.Format("{0}  {1} !", firtsString, secondString);
            Console.WriteLine(concatenation);
            
        }
    }
/*
Declare two string variables and assign them with “Hello” and “World”. Declare an object variable and assign it with the concatenation of the first two variables (mind adding an interval). Declare a third string variable and initialize it with the value of the object variable (you should perform type casting).
*/