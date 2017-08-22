using System;
    class NullValuesOfIntegersAndDoubleVariables
    {
        static void Main()
        {
            int? integerNumber = null;
            double? doubleNumber = null;
            Console.WriteLine("Null numbers: " + integerNumber + "and"+ doubleNumber + (char)2);
            integerNumber = 12;
            doubleNumber = 12.345;
            Console.WriteLine(integerNumber.GetValueOrDefault());
            Console.WriteLine(doubleNumber.GetValueOrDefault());
            
        }
    }
    /*
     Create a program that assigns null values to an integer and to double variables. Try to print them on the console, try to add some values or the null literal to them and see the result.

     */