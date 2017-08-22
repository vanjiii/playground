using System;
    class EscapingSpecialSymbols
    {
        static void Main()
        {
            // quoted string
            string quotedString = "The \"use\" of quotation causes difficulties, (using \\\")";
            Console.WriteLine(quotedString);
            //regular string
            string justString = @"The ""use"" of quatation causes difficulties, (using @)";
            Console.WriteLine(justString);
        }
    }
    /*
     Declare two string variables and assign them with following value:

        Do the above in two different ways: with and without using quoted strings.

     */