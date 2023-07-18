using System;
/*
namespace Kvadratki
{
    public static class Program
    {
        /// <summary>
        /// Показывает сообщение об ошибке ввода коэффициентов
        /// </summary>
        /// <param name="letter"></param>
        static void ReadErrorMessage(string letter)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка ввода! Введите коэффициент " + letter);
            Console.ResetColor();
        }

        static void quadratic(double a1, double b1, double c1)
        {
            double D = Math.Pow(b1, 2) - (4 * a1 * c1);
            if (D < 0)
                Console.WriteLine("Корень не существует!");
            else
            {
                double x1 = (-b1 - Math.Sqrt(D)) / (2 * a1);
                double x2 = (-b1 + Math.Sqrt(D)) / (2 * a1);
                if (x1 != x2)
                    Console.WriteLine("Ответ: x1 = " + x1.ToString() + "; x2 = " + x2.ToString());
                else
                    Console.WriteLine("Ответ: x = " + x1.ToString());
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите коэффициенты");
            // Проверка на ввод цифр
            double a, b, c;
            while (!double.TryParse(Console.ReadLine(), out a))
                ReadErrorMessage("a");
            while (!double.TryParse(Console.ReadLine(), out b))
                ReadErrorMessage("b");
            while (!double.TryParse(Console.ReadLine(), out c))
                ReadErrorMessage("c");

            quadratic(a, b, c);
        }
    }
}*/