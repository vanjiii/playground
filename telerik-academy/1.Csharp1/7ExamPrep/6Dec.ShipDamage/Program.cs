using System;

class Program
{
    static void Main()
    {
        // the coordinates of the rectangle
        int sx1 = int.Parse(Console.ReadLine());
        int sy1 = int.Parse(Console.ReadLine());
        int sx2 = int.Parse(Console.ReadLine());
        int sy2 = int.Parse(Console.ReadLine());
        int height = int.Parse(Console.ReadLine());

        //initialize the borders of the space ship :P
        int minXRectangle = Math.Min(sx1, sx2);
        int maxXRectangle = Math.Max(sx1, sx2);
        int minYRectangle = Math.Min(sy1, sy2);
        int maxYrectangle = Math.Max(sy1, sy2);

        int damage = 0;

        //read the coordinates of the three bombs
        for (int i = 0; i < 3; i++)
        {
            int pointX = int.Parse(Console.ReadLine());
            int pointY = int.Parse(Console.ReadLine());

            pointY = 2 * height - pointY;

            if ( ((pointX == minXRectangle) || (pointX == maxXRectangle)) &&
                 ((pointY == minYRectangle) || (pointY == maxYrectangle)) )
            {
                //is on corner
                damage += 25;
            }

            if ( ((pointX > minXRectangle) && (pointX < maxXRectangle)) &&
                 ((pointY == minYRectangle) || (pointY == maxYrectangle)) )
            {
                //is on border y
                damage += 50;
            }

            if ( ((pointX > minXRectangle) && (pointX < maxXRectangle)) && 
                 ((pointY > minYRectangle) && (pointY < maxYrectangle)) )
            {
                //is inside the rectangle
                damage += 100;
            }

        }


        Console.WriteLine(damage + "%");

    }
}

                                    /*
                                     * this is the solution for 100 points.............
                                     */
/*
 * 
 * using System;

class ShipDamage
{
    static void Main()
    {
        // Read the input
        int sx1 = Int32.Parse(Console.ReadLine());
        int sy1 = Int32.Parse(Console.ReadLine());
        int sx2 = Int32.Parse(Console.ReadLine());
        int sy2 = Int32.Parse(Console.ReadLine());
        int h = Int32.Parse(Console.ReadLine());
        int cx1 = Int32.Parse(Console.ReadLine());
        int cy1 = Int32.Parse(Console.ReadLine());
        int cx2 = Int32.Parse(Console.ReadLine());
        int cy2 = Int32.Parse(Console.ReadLine());
        int cx3 = Int32.Parse(Console.ReadLine());
        int cy3 = Int32.Parse(Console.ReadLine());

        // Find the hit points (apply symmetrics)
        cy1 = 2 * h - cy1;
        cy2 = 2 * h - cy2;
        cy3 = 2 * h - cy3;

        // Find the ship bounds
        int minX = Math.Min(sx1, sx2);
        int maxX = Math.Max(sx1, sx2);
        int minY = Math.Min(sy1, sy2);
        int maxY = Math.Max(sy1, sy2);

        int totalDamage = 0;

        // Check the corners damage
        if ((cx1 == minX || cx1 == maxX) && (cy1 == minY || cy1 == maxY))
        {
            totalDamage += 25; // Hit in the corner
        }
        if ((cx2 == minX || cx2 == maxX) && (cy2 == minY || cy2 == maxY))
        {
            totalDamage += 25; // Hit in the corner
        }
        if ((cx3 == minX || cx3 == maxX) && (cy3 == minY || cy3 == maxY))
        {
            totalDamage += 25; // Hit in the corner
        }

        // Check the borders damage
        if (((cx1 == minX || cx1 == maxX) && (cy1 > minY && cy1 < maxY)) ||
            ((cy1 == minY || cy1 == maxY) && (cx1 > minX && cx1 < maxX)))
        {
            totalDamage += 50; // Hit in the border
        }
        if (((cx2 == minX || cx2 == maxX) && (cy2 > minY && cy2 < maxY)) ||
            ((cy2 == minY || cy2 == maxY) && (cx2 > minX && cx2 < maxX)))
        {
            totalDamage += 50; // Hit in the border
        }
        if (((cx3 == minX || cx3 == maxX) && (cy3 > minY && cy3 < maxY)) ||
            ((cy3 == minY || cy3 == maxY) && (cx3 > minX && cx3 < maxX)))
        {
            totalDamage += 50; // Hit in the border
        }

        // Check the internal body damage
        if ((cx1 > minX) && (cx1 < maxX) && (cy1 > minY) && (cy1 < maxY))
        {
            totalDamage += 100; // Hit in the internal body
        }
        if ((cx2 > minX) && (cx2 < maxX) && (cy2 > minY) && (cy2 < maxY))
        {
            totalDamage += 100; // Hit in the internal body
        }
        if ((cx3 > minX) && (cx3 < maxX) && (cy3 > minY) && (cy3 < maxY))
        {
            totalDamage += 100; // Hit in the internal body
        }

        Console.WriteLine(totalDamage + "%");
    }
}
 * 
*/