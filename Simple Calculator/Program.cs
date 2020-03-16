using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Calculator
{
    class Program
    {
        static void Dialog()
        {
            int operation;
            double a;
            double b = 0;

            operation = ChooseOperation();
            a = InputData();
            if (operation < 5)
                b = InputData();

            double result = Calculation(a, b, operation);

            Console.WriteLine(result);
            
            while(ContinueCalculation())
            {
                operation = ChooseOperation();
                if (operation < 5)
                    b = InputData();
                result = Calculation(result, b, operation);
                Console.WriteLine(result);
            }
        }

        static bool ContinueCalculation()
        {
            Console.WriteLine("Продолжить вычисления над результатом? y/n");
            while (true)
            {
                string answer = Console.ReadLine();
                if (answer == "y")
                    return true;
                else if (answer == "n")
                    return false;
                else
                    ShowError();
            }
        }

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
                return Math.Sqrt(a);
        }

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
                    return Convert.ToInt16(Console.ReadLine());
                }
                catch
                {
                    ShowError();
                }
            }

        }

        static bool Stop(string input)
        {
            if (input == "C")
                return true;
            else
                return false;
        }

        static void ShowError()
        {
            Console.WriteLine("Проверьте правильность введенных данных!");
        }

        static double InputData()
        {
            Console.WriteLine("Введите число:");
            while(true)
            {
                try
                {
                    return double.Parse(Console.ReadLine());
                }
                catch
                {
                    ShowError();
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
