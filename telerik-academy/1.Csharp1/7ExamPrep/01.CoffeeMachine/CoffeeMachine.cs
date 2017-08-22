using System;
using System.Globalization;
using System.Threading;

class CoffeeMachine
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        int coin5 = int.Parse(Console.ReadLine());
        int coin10 = int.Parse(Console.ReadLine());
        int coin20 = int.Parse(Console.ReadLine());
        int coin50 = int.Parse(Console.ReadLine());
        int coin100 = int.Parse(Console.ReadLine());
        decimal developerMoney = decimal.Parse(Console.ReadLine());
        decimal drinkPrice = decimal.Parse(Console.ReadLine());

        decimal change = 0, moneyInMachine = 0, allMoneyInMachine;
        allMoneyInMachine = (1.00m * coin100) + (0.5m * coin50) + (0.2m * coin20) + (0.1m * coin10) + (0.05m * coin5);

        if (developerMoney < drinkPrice)
        {//33%
            Console.WriteLine("More {0:0.00}", drinkPrice - developerMoney);
        }
        //else if (developerMoney == drinkPrice)
        //{
        //    Console.WriteLine("Yes {}");
        //}
        else
        {
            change = developerMoney - drinkPrice;

            while ((change >= 1.00m) && (coin100 > 0))
            {
                change -= 1.00m;
                coin100--;
                //Console.WriteLine(change);
            }
            while ((change >= 0.50m) && (coin50 > 0))
            {
                change += 0.50m;
                coin50--;
            }
            while ((change >= 0.20m) && (coin20 > 0))
            {
                change -= 0.20m;
                coin20--;
                //Console.WriteLine(change);
            }
            while ((change >= 0.10m) && (coin10 > 0))
            {
                change -= 0.10m;
                coin10--;
                //Console.WriteLine(change);
            }
            while ((change >= 0.05m) && (coin5 > 0))
            {
                change -= 0.05m;
                coin5--;
            }


            if (Math.Round(change, 2) == 0)
            {//16%
                moneyInMachine = (1.00m * coin100) + (0.5m * coin50) + (0.2m * coin20) + (0.1m * coin10) + (0.05m * coin5);
                Console.WriteLine("Yes {0:0.00}", allMoneyInMachine - (developerMoney - drinkPrice));
            }
            else
            {//16%
                if ((developerMoney - drinkPrice) - allMoneyInMachine < 0)
                {
                    Console.WriteLine("No {0:0.00}", change);
                }
                else
                {
                    Console.WriteLine("No {0:0.00}", (developerMoney - drinkPrice) - allMoneyInMachine);
                }
                
            }
        }


    }
}
