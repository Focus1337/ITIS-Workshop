using MyFakeList;
using System;
using System.Collections;
using System.Linq;

namespace MyFakeList
{
    public class List<T>
    {
        //============ public методы ============
        public int Capacity => list.Length; // capacity = array length
        public int Count { get; private set; }
        public T this[int i] // создаем индексатор
        {
            get
            {
                ThrowIndexException(i);
                return list[i];
            }
            set
            {
                ThrowIndexException(i);
                list[i] = value;
            }
        }
        public List() => list = new T[0]; // изначально ничего в листе нет
        public int IndexOf(T item) // получаем индекс листа
        {
            int i = 0;
            while ((i < Count) && (!list[i].Equals(item)))
                i++;
            if (i == Count)
                return -1;
            return i;
        }
        public void Insert(int index, T item) => InsertItem(index, item);
        public void RemoveAt(int index)
        {
            ThrowIndexException(index);
            for (var i = index; i < Count - 1; i++)
            {
                list[i] = list[i + 1];
            }
            list[Count - 1] = default(T);
            Count--;
        }
        public void Add(T item) => InsertItem(Count, item);
        public void AddRange(ICollection collection)
        {
            foreach (var e in collection)
                Add((dynamic)e);
        }
        public void AddRange(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
                Add(list[i]);
        }
        public void ChangeMin()
        {
            //============ получение ключа максимального элемента ============
            var maxValueKey = IndexOf(list.OrderByDescending(x => x).Max());

            //============ создание временного массива ============
            // (это сделано для того, чтобы обойти лишние нули в листе. Т.е. Count 13, а Capacity 16, т.е. 3 лишних нуля)
            var tempItems = new T[Count];
            for (int i = 0; i < Count; i++)
                tempItems[i] = list[i];
            //============ получение ключа минимального элемента ============
            var minValueKey = Array.IndexOf(tempItems, (dynamic)tempItems.Min());

            //============ swap элементов ============
            var temp = list[maxValueKey];
            list[maxValueKey] = list[minValueKey];
            list[minValueKey] = temp;
        }

        public void Remove(T item) => RemoveAt(IndexOf(item));
        public void SortSelection()
        {
            for (var i = 0; i < Count - 1; i++)
            {
                int min = i; // изначально наш минимальный элемент - это самый первый

                for (var j = i + 1; j < Count; j++) // i+1 - т.к. мы не учитываем число, которое ушло прошло сортировку (слева)
                    if ((dynamic)list[j] < (dynamic)list[min]) // обычная проверка на минимум
                        min = j;

                if (min != i) // лишние действия не нужны, поэтому пропустим, если это то же самое число
                {
                    var temp = (dynamic)list[i];
                    list[i] = list[min];
                    list[min] = temp;
                }
            }
        }
        public void Sort() => Array.Sort(list);


        //============ private методы ============
        private T[] list;

        private void ThrowIndexException(int index)
        {
            if ((index < 0) || (index >= Count))
                throw new IndexOutOfRangeException("Ошибка индекса! Элементов < 0 || Вышли за размер списка");
        }
        private void ResizeList()
        {
            Count++;

            if (list.Length < Count)
                Array.Resize(ref list, list.Length == 0 ? 1 : list.Length * 2);
        }
        private void InsertItem(int index, T item)
        {
            ResizeList();
            for (var i = Count - 1; i > index; i--)
                list[i] = list[i - 1];

            list[index] = item;
        }
    }
}


namespace Prog
{
    class Pr
    {
        static void Main()
        {
            var list = new List<int>();
            var rand = new Random();
            list.Add(rand.Next(-1000, 1000));
            list.Add(rand.Next(-1000, 1000));
            list.Add(rand.Next(-1000, 1000));
            list.Add(rand.Next(-1000, 1000));
            list.Insert(0, 4);
            var test = new int[5] { 100, 200, 300, 400, 500 };
            var test2 = new List<int>();
            test2.Add(1000);
            test2.Add(2000);
            test2.Add(3000);

            list.AddRange(test);
            list.AddRange(test2);

            for (int i = 0; i < list.Count; i++)
                Console.WriteLine(list[i]);
            Console.WriteLine("\nChangeMin()");
            list.ChangeMin();
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine(list[i]);
        }
    }
}