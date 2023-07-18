/*using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_1kurs
{
    class bar
    {
        static bool BarCanPass(double x, double y, double a, double b)
        {
            if (x * y <= a * b) // проверка площадей
            {
                if (x <= a && y <= b)
                    return true;
                else
                {
                    Console.WriteLine("Поворачиваю на 90°...");

                    if (y <= a && x <= b)
                        return true;
                    else
                        return false;
                }
            }
            else
            {
                Console.WriteLine("Площадь бруска больше, чем площадь отверствия\nБрусок не пролезет.");
                return false;
            }
        }
        public static void Main()
        {
            Console.WriteLine("Введите стороны x, y, z бруска (через пробел)");
            string[] barData = Console.ReadLine().Split();
            double x = 0, y = 0, z = 0, a = 0, b = 0;
            try
            {
                if (!double.TryParse(barData[0], out x) || x < 0)
                    Console.WriteLine("Ошибка ввода!");
                if (!double.TryParse(barData[1], out y) || y < 0)
                    Console.WriteLine("Ошибка ввода!");
                if (!double.TryParse(barData[2], out z) || z < 0)
                    Console.WriteLine("Ошибка ввода!");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Ошибка ввода!");
            }

            Console.WriteLine("Введите стороны a, b отверствия (через пробел)");
            string[] holeData = Console.ReadLine().Split();
            try
            {
                if (!double.TryParse(holeData[0], out a) || a < 0)
                    Console.WriteLine("Ошибка ввода!");
                if (!double.TryParse(holeData[1], out b) || b < 0)
                    Console.WriteLine("Ошибка ввода!");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Ошибка ввода!");
            }

            if (BarCanPass(x, y, a, b))
                Console.WriteLine("Брусок пролезет.");
            else
                Console.WriteLine("Брусок не пролезет.");
        }
    }
}*/
