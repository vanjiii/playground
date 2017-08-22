using System;

class DrunkenNumbers
{
    static void Main()
    {
        //Input N
        string roundStringN = Console.ReadLine();
        long roundIntegerN = long.Parse(roundStringN);

        //if N is negative multiplicate by -1
        if (roundIntegerN < 0)
        {
            roundIntegerN *= (-1);
        }

        long beersMitko = 0, beersVladko = 0, drinkenNumbersDigit = 0, remainder = 0;

        //input drinken numbers
        for (int i = 0; i < roundIntegerN; i++)
        {
            string stringDrinkenNumbers = Console.ReadLine();
            drinkenNumbersDigit = long.Parse(stringDrinkenNumbers);

            //Check if the input number is negative??
            if (drinkenNumbersDigit < 0)
            {
                drinkenNumbersDigit *= (-1);
            }

            //check if the number has more than 9 digits
            //long checkLenght = stringDrinkenNumbers.Length;
            //if (stringDrinkenNumbers.Length >= 10)
            //{
            //    for (int p = 0; p < (stringDrinkenNumbers.Length - 9); p++)
            //    {
            //        drinkenNumbersDigit /= 10;
            //    }
            //}

           //count the present digits
            long num = drinkenNumbersDigit;
            int countDigits = 0;
            while (num != 0)
            {
                num /= 10;
                countDigits++;
            }
           
            //if the number of digits are even 
            if (countDigits % 2 == 0)
            {
                for (int v = 0; v < countDigits / 2; v++)
                {
                    remainder = drinkenNumbersDigit % 10;
                    beersVladko += remainder;
                    drinkenNumbersDigit /= 10;
                }
                for (int m = countDigits / 2; m < countDigits; m++)
                {
                    remainder = drinkenNumbersDigit % 10;
                    beersMitko += remainder;
                    drinkenNumbersDigit /= 10;
                }
            }
            //if the number of gigits are odd
            else
            {
                for (int v = 0; v <= (countDigits / 2) - 1 ; v++)
                {
                    remainder = drinkenNumbersDigit % 10;
                    beersVladko += remainder;
                    drinkenNumbersDigit /= 10;
                }
                //count the middle number to each player
                remainder = drinkenNumbersDigit % 10;
                beersVladko += remainder;
                beersMitko += remainder;
                drinkenNumbersDigit /= 10;
                for (int m = (countDigits / 2) + 1; m <= countDigits; m++)
                {
                    remainder = drinkenNumbersDigit % 10;
                    beersMitko += remainder;
                    drinkenNumbersDigit /= 10;
                }

            }
        }
        //print result
        if (beersVladko > beersMitko)
        {
            Console.WriteLine("V " + (beersVladko - beersMitko));
        }
        else if (beersVladko < beersMitko)
        {
            Console.WriteLine("M " + (beersMitko - beersVladko));
        }
        else
        {
            Console.WriteLine("No " + (beersVladko + beersMitko));
        }
    }
}
