using System;
/*
namespace CSharp_Shell
{
    public static class Program
    {
        /// <summary>
        /// Выводить углы трёх сторон
        /// </summary>
        /// <param name="alpha">угол стороны a</param>
        /// <param name="beta">угол стороны b</param>
        /// <param name="sigma">угол стороны c</param>
        public static void writeAngles(double alpha, double beta, double sigma)
        {
            Console.WriteLine("альфа: " + alpha + "°, бета: " + beta + "°, сигма: " + sigma + "°");
        }

        /// <summary>
        /// Нахождение площади треугольника с помощью формулы Геррона
        /// </summary>
        /// <param name="a">сторона a</param>
        /// <param name="b">сторона b</param>
        /// <param name="c">сторона c</param>
        /// <returns></returns>
        public static double triangleSquare(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        /// <summary>
        /// Выводятся первые 4 строки программы
        /// </summary>
        public static void hello()
        {
            Console.WriteLine("Выберите задачу:");
            Console.WriteLine("1) Определить, является ли треугольник треугольником; 2) Найти углы треугольника, определить тип треугольника;");
            Console.WriteLine("3) Найти площадь треугольника; 4) Найти наибольшую и наименьшую высоту;");
            Console.WriteLine("5) Найти площадь вписанного в этот треугольник окружности;");
        }

        /// <summary>
        /// Выводит сообщение, что это не треугольник
        /// </summary>
        public static void notTriangle()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка! Это не треугольник.");
        }
        public static void Main()
        {
            Console.WriteLine("Впишите значения сторон треугольника (a, b, c): ");
            double a, b, c; // далее проверка на ввод цифр
            while (!double.TryParse(Console.ReadLine(), out a))
                Console.WriteLine("Ошибка ввода! Введите число a");
            while (!double.TryParse(Console.ReadLine(), out b))
                Console.WriteLine("Ошибка ввода! Введите число b");
            while (!double.TryParse(Console.ReadLine(), out c))
                Console.WriteLine("Ошибка ввода! Введите число c");

            // углы сторон
            double alpha = (180 * Math.Acos((a * a + c * c - b * b) / (2 * a * c))) / Math.PI;
            double beta = (180 * Math.Acos((a * a + b * b - c * c) / (2 * a * b))) / Math.PI;
            double sigma = (180 * Math.Acos((c * c + b * b - a * a) / (2 * c * b))) / Math.PI;
            string triangleAngleType; // тип углов треугольника (прямоуг, тупоугольный, остроугольный)
            string triangleType; // тип треугольника (равносторон, равнобедрен, произвольный треуг)
            if (alpha > 90.0 || beta > 90.0 || sigma > 90.0)
                triangleAngleType = "тупоугольный";
            else if (alpha == 90.0 || beta == 90.0 || sigma == 90.0)
                triangleAngleType = "прямоугольный";
            else
                triangleAngleType = "остроугольный";

            if (a == b && a == c && b == c)
                triangleType = "равносторонний";
            else if (a == b || a == c || b == c)
                triangleType = "равнобедренный";
            else
                triangleType = "произвольный";


            hello();
            int choose = Convert.ToInt32(Console.ReadLine());
            bool isTriangle; // проверка на треугольник
            if ((a + b > c) && (b + c > a) && (a + c > b))
                isTriangle = true;
            else
                isTriangle = false;

            switch (choose)
            {
                case 1:
                    Console.WriteLine("Выбрана 1 задача \n");
                    if (isTriangle == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Это треугольник");
                    }
                    else
                        notTriangle();
                    break;
                case 2:
                    Console.WriteLine("Выбрана 2 задача \n");
                    if (isTriangle == true)
                    {
                        Console.WriteLine("Треугольник " + triangleType + " и " + triangleAngleType);
                        writeAngles(alpha, beta, sigma);
                    }
                    else
                        notTriangle();
                    break;
                case 3:
                    Console.WriteLine("Выбрана 3 задача \n");
                    if (isTriangle == true)
                        Console.WriteLine("Площадь = " + triangleSquare(a, b, c));
                    else
                        notTriangle();
                    break;
                case 4:
                    Console.WriteLine("Выбрана 4 задача \n");
                    double iza = (2 * triangleSquare(a, b, c)) / a;
                    double izb = (2 * triangleSquare(a, b, c)) / b;
                    double izc = (2 * triangleSquare(a, b, c)) / c;
                    double big = 0;
                    double mal = 0;
                    // проверка на наибольшую высоту
                    if ((iza > izb) && (iza > izc))
                        big = iza;
                    else if ((izb > iza) && (izb > izc))
                        big = izb;
                    else if ((izc > iza) && (izc > izb))
                        big = izc;

                    // проверка на наименьшую высоту
                    if ((iza < izb) && (iza < izc))
                        mal = iza;
                    else if ((izb < iza) && (izb < izc))
                        mal = izb;
                    else if ((izc < iza) && (izc < izb))
                        mal = izc;
                    if (isTriangle == true)
                    {
                        if (a == b && a == c && b == c)
                            Console.WriteLine("Треугольник - равносторонний, высота = " + (Math.Sqrt(3.0) / 2) * a);
                        else
                        {
                            Console.WriteLine("Наибольшая высота = " + big); // выводит наибольшую высоту
                            Console.WriteLine("Наименьшая высота = " + mal); // выводит наименьшую высоту
                        }
                    }
                    else
                        notTriangle();
                    break;
                case 5:
                    Console.WriteLine("Выбрана 5 задача \n");
                    if (isTriangle == true)
                        Console.WriteLine("Площадь впис. окружности = " + triangleSquare(a, b, c) * ((a + b + c) / 2)); // выводит значение площади
                    else
                        notTriangle();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка. Вы должны выбирать числа от 1 до 5!");
                    break;
            }
        }
    }
}
*/