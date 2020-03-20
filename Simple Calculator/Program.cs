using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Calculator
{
    class Program
    {
        static void Greet()
        {
            Console.WriteLine("Данный калькулятор выполняет простейшие действия " +
                "(+, - , *, /, возведение в квадрат, извлечение корня)\n" +
                "Числа от знаков операций ОБЯЗАТЕЛЬНО должны ОТДЕЛЯТЬСЯ ПРОБЕЛОМ \n" +
                "Для возведения в квадрат введите sqr \"число\" \n" +
                "Для извлечения корня sqrt \"число\" \n" +
                "Для выполения операций над результатом введите требуемую команду без первого операнда \n" +
                "Для выхода из калькулятора введите exit");
        }

        static void StartCalculation()
        {
            double result = 0;
            bool isFirstCalculation = true;
            string operations = "+-*/";
            while(true)
            {
                try
                {
                    double a = 0;
                    double b = 0;
                    int operationNumber = 0;
                    string rawInput = Console.ReadLine();
                    if(IsExitRequired(rawInput))
                    {
                        Environment.Exit(0);
                    }
                    rawInput = rawInput.Replace(".", ",");
                    string[] input = rawInput.Split(new char[] { ' ' });

                    if (input.Length == 3)
                    {

                        a = double.Parse(input[0]);
                        b = double.Parse(input[2]);
                        operationNumber = operations.IndexOf(input[1]);

                        result = Calculate(a, b, operationNumber);
                    }
                    else if (input.Length == 2)
                    {
                        if (input[0] == "sqr")
                        {
                            a = double.Parse(input[1]);
                            operationNumber = 4;
                            result = Calculate(a, b, operationNumber);
                        }
                        else if (input[0] == "sqrt")
                        {
                            a = double.Parse(input[1]);
                            operationNumber = 5;
                            result = Calculate(a, b, operationNumber);
                        }
                        else if (!isFirstCalculation)
                        {
                            a = result;
                            b = double.Parse(input[1]);
                            operationNumber = operations.IndexOf(input[0]);

                            result = Calculate(a, b, operationNumber);
                        }
                        else
                        {
                            throw new FormatException("Неправильный формат входных данных!");
                        }
                    }
                    else if (input.Length == 1)
                    {
                        if (input[0] == "sqr" && !isFirstCalculation)
                        {
                            a = result;
                            operationNumber = 4;
                            result = Calculate(a, b, operationNumber);
                        }
                        else if (input[0] == "sqrt" && !isFirstCalculation)
                        {
                            a = result;
                            operationNumber = 5;
                            result = Calculate(a, b, operationNumber);
                        }
                        else
                        {
                            throw new FormatException("Неправильный формат входных данных!");
                        }
                    }
                    else
                    {
                        throw new FormatException("Неправильный формат входных данных!");
                    }
                    Console.WriteLine(PrepareOutput(a, b, result, operationNumber));
                    isFirstCalculation = false;
                }
                catch (Exception e)
                {
                    ShowError(e);
                }
            }
        }

        static double Calculate(double a, double b, int operation)
        {
            if (operation == 0)
                return a + b;
            else if (operation == 1)
                return a - b;
            else if (operation == 2)
                return a * b;
            else if (operation == 3)
                return a / b;
            else if (operation == 4)
                return a * a;
            else if (operation == 5)
            {
                if (a < 0)
                    throw new ArgumentException("Невозможно вычислить корень из отрицательного числа!");
                return Math.Sqrt(a);
            }
            else
                throw new FormatException("Неправильный формат входных данных!");
        }

        static string PrepareOutput(double a, double b, double result, int operation)
        {
            string output;
            if (operation == 0)
                output = a.ToString() + " + " + b.ToString() + " = " + result.ToString();
            else if (operation == 1)
                output = a.ToString() + " - " + b.ToString() + " = " + result.ToString();
            else if (operation == 2)
                output = a.ToString() + " * " + b.ToString() + " = " + result.ToString();
            else if (operation == 3)
                output = a.ToString() + " / " + b.ToString() + " = " + result.ToString();
            else if (operation == 4)
                output = "sqr(" + a.ToString() + ") = " + result.ToString();
            else
                output = "sqrt(" + a.ToString() + ") = " + result.ToString();
            return output;
        }

        static bool IsExitRequired(string input)
        {
            if (input == "exit")
                return true;
            else
                return false;
        }

        static void ShowError(Exception e)
        {
            Console.WriteLine(e.Message);
        }

        static void Main(string[] args)
        {
            Greet();
            StartCalculation();
        }
    }
}
