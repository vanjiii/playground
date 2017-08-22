using System;
/*
 * Write a method that adds two polynomials. 
 * Represent them as arrays of their coefficients as in the example below:
		x2 + 5 = 1x2 + 0x + 5  5 0 1
 */
class Polynomials
{
    static int[] Add(int[] firstPolyn, int[] secondPolyn)
    {
        //the result
        int[] res = new int[firstPolyn.Length > secondPolyn.Length ? firstPolyn.Length : secondPolyn.Length];
        //going through all element of the smallest array (polynomial)
        for (int i = 0; i < (firstPolyn.Length < secondPolyn.Length ? firstPolyn.Length : secondPolyn.Length); i++)
        {
            res[i] = firstPolyn[i] + secondPolyn[i];   
        }
        //if the two arrays have different length
        //we find wich is bigger and add his elements to the result
        //this is something like adding zero to a number
        if (firstPolyn.Length != secondPolyn.Length)
        {
            int bigLength = firstPolyn.Length > secondPolyn.Length ? firstPolyn.Length : secondPolyn.Length;
            int smallLength = firstPolyn.Length < secondPolyn.Length ? firstPolyn.Length : secondPolyn.Length;
            for (int j = smallLength; j < bigLength; j++)
            {
                res[j] = firstPolyn.Length > secondPolyn.Length ? firstPolyn[j] : secondPolyn[j];
            }
        }
        return res;
    }
    static void Main()
    {
        //input
        Console.WriteLine("Enter the coefficients of the polynomials...");
        Console.Write("How many members will the first polynomial has (length of the array): ");
        int lengthFirstPolynomial = int.Parse(Console.ReadLine());
        //input the first polynomial
        int[] firstPolynomial = new int[lengthFirstPolynomial];
        for (int i = 0; i < lengthFirstPolynomial; i++)
        {
            Console.Write("For x ^ {0} : ", i);
            firstPolynomial[i] = int.Parse(Console.ReadLine());
        }
        //enter the second polynomial
        Console.Write("How many members will the second polinomial has (length of the array): ");
        int lengthSecondPolynomial = int.Parse(Console.ReadLine());
        int[] secondPolynomial = new int[lengthSecondPolynomial];
        for (int ii = 0; ii < lengthSecondPolynomial; ii++)
        {
            Console.Write("For x ^ {0} : ", ii);
            secondPolynomial[ii] = int.Parse(Console.ReadLine());
        }

        //add the polynomial
        int[] result = new int[lengthFirstPolynomial > lengthSecondPolynomial ? lengthFirstPolynomial : lengthSecondPolynomial];
        result = Add(firstPolynomial, secondPolynomial);

        //print the result
        for (int j = result.Length - 1; j >= 0; j--)
        {
            if (result[j] != 0)
            {
                Console.Write(" " + result[j] + "X^" + j + " +");
            }
            
        }
        Console.Write("\b");

        //int a = 22;
        //int b = 5;
        //Console.WriteLine(a>b ? a : b);
           
    }
}
