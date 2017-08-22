using System;
    class RectanglesArea
    {
        static void Main()
        {
            Console.WriteLine("Enter height: ");
            string recH = Console.ReadLine();
            Console.WriteLine("Enter Wigth: ");
            string recW = Console.ReadLine();
            int rectangleWidth, rectangleHeight, rectangleArea;
            int.TryParse(recH, out rectangleHeight);
            int.TryParse(recW, out rectangleWidth);
            rectangleArea = rectangleHeight * rectangleWidth;
            Console.WriteLine("The area of the rectangle with height {0} and width {1} is : {2} .", rectangleHeight, rectangleWidth, rectangleArea);
        }
    }
/*
 Write an expression that calculates rectangle’s area by given width and height.
 */
