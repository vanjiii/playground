using System;
/*
 * Extend the program to support also subtraction and multiplication of polynomials.
 */
class ExtendPolynomial
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
    static int[] Substraction(int[] firstPolyn, int[] secondPolyn)
    {
        //there are 3 case - the two polynomial are equal by length; the first is bigger; the second is bigger
        //the result
        int[] res = new int[firstPolyn.Length > secondPolyn.Length ? firstPolyn.Length : secondPolyn.Length];

        if (firstPolyn.Length > secondPolyn.Length)
        {
            //here we substract the elements.
            //length is the shortest one and adding the rest
            //'cause : a - 0 = a :)
            for (int i = 0; i < secondPolyn.Length; i++)
            {
                res[i] = firstPolyn[i] - secondPolyn[i];
            }

            for (int ii = secondPolyn.Length; ii < firstPolyn.Length; ii++)
            {
                res[ii] = firstPolyn[ii];
            }
        }
        else if (firstPolyn.Length < secondPolyn.Length)
        {
            //here it is similar
            //but we adding the rest elements multiplicated by -1
            // 0 - a = -a 
            for (int j = 0; j < firstPolyn.Length; j++)
            {
                res[j] = firstPolyn[j] - secondPolyn[j];
            }

            for (int jj = firstPolyn.Length; jj < secondPolyn.Length; jj++)
            {
                res[jj] = secondPolyn[jj] * (-1);
            }
        }
        else
        {
            //if their length is equal
            //there are no complications
            for (int i = 0; i < secondPolyn.Length; i++)
            {
                res[i] = firstPolyn[i] - secondPolyn[i];
            }
        }
        return res;
    }
    static int[] Multiplication(int[] firstPolynomial, int[] secondPolynomial)
    {
        int index = 0;
        //the power of X
        int[] powerOfX = new int[firstPolynomial.Length * secondPolynomial.Length]; 
        //the values of every X^n
        int[] res = new int[firstPolynomial.Length * secondPolynomial.Length];
        
        //multiplication of the values of the polynomial
        for (int i = 0; i < firstPolynomial.Length; i++)
        {
            for (int j = 0; j < secondPolynomial.Length; j++)
            {
                res[index] = firstPolynomial[i] * secondPolynomial[j];
                powerOfX[index] = i + j;
                index++;
            }
        }
        //adding the polynomial with same power
        for (int ii = 0; ii < index; ii++)
        {
            for (int jj = ii + 1; jj < index; jj++)
            {
                if ((powerOfX[ii] == powerOfX[jj]) && (powerOfX[ii] != -1) && (powerOfX[ii] != -1))
                {
                    res[ii] = res[ii] + res[jj];
                    powerOfX[jj] = -1;
                    res[jj] = 0;
                }       
            }
        }
        //'cause every method can return one value
        //in this case one array - i add the two arrays - the values and the power of x
        //and the carefuly print them :)
        int[] resPlusPowerX = new int[2 * firstPolynomial.Length * secondPolynomial.Length];
        for (int n = 0; n < index; n++)
        {
            resPlusPowerX[n] = res[n];
        }
        for (int m = (firstPolynomial.Length * secondPolynomial.Length); m < 2 * (firstPolynomial.Length * secondPolynomial.Length); m++)
        {
            resPlusPowerX[m] = powerOfX[m - (firstPolynomial.Length * secondPolynomial.Length)];
        }
        return resPlusPowerX;
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

        //choose a function
        Console.WriteLine("What do you want to do with these polynomials? ");
        Console.WriteLine(@"Enter 
                            1 - add
                            2 - substract
                            3 - multiplication
                            0 - exit");
        int choose = int.Parse(Console.ReadLine());
        switch (choose)
        {
                //in case of adding
            case 1: int[] resultAdd = new int[lengthFirstPolynomial > lengthSecondPolynomial ? lengthFirstPolynomial : lengthSecondPolynomial];
                resultAdd = Add(firstPolynomial, secondPolynomial);
                //print the result
                for (int j = resultAdd.Length - 1; j >= 0; j--)
                {
                    if (resultAdd[j] != 0)
                    {
                        Console.Write(" " + resultAdd[j] + "X^" + j + " +");
                    }

                }
                Console.Write("\b");
                break;
                //in case of substracting
            case 2: int[] resultSub = new int[lengthFirstPolynomial > lengthSecondPolynomial ? lengthFirstPolynomial : lengthSecondPolynomial];
                resultSub = Substraction(firstPolynomial, secondPolynomial);
                //print the result
                for (int j = resultSub.Length - 1; j >= 0; j--)
                {
                    if (resultSub[j] != 0)
                    {
                        Console.Write(" " + resultSub[j] + "X^" + j + " +");
                    }

                }
                Console.Write("\b");
                break;
                //in case of multiplication
            case 3: int[] resultMult = new int[lengthFirstPolynomial * lengthSecondPolynomial];
                resultMult = Multiplication(firstPolynomial, secondPolynomial);
                for (int i = 0; i < lengthFirstPolynomial * lengthSecondPolynomial; i++)
                {
                    if (resultMult[i] != 0 && resultMult[(i + (lengthFirstPolynomial * lengthSecondPolynomial))] != -1)
                    {
                        Console.Write(" " + resultMult[i] + "X^" + resultMult[(i + (lengthFirstPolynomial * lengthSecondPolynomial))] + " +");
                    }
                    
                }
                Console.WriteLine("\b");
                break;
            default:
                break;
        }
    }
}
