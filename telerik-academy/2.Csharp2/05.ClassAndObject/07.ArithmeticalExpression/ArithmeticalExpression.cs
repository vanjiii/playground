using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
/*
 * * Write a program that calculates the value of given arithmetical expression. The expression can contain the following elements only:
Real numbers, e.g. 5, 18.33, 3.14159, 12.6
Arithmetic operators: +, -, *, / (standard priorities)
Mathematical functions: ln(x), sqrt(x), pow(x,y)
Brackets (for changing the default priorities)
	Examples:
	(3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7)  ~ 10.6
	pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3)  ~ 21.22
	Hint: Use the classical "shunting yard" algorithm and "reverse Polish notation".
 */
class ArithmeticalExpression
{
    public static List<char> ArithmericalOperators = new List<char>() {'*', '/', '+', '-' };
    public static List<string> Functions = new List<string>() {"pow", "sqrt", "ln"};
    public static List<char> Brackets = new List<char>() { '(', ')' };
    static void Main()
    {
        PutInvariantculture();
        Console.WriteLine("Enter a sequence: ");
        Console.Write("or 'exit' to terminate the program: ");
        string input = Console.ReadLine().Trim();
        while (input.ToLower() != "exit")
        {
                try
                {
                    var output = ShuntingYard(input);
                    var reversePolishNotation = ConvertToReversePolishNotation(output);
                    var finalResult = GetResultFromRPN(reversePolishNotation);
                    Console.WriteLine(finalResult);
                }
                catch (ArgumentException exc)
                {
                    Console.WriteLine(exc.Message);
                }
                Console.WriteLine("Enter a sequence: ");
                Console.Write("or 'exit' to terminate the program: ");
                input = Console.ReadLine().Trim();
        }   
    }
       

    public static int Precedence(string arithmeticalOperator)
    {
        if (arithmeticalOperator == "+" || arithmeticalOperator == "-")
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

    public static void PutInvariantculture()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
    }

    public static List<string> ShuntingYard(string input)
    {
        //initialize 
        List<string> aritOperators = new List<string>();
        StringBuilder number = new StringBuilder();

        //remove the blank spaces
        input = input.Replace(" ", "");

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '-' && (i == 0 || input[i - 1] == ',' || input[i-1] == '('))
            {
                number.Append('-');
            }
            else if (char.IsDigit(input[i]) || input[i] == '.')
            {
                number.Append(input[i]);
            }
            else if (!char.IsDigit(input[i]) && number.Length != 0 && input[i] != '.')
            {
                aritOperators.Add(number.ToString());
                number.Clear();
                i--;
            }
            else if (ArithmericalOperators.Contains(input[i]))
            {
                aritOperators.Add(input[i].ToString());
            }
            else if (Brackets.Contains(input[i]))
            {
                aritOperators.Add(input[i].ToString());
            }
            else if (input[i] == ',')
            {
                aritOperators.Add(",");
            }
            else if (i + 1 < input.Length && input.Substring(i,2).ToLower() == "ln")
            {
                aritOperators.Add("ln");
            }
            else if (i + 2 < input.Length && input.Substring(i, 3).ToLower() == "pow")
            {
                aritOperators.Add("pow");
            }
            else if (i + 3 < input.Length && input.Substring(i, 4).ToLower() == "sqrt")
            {
                aritOperators.Add("sqrt");
            }
        }
        if (number.Length != 0)
        {
            aritOperators.Add(number.ToString());
        }
        return aritOperators;
    }

    public static double GetResultFromRPN(Queue<string> queue) 
    {
        Stack<double> stack = new Stack<double>();

        while (queue.Count != 0)
        {
            string currentToken = queue.Dequeue();

            double number;

            if (double.TryParse(currentToken, out number))
            {
                stack.Push(number);
            }
            else if (ArithmericalOperators.Contains(currentToken[0]) || Functions.Contains(currentToken))
            {
                if (currentToken == "+")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("invalid expression");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(firstValue + secondValue);
                }
                else if (currentToken == "-")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("invalid expression");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(secondValue - firstValue);
                }
                else if (currentToken == "*")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("invalid expression");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(firstValue * secondValue);
                }
                else if (currentToken == "/")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("invalid expression");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(secondValue / firstValue);
                }
                 else if (currentToken == "pow")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("invalid expression");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(Math.Pow(secondValue, firstValue));
                }
                 else if (currentToken == "sqrt")
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("invalid expression");
                    }

                    double value = stack.Pop();

                    stack.Push(Math.Sqrt(value));
                }
                 else if (currentToken == "ln")
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("invalid expression");
                    }

                    double value = stack.Pop();

                    stack.Push(Math.Log(value));
                }
            }
        }
        if (stack.Count == 1)
	    {
		return stack.Pop();
	    }
        else
	    {
            throw new ArgumentException("Invalid Expression");
	    }
    }

    public static Queue<string> ConvertToReversePolishNotation(List<string> tokens)
    {
        Queue<string> queue = new Queue<string>();
        Stack<string> stack = new Stack<string>();

        for (int i = 0; i < tokens.Count; i++)
        {
            string currentToken = tokens[i];
            double number;

            if (double.TryParse(currentToken, out number))
            {
                queue.Enqueue(currentToken);
            }
            else if (Functions.Contains(currentToken))
            {
                stack.Push(currentToken);
            }
            else if (currentToken == ",")
            {
                if (! stack.Contains("(") || stack.Count == 0)
                {
                    throw new ArgumentException("Invalid brackets or function separator");
                }

                //if not working  => you may need to pop the "("
                while (stack.Peek() != "(")
                {
                    queue.Enqueue(stack.Pop());
                }
            }
            else if (ArithmericalOperators.Contains(currentToken[0]))
            {
                while (stack.Count !=0 && ArithmericalOperators.Contains(stack.Peek()[0]) && Precedence(currentToken) <= Precedence(stack.Peek()))
                {
                    queue.Enqueue(stack.Pop());
                }
                stack.Push(currentToken);
            }
            else if (currentToken == "(")
            {
                stack.Push("(");
            }
            else if (currentToken == ")")
            {
                if (!stack.Contains("(") || stack.Count == 0)
                {
                    throw new ArgumentException("Invalid brackets");
                }
                while (stack.Peek() != "(")
                {
                    queue.Enqueue(stack.Pop());
                }

                stack.Pop();

                if (stack.Count != 0 && Functions.Contains(stack.Peek()))
                {
                    queue.Enqueue(stack.Pop());
                }
            }
        }
        while (stack.Count != 0)
        {
            if (Brackets.Contains(stack.Peek()[0]))
            {
                throw new ArgumentException("Invalid brackets position");
            }
            queue.Enqueue(stack.Pop());
        }
        return queue;
    }
}
