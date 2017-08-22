using System;
    class CharacterVariableWithUnicodeSymbol
    {
        static void Main()
        {
            //Decimal represantation of 0x72 is 114
            char characterInUnicode = '\x0072';
            Console.WriteLine("The unicod of 72 is " + characterInUnicode);
            char i = (char)72;
            Console.WriteLine("The unicod of 72 is " + i);
        }
    }
/*
Declare a character variable and assign it with the symbol that has Unicode code 72. Hint: first use the Windows Calculator to find the hexadecimal representation of 72.
*/