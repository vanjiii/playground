using System;
    class CompareFloatingPointNumbers
    {
        static void Main()
        {
            Console.Title = "Exercises 3";
            float firstDifferent = 5.3f;
            float secondDifferent = 6.01f;
            float firstEqual = 5.00000001f, secondEqual = 5.00000003f;

            Console.WriteLine("Is 5.3 and 6.01 equal ?!?");
            Console.WriteLine("Is 5.00000001 and 5.00000003 equal ?!?");
            if (secondDifferent - firstDifferent < 0.000001)
            {
           
                Console.WriteLine("Yes, 5.3 and 6.01 are equal!");
            }  

            if (secondEqual - firstEqual < 0.000001)
            {

                Console.WriteLine("Yes, 5.00000001 and 5.00000003 are equal!");
            }

        }
    }
/*
 * Write a program that safely compares floating-point numbers with precision of 0.000001. Examples:(5.3 ; 6.01)  false;  (5.00000001 ; 5.00000003)  true
*/
