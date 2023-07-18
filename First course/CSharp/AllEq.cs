using System;
using System.Collections.Generic;

namespace Prog
{
    class Program
    {
        static List<string> AllEq(List<string> list)
        {
            //============ объявление переменных ============
            var newList = new List<string>(list); // копируем в новый лист старый
            // newList = list не делаю, т.к. таким я образом в куче я дам ссылку прямо на этот же лист (а зачем мне это?)
            var maxLength = 0; // хранение макс длины
            int lengthDelta; // разница в длине
            string newString; // сюда добавляем '_'

            //============ поиск макс длины ============
            for (int i = 0; i < newList.Count; i++)
            {
                if (newList[i].Length > maxLength)
                    maxLength = newList[i].Length;
            }

            //============ поэлементый поиск и добавление '_' ============
            for (int i = 0; i < newList.Count; i++)
            {
                if (newList[i].Length != maxLength) // если не равно самой максимальной длине, добавляем _
                {
                    lengthDelta = maxLength - newList[i].Length;
                    newString = new string('_', lengthDelta); // каждый раз выдаём ему новый стринг из символов _
                    newList[i] = new string(newList[i] + newString);
                }
            }

            return newList;
        }

        static void Main()
        {
            var stringList = new List<string>();
            stringList.Add("3434656g");
            stringList.Add("gnyfukrsthserhjrtyej");
            stringList.Add("qery2456u35678gfd");
            stringList.Add("dafhsrgj6785");
            stringList.Add("rfwhh");
            stringList.Add("12yfu22stvsrffjrvyvj");
            stringList.Add("4567hu7");

            Console.WriteLine("\n Новый список");
            AllEq(stringList).ForEach(Console.WriteLine);
            Console.WriteLine("\n Старый список");
            stringList.ForEach(Console.WriteLine);
        }
    }
}
