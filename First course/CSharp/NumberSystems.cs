/*using System;
using System.Text;
using System.Collections;

namespace CSharp_1kurs
{
    class NumberSystems
    {
        /// <summary>
        /// Переводит из деятичной системы счисления в систему счисления с основанием N
        /// </summary>
        /// <param name="number">Число, которое переводим </param>
        /// <param name="numberSystem">Система счисления, в которую переводим</param>
        /// <returns>Возвращает переведенное число в строковом формате</returns>
        static string From10ToN(string number, string numberSystem)
        {
            string newNum = "";
            int num = int.Parse(number);
            int chast = int.Parse(number);
            int numSys = int.Parse(numberSystem);
            ArrayList numTemp = new ArrayList();
            while (chast > 0)
            {
                chast /= numSys;
                numTemp.Add(num - chast * numSys);
                num = chast;
            }
            for (int j = numTemp.Count - 1; j >= 0; j--)
                newNum += ExchangeNumbersAndLetters(numTemp[j].ToString(), 0);
            return newNum;
        }

        /// <summary>
        /// Функция, заменяет буквы на числа и наоборот
        /// </summary>
        /// <param name="sym">Число, над которым нужно работать</param>
        /// <param name="toFrom">В какую сторону осуществляется действие относительно десятичной СС (0 - в 10, 1 - из 10) </param>
        /// <returns>Возвращает букву, если числу соответствует буква и наоборот, иначе число</returns>
        static string ExchangeNumbersAndLetters(string sym, int toFrom)
        {
            string characters = "ABCDEF";
            string s = "";
            if (toFrom == 0)
            {
                if (Convert.ToInt32(sym) >= 10) // если цифра >= 10 , то идёт замена на буквы
                    s += characters.Substring(Convert.ToInt32(sym) - 10, 1);
                else
                    s += sym;
            }
            else if (toFrom == 1)
            {
                if (characters.IndexOf(sym) == -1)
                    s += sym;
                else
                    s += (characters.IndexOf(sym) + 10).ToString();
            }
            return s;
        }

        /// <summary>
        /// Переводит системы счисления с основанием N в деятичную систему счисления 
        /// </summary>
        /// <param name="number">Число, которое переводим </param>
        /// <param name="sys">Система счисления, из которой переводим</param>
        /// <returns>Возвращает переведенное число в строковом формате</returns>
        static string FromNTo10(string number, string sys)
        {
            int newNum = 0;
            string temp;
            for (int i = 0; i < number.Length; i++)
            {
                temp = "";
                temp += ExchangeNumbersAndLetters(number.Substring(i, 1), 1);
                int t = (int)Math.Pow(Convert.ToDouble(sys), Convert.ToDouble(number.Length - (i + 1)));
                newNum += Convert.ToInt32(temp) * t;
            }
            return newNum.ToString();
        }

        /// <summary>
        /// Перевод из одной системы счисления в другую
        /// </summary>
        /// <param name="number">число</param>
        /// <param name="numSys1">СС, из которой будет перевод</param>
        /// <param name="numSys2">СС, в которую планируется перевод</param>
        /// <returns></returns>
        static string FromSys1ToSys2(string number, string numSys1, string numSys2)
        {
            string temp; // промежуточно меняю так: из указанной СС -> 10 СС -> в указанную СС
            temp = FromNTo10(number, numSys1); 
            temp = From10ToN(temp, numSys2);
            return temp;
        }

        public static void Main()
        {
             Console.WriteLine("Через пробел напишите: 1) число для перевода; 2) из какой СС; 3) в какую СС");
            string[] digitData = Console.ReadLine().Split();

            if (double.Parse(digitData[1]) <= 16 && double.Parse(digitData[1]) > 1
                && double.Parse(digitData[2]) <= 16 && double.Parse(digitData[2]) > 1)
            {
                try
                {
                    Console.WriteLine(FromSys1ToSys2(digitData[0], digitData[1], digitData[2]));
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Ошибка ввода");
                }
            }
            else
                Console.WriteLine("Ошибка ввода! Допустимые для перевода СС: от 2 по 16");
        }
    }
}*/