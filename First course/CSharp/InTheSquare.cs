/*using System;
using System.Globalization;


namespace CSharp_1kurs
{
    class Program
    {
        public static bool IsSquare(double x0, double y0, double x1, double y1)
        { // проверка на квадрат
            return x1 - x0 == y1 - y0;
        }

        public static void InSquare(double x0, double y0, double x1, double y1, double xDot, double yDot)
        { // в квадрате?
            if (IsSquare(x0, y0, x1, y1))
            {
                if (x0 < xDot && xDot < x1 && y0 < xDot && xDot < y1)
                    Console.Write("Точка лежит в области квадрата");
                else
                    Console.Write("Точка не лежит в области квадрата");
            }
            else
                Console.Write("Не квадрат!");
        }

        public static void Main()
        {
            Console.WriteLine("Введите координаты точки (x, y) через пробел");
            string[] dotData = Console.ReadLine().Split();
            double xDot = 0, yDot = 0, x0 = 0, y0 = 0, x1 = 0, y1 = 0;
            try
            {
                xDot = double.Parse(dotData[0]);
                yDot = double.Parse(dotData[1]);
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка ввода");
            }

            Console.WriteLine("Введите координаты 1-го угла (x0, y0) через пробел");
            string[] angle1Data = Console.ReadLine().Split();
            try
            {
                x0 = double.Parse(angle1Data[0]);
                y0 = double.Parse(angle1Data[1]);
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка ввода");
            }

            Console.WriteLine("Введите координаты 2-го угла (x1, y1) через пробел");
            string[] angle2Data = Console.ReadLine().Split();
            try
            {
                x1 = double.Parse(angle2Data[0]);
                y1 = double.Parse(angle2Data[1]);
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка ввода");
            }

            InSquare(x0, y0, x1, y1, xDot, yDot);
        }
    }
}*/