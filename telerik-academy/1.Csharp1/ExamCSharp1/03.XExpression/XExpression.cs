using System;

class XExpression
{
    static void Main()
    {
        string inputExpression = (Console.ReadLine());
        
        //helpfull variables
        bool isInsideBrackets = false;
        bool isPlus = false;
        bool isMinus = false;
        bool isMultiple = false;
        bool isDevide = false;
        bool firstNumberIsDigit = true;
        bool firstCharIsBracket = false;
        //bool beenInBrackets = false;
        char symbolWhenInside = new char();
        decimal result = 0m;
        decimal insideResult = 0;

        for (int ii = 0; ii < inputExpression.Length; ii++)
        {
            if (!(char.IsNumber(inputExpression[ii])))
            {
                switch (inputExpression[ii])
                {
                    case '+': isPlus = true; break;
                    case '-': isMinus = true; break;
                    case '*': isMultiple = true; break;
                    case '/': isDevide = true; break;
                    case '(': isInsideBrackets = true;
                        //beenInBrackets = false;
                        firstNumberIsDigit = false;
                        if (ii != 0)
                        {
                            symbolWhenInside = inputExpression[ii - 1];
                        }
                        else if (ii == 0)
                        {
                            firstCharIsBracket = true;
                        }
                        
                        insideResult = int.Parse(inputExpression[ii + 1].ToString()); break;
                    case ')': isInsideBrackets = false;
                        //beenInBrackets = true;
                        if (firstCharIsBracket)
                        {
                            result = result + insideResult;
                            firstCharIsBracket = false;
                        }
                        else
                        {
                            switch (symbolWhenInside)
                            {
                                case '+': result = result + insideResult; break;
                                case '-': result = result - insideResult; break;
                                case '*': result = result * insideResult; break;
                                case '/': result = result / insideResult; break;
                            }
                        }
                        firstNumberIsDigit = true; break;
                    case '=': Console.WriteLine("{0:F2}",result); break;
                    default: Console.WriteLine("We have other char.............!");
                        break;
                }
            }
            //outside brackets
            if (char.IsNumber(inputExpression[ii]) && !(isInsideBrackets))
            {
                //if (beenInBrackets)
                //{
                //    switch (symbolWhenInside)
                //    {
                //        case '+': result = result + insideResult;
                //            beenInBrackets = false; break;
                //        case '-': result = result - insideResult;
                //            beenInBrackets = false; break;
                //        case '/': result = result / insideResult;
                //            beenInBrackets = false; break;
                //        case '*': result = result * insideResult;
                //            beenInBrackets = false; break;
                //        default: Console.WriteLine("problem with the brackets");
                //            break;
                //    }
                //}
                if (firstNumberIsDigit && (ii == 0))
	            {
		            result = int.Parse(inputExpression[0].ToString());
                }
                else if ((!firstNumberIsDigit) && (ii == 1))
	            {
                    result = int.Parse(inputExpression[1].ToString());
	            }
                
                if (isPlus)
                {
                    result += int.Parse(inputExpression[ii].ToString());
                    isPlus = false;
                }
                if (isMinus)
                {
                    result -= int.Parse(inputExpression[ii].ToString()); 
                    isMinus = false;
                }
                if (isDevide)
                {   
                    result /= int.Parse(inputExpression[ii].ToString());
                    isDevide = false;
                }
                if (isMultiple)
                {
                    result *= int.Parse(inputExpression[ii].ToString()); 
                    isMultiple = false;
                }
            }
                //inside brackets
            else if ((char.IsNumber(inputExpression[ii]) && (isInsideBrackets)))
            {
                if (firstNumberIsDigit)
                {
                    insideResult = int.Parse(inputExpression[ii].ToString());
                    firstNumberIsDigit = false;
                }
                if (inputExpression[ii - 1] == '(')
                {
                    isPlus = false;
                    isMinus = false;
                    isMultiple = false;
                    isDevide = false;
                }
                if (isPlus)
                {
                    insideResult += int.Parse(inputExpression[ii].ToString());
                    isPlus = false;
                }
                if (isMinus)
                {
                    insideResult -= int.Parse(inputExpression[ii].ToString()); 
                    isMinus = false;
                }
                if (isDevide)
                {
                    insideResult /= int.Parse(inputExpression[ii].ToString());
                    isDevide = false;
                }
                if (isMultiple)
                {
                    insideResult *= int.Parse(inputExpression[ii].ToString()); 
                    isMultiple = false;
                }
            }
        }
    }
}
