/*using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CSharp_1kurs
{
    class Triforce
    {
        static void MakeTriforce(int height)
        {
            char space = ' '; // пустой символ (костыль небольшой)
            char paint = '*'; // символ для треугольника
            for (int lineNumber = 1; lineNumber <= height; lineNumber++) // рисует верхний треугольник
            {
                //Console.Write(Enumerable.Repeat(" ", scale - row));
                // изначально хотел это использовать для повтора символа,
                // но нашёл в stackoverflow, что можно использовать new string

                Console.Write(new string(space, height * 2 - lineNumber)); // для симметрии
                Console.Write(new string(paint, lineNumber * 2 - 1)); // рисует символы верхнему треугольнику
                Console.WriteLine();
            }
            for (int lineNumber = 1; lineNumber <= height; lineNumber++) // рисует нижние треугольники
            {
                Console.Write(new string(space, height - lineNumber)); // для симметрии
                Console.Write(new string(paint, lineNumber * 2 - 1)); // рисует символы нижнему левому треугольнику
                Console.Write(new string(space, (height - lineNumber) * 2 + 1));
                Console.Write(new string(paint, lineNumber * 2 - 1)); // рисует символы нижнему правому треугольнику
                Console.WriteLine();
            }
        }

        static void Main()
        {
            // ADIEV ADEL - 11-010
            // ЗАДАЧА: Трифорс (пункт 7.0)
            int n = 0;
            Console.WriteLine("Введите высоту n:");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                Console.WriteLine("Ошибка ввода!");
            MakeTriforce(n);
        }
        // другой код, попытался сделать трифорс, не получилось; смог просто треугольник нарисовать
        //public static void Main()
        //{
        //    int i, j, n;
        //    Console.WriteLine("Введите высоту:");
        //    n = Convert.ToInt32(Console.ReadLine());
        //    for (i = 0; i < n; i++)
        //    {
        //        for (j = 1; j <= n - i - 1; j++)
        //            Console.Write(" ");
        //        for (j = 1; j <= 2 * i + 1; j++)
        //            Console.Write("*");
        //        Console.Write("\n");

        //    }
        //    // перевёрнутый треугольник
        //    Console.WriteLine();
        //    for (i = 1; i <= n; i++)
        //    {
        //        for (j = 1; j < i; j++)
        //        {
        //            Console.Write(" ");
        //        }
        //        for (j = 1; j <= (n * 2 - (i * 2 - 1)); j++)
        //        {
        //            Console.Write("*");
        //        }
        //        Console.WriteLine();
        //    }
        //}

    }
}*/