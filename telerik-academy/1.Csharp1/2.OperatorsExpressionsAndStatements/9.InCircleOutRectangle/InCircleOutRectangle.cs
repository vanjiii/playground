using System;
    class InCircleOutRectangle
    {
        static void Main()
        {
            // Intput the x and y coordinate of a point.
            Console.WriteLine("Enter X coordinate: ");
            string X = Console.ReadLine();
            Console.WriteLine("Enter Y coordinate: ");
            string Y = Console.ReadLine();
            double coorX, coorY, circleRadius = 3;
            int x0 = 1, y0 = 1;
            double.TryParse(X, out coorX);
            double.TryParse(Y, out coorY);

            // Initializing the rectangle and the triangles, made by two point of the rectangle and random point.
            double areaABP, areaADP, areaBCP, areaCDP;
            double rectangleAx = -1, rectangleAy = -1, rectangleBx = 5, rectangleBy = -1, rectangleCx = 5, rectangleCy = 1, rectangleDx = -1, rectangleDy = 1;

            // Calculate the area of the trinagles made by two point og the rectangle and given point.
            areaABP = Math.Abs((rectangleAx * ( rectangleBy - coorY ) + rectangleBx * ( coorY - rectangleAy ) + coorX * ( rectangleAy - rectangleBy )) * 0.5);
            areaADP = Math.Abs((rectangleAx * (rectangleDy - coorY) + rectangleDx * (coorY - rectangleAy) + coorX * (rectangleAy - rectangleDy)) * 0.5);
            areaBCP = Math.Abs((rectangleBx * (rectangleCy - coorY) + rectangleCx * (coorY - rectangleBy) + coorX * (rectangleBy - rectangleCy)) * 0.5);
            areaCDP = Math.Abs((rectangleDx * (rectangleCy - coorY) + rectangleCx * (coorY - rectangleDy) + coorX * (rectangleDy - rectangleCy)) * 0.5);

            //Area of rectangle
            double areaRectangle;
            areaRectangle = (rectangleBx - rectangleAx) * (rectangleCy - rectangleBy);

           
            

            // The first "if" caclculates if the point is in the circle.
            if ((Math.Pow((coorX - x0), 2) + Math.Pow((coorY - y0), 2)) <= Math.Pow(circleRadius, 2))
            {
                // point in the rectangle ?
                if ((areaABP + areaADP + areaBCP + areaCDP) >= areaRectangle)
                    {
                        Console.WriteLine("The point is in the rectangle and in the circle.");
                    }
                else
                {
                    Console.WriteLine("It's in the rectangle");
                }
            }
            else
            {
                Console.WriteLine("it's otside the circle");
            }
 
        }
    }
/*
 Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).
 */

    /*
     * Let P(x,y), and rectangle A(x1,y1),B(x2,y2),C(x3,y3),D(x4,y4)
    Calculate the sum of areas of △APD,△DPC,△CPB,△PBA.

    If this sum is greater than the area of the rectangle, then P(x,y) is outside the rectangle.

    Else if this sum is equal to the area of the rectangle (observe that this sum can not be less than the later),

    if area of any of the triangle is 0, then P(x,y) is on the rectangle (in fact on that line corresponding to the triangle of area=0). Observe that the equality of the sum is necessary, only area=0 is not sufficient),

    else P(x,y) is is inside the rectangle.
     */