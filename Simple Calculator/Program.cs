using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Calculator
{
    class Program
    {

        // Реализует взаимодействие программы с пользователем
        static void Dialog()
        {
            
            int operation;
            double a = 0;
            double b = 0;
            bool isFirstCalculation = true;

            try
            {
                do
                {
                    operation = ChooseOperation();
                    if (isFirstCalculation)
                        a = InputData();
                    if (operation < 5)
                        b = InputData();
                    double result = Calculation(a, b, operation);
                    Console.WriteLine(PrepareOutput(a, b, result, operation));
                    isFirstCalculation = false;
                    a = result;

                } while (ContinueCalculation());
            }
            catch (Exception e)
            {
                ShowError(e);
            }
        }

        // Треббуется ли продолжить вычисления над результатом
        static bool ContinueCalculation()
        {
            Console.WriteLine("Продолжить вычисления над результатом? y/n");
            while (true)
            {
                try
                {

                    string answer = Console.ReadLine();
                    if (IsExitRequired(answer))
                        Environment.Exit(0);
                    else if (answer == "y")
                        return true;
                    else if (answer == "n")
                        return false;
                    else
                        throw new ArgumentException("Ответ должен быть либо 'y', либо 'n'!");
                }
                catch (Exception e)
                {
                    ShowError(e);
                }
            }
        }

        // Подготовка строки с записью произведенных вычислений
        static string PrepareOutput(double a, double b, double result, int operation)
        {
            string output;
            if (operation == 1)
                output = a.ToString() + " + " + b.ToString() +  " = " + result.ToString();
            else if (operation == 2)
                output = a.ToString() + " - " + b.ToString() + " = " + result.ToString();
            else if (operation == 3)
                output = a.ToString() + " * " + b.ToString() + " = " + result.ToString();
            else if (operation == 4)
                output = a.ToString() + " / " + b.ToString() + " = " + result.ToString();
            else if (operation == 5)
                output = "sqr(" + a.ToString() +  ") = " + result.ToString();
            else
                output = "sqrt(" + a.ToString() + ") = " + result.ToString();
            return output;
        }

        // Выполение операций счета
        static double Calculation(double a, double b,  int operation)
        {
            if (operation == 1)
                return a + b;
            else if (operation == 2)
                return a - b;
            else if (operation == 3)
                return a * b;
            else if (operation == 4)
                return a / b;
            else if (operation == 5)
                return a * a;
            else
            {
                if (a < 0)
                    throw new ArgumentException("Невозможно вычислить корень из отрицательного числа!");
                return Math.Sqrt(a);
            }
        }

        // Выбор требуемой операции
        static int ChooseOperation()
        {
            Console.WriteLine("Выберите операцию:\n" +
                "1 - Сложение\n" +
                "2 - Вычитание\n" +
                "3 - Умножение\n" +
                "4 - Деление\n" +
                "5 - Возведение в квадрат\n" +
                "6 - Вычисление корня");
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    if (IsExitRequired(input))
                    {
                        Environment.Exit(0);
                    }
                    if (input == "1" || input == "2" || input == "3" ||
                        input == "4" || input == "5" || input == "6")
                    {
                        return Convert.ToInt16(input);
                    }
                    else
                        throw new FormatException("Выберите одну из операций, написав соответствующую цифру!");
                }
                catch (Exception e)
                {
                    ShowError(e);
                }
            }

        }


        // Выход из программы
        static bool IsExitRequired(string input)
        {
            if (input == "exit")
                return true;
            else
                return false;
        }

        // Вывод ошибок в консоль
        static void ShowError(Exception e)
        {
            Console.WriteLine(e.Message);
        }


        // Считывание операндов из консоли
        static double InputData()
        {
            Console.WriteLine("Введите число:");
            while(true)
            {
                try
                {
                    string input = Console.ReadLine();
                    input = input.Replace('.', ',');
                    if (IsExitRequired(input))
                    {
                        Environment.Exit(0);
                    }
                    return double.Parse(input);
                }
                catch (Exception e)
                {
                    ShowError(e);
                }
            }
        }

        static void Main(string[] args)
        {
            while(true)
            {
                Dialog();
            }
        }
    }
}
