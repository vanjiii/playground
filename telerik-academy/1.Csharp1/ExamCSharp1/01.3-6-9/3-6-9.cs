using System;

class Program
{
    static void Main()
    {
        //the input
        decimal A = decimal.Parse(Console.ReadLine());
        int B = int.Parse(Console.ReadLine());
        decimal C = decimal.Parse(Console.ReadLine());
        decimal R = 0;

        switch (B)
        {
            case 3:
                {
                    R = A + C;
                    break;
                }
            case 6:
                {
                    R = A * C;
                    break;
                }
            case 9:
                {
                    R = (A % C);
                    break;
                }
            default: break;
        }
        if (R % 3 == 0)
	    {
		    Console.WriteLine(decimal.Divide(R, 3));
            Console.WriteLine(R);
	    }else
	    {
            Console.WriteLine(R % 3);
            Console.WriteLine(R);
	    }

    }
}
