using System;
using System.Threading;
using System.Globalization;

class Garden
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        int area = 250;

        //input the prices of each seed
        decimal tomatoPricePerSeed = 0.5m;
        decimal cucumberPricePerSeed = 0.4m;
        decimal potatoPricePerSeed = 0.25m;
        decimal carrotPriceSeed = 0.6m;
        decimal cabbagePricePerSeed = 0.3m;
        decimal beansPricePerSeed = 0.4m;

        //read from the console the amount and the area of the vegetables.
        int tomatoSeeds = int.Parse(Console.ReadLine());
        int tomatoArea = int.Parse(Console.ReadLine());
        int cucumberSeeds = int.Parse(Console.ReadLine());
        int cucumberArea = int.Parse(Console.ReadLine());
        int potatoSeeds = int.Parse(Console.ReadLine());
        int potatoArea = int.Parse(Console.ReadLine());
        int carrotSeeds = int.Parse(Console.ReadLine());
        int carrotArea = int.Parse(Console.ReadLine());
        int cabbageSeeds = int.Parse(Console.ReadLine());
        int cabbageArea = int.Parse(Console.ReadLine());
        int beansSeeds = int.Parse(Console.ReadLine());

        int areaLeft = area - (tomatoArea + cucumberArea + potatoArea + carrotArea + cabbageArea);
        decimal tomatoCost, cucumberCost, potatoCost, carrotCost, cabbageCost, beansCost, allCostWithoutBeans;

        tomatoCost = tomatoPricePerSeed * tomatoSeeds;
        cucumberCost = cucumberPricePerSeed * cucumberSeeds;
        potatoCost = potatoPricePerSeed * potatoSeeds;
        carrotCost = carrotPriceSeed * carrotSeeds;
        cabbageCost = cabbagePricePerSeed * cabbageSeeds;
        allCostWithoutBeans = tomatoCost + cucumberCost + potatoCost + carrotCost + cabbageCost;

        if (areaLeft > 0)
        {
            Console.WriteLine("Total costs: {0:0.00}", (allCostWithoutBeans + (beansPricePerSeed * beansSeeds)));
            Console.WriteLine("Beans area: " + areaLeft);
        }
        else if (areaLeft == 0)
        {
            Console.WriteLine("Total costs: {0:0.00}", (allCostWithoutBeans + (beansPricePerSeed * beansSeeds)));
            Console.WriteLine("No area for beans");
        }
        else
        {
            Console.WriteLine("Total costs: {0:0.00}", (allCostWithoutBeans + (beansPricePerSeed * beansSeeds)));
            Console.WriteLine("Insufficient area");
        }

    }
}
