using System;
    class IsoscelesTriangleOfCopyrightSymbols
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("©");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Console.WriteLine("\u00a9");
            string isoscelesTriangle = 
            @"     
                                              ©     
                                             © ©
                                            ©   ©
                                           ©     ©
                                          © © © © ©
            ";

            Console.WriteLine(isoscelesTriangle);
        }
    }
    /*
     Write a program that prints an isosceles triangle of 9 copyright symbols ©. Use Windows Character Map to find the Unicode code of the © symbol. Note: the © symbol may be displayed incorrectly.

     */