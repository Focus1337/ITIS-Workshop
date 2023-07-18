using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CSharp_1kurs
{
    public delegate void progDelegates();

    class Program
    {
        static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
                for (int j = i + 1; j < array.Length; j++)
                    if (array[i] > array[j]) 
                        Swap(array, i, j);
        }

        public static void SortInverse(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
                for (int j = i + 1; j < array.Length; j++)
                    if (array[i] < array[j])
                        Swap(array, i, j);
        }

        public static void Pp() { Console.WriteLine("Чел ты..."); }
        public static void Prog1()
        {
            var linkedList = new LinkedList<string>();
            //============ чтение из файла в массив ============
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var filePath1 = Path.Combine(desktopPath, "books.txt");
            var filePath2 = Path.Combine(desktopPath, "books2.txt");
            var oldBooks = File.ReadAllLines(filePath1);
            Stopwatch timer = new Stopwatch();

            //============ сразу присвоить в отсортированном виде ============
            Array.Sort(oldBooks);

            timer.Start();
            //============ массив в линкед лист ============
            for (int i = 0; i < oldBooks.Length; i++)
                linkedList.AddLast(oldBooks[i]);

            LinkedListNode<string> node;
            //============ вывод линкед листа ============
            for (node = linkedList.First; node != null; node = node.Next)
                Console.WriteLine(node.Value + "\t");
            Console.WriteLine();

            //============ сортировка линкед листа ============
            var tempList = new List<string>(linkedList);
            //  tempList.Sort();

            //============= список в линкед лист ============
            for (int i = 0; i < tempList.Count; i++)
                linkedList.AddLast(tempList[i]);

            //============ добавить в список элемент и отсортировать ============
            // tempList.Add("Gerasim iz SF");
            var newBooks = File.ReadAllLines(filePath2);
            for (int i = 0; i < newBooks.Length; i++)
                tempList.Add(newBooks[i]);

            tempList.Sort();

            //============ очистка линкед листа и лист в линкед лист ============
            linkedList.Clear();
            for (int i = 0; i < tempList.Count; i++)
                linkedList.AddLast(tempList[i]);
            tempList.Clear();

            timer.Stop();
            Console.WriteLine(timer.ElapsedMilliseconds + " ms\n");

            for (node = linkedList.First; node != null; node = node.Next)
                Console.WriteLine(node.Value + "\t");
        }

        public static void Prog2()
        {
            //============ чтение из файла в массив ============
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var filePath1 = Path.Combine(desktopPath, "books.txt");
            var filePath2 = Path.Combine(desktopPath, "books2.txt");
            var oldBooks = File.ReadAllLines(filePath1);
            var newBooks = File.ReadAllLines(filePath2);

            var oldBooksLinkedList = new LinkedList<string>();
            var newBooksLinkedList = new LinkedList<string>();
            var finalLinkedList = new LinkedList<string>();

            //============ лень было сортировать в txt, так что пусть сортируется список книг здесь ============
            Array.Sort(oldBooks);
            Array.Reverse(oldBooks);
            Array.Sort(newBooks);
            Array.Reverse(newBooks);

            Stopwatch timer = new Stopwatch();
            timer.Start();
            //============ присвоить linkedlist'y array ============
            foreach (var oldB in oldBooks)
                oldBooksLinkedList.AddLast(oldB);
            foreach (var newB in newBooks)
                newBooksLinkedList.AddLast(newB);

            //============ вывод линкед листа ============
            Console.WriteLine("1st linked list:\n");
            foreach (var oldB in oldBooksLinkedList)
                Console.WriteLine(oldB);
            Console.WriteLine("\n2nd linked list:\n");
            foreach (var newB in newBooksLinkedList)
                Console.WriteLine(newB);

            //============ скопировать элементы из линкедлистов в массив ============
            string[] ConcatedLinkedLists = new string[oldBooksLinkedList.Count + newBooksLinkedList.Count];
            oldBooksLinkedList.CopyTo(ConcatedLinkedLists, 0);
            newBooksLinkedList.CopyTo(ConcatedLinkedLists, oldBooksLinkedList.Count);

            //============ отсортировать по невозрастании ============
            Array.Sort(ConcatedLinkedLists);
            Array.Reverse(ConcatedLinkedLists);

            //============ массив в линкедлист ============
            foreach (var conc in ConcatedLinkedLists)
                finalLinkedList.AddLast(conc);
            timer.Stop();
            //============ вывести линкедлист ============
            Console.WriteLine();
            foreach (var e in finalLinkedList)
                Console.WriteLine(e);

            Console.WriteLine($"\n{timer.ElapsedMilliseconds} ms");
        }

        public static int IndexOf<T>(LinkedList<T> list, T item)
        {
            var count = 0;
            for (var node = list.First; node != null; node = node.Next, count++)
            {
                if (item.Equals(node.Value))
                    return count;
            }
            return -1;
        }

        public static void Prog3()
        {
            var linkedList = new LinkedList<int>();
            var rand = new Random();

            //============ заполнение линкед листа ============
            while (linkedList.Count < 20)
                linkedList.AddLast(rand.Next(-100, 100));

            Console.WriteLine("Linked List выглядил так: \n");
            foreach (var e in linkedList)
                Console.WriteLine(e);
            var numbers = new LinkedList<int>();

            LinkedListNode<int> node;
            //============ проверка по элементам ============
            for (node = linkedList.First; node != null; node = node.Next)
                if (node.Value > 0 && IndexOf(linkedList, node.Value) % 2 == 0)
                    numbers.AddLast(node.Value);
            linkedList.Clear();

            //============ вывод линкед листа ============
            Console.WriteLine("\n\n");
            foreach (var e in numbers)
                Console.Write($"{e} ");
        }
        public static void Prog4()
        {
            var list1 = new LinkedList<int>();
            var list2 = new LinkedList<int>();

            Console.WriteLine("Введите значения для первого списка (как будет достаточно, напишите -1)");
            do list1.AddLast(int.Parse(Console.ReadLine()));
            while (list1.Last.Value != -1);

            Console.WriteLine("Введите значения для второго списка (как будет достаточно, напишите -1)");
            do list2.AddLast(int.Parse(Console.ReadLine()));
            while (list2.Last.Value != -1);

            bool equal = list1.SequenceEqual(list2);
            Console.WriteLine("The lists {0} equal.", equal ? "are" : "are not");
        }
        public static void Prog5()
        {
            var linkedList = new LinkedList<int>();
            for (int i = 1; i < 11; i++)
                linkedList.AddLast(i);

            var savedList = new List<int>();
            LinkedListNode<int> node;
            for (node = linkedList.First; node != null; node = node.Next)
            {
                if (IndexOf(linkedList, node.Value) != 0)
                {
                    for (int i = 0; i < IndexOf(linkedList, node.Value); i++)
                        savedList.Add(linkedList.ElementAt(i));

                    for (int i = savedList.Count - 1; i >= 0; i--)
                        linkedList.AddAfter(node, savedList[i]);

                    foreach (var e in linkedList)
                        Console.Write(e+" ");

                    Console.WriteLine();
                    savedList.Clear();
                    Console.ReadKey();
                }
            }

        }
        public static void Prog6()
        {
            var linkedList = new LinkedList<string>();
            linkedList.AddLast("examplesofcompletesentences");
            linkedList.AddLast("canyougotospeakwithyouritmathrepetitor");
            linkedList.AddLast("sometimesineeditmathrepetitor");
            linkedList.AddLast("itmathrepetitorisbestthingever");
            linkedList.AddLast("itmathrepetitoritmathrepetitoritmathrepetitoritmathrepetitoritmathrepetitor" +
                "itmathrepetitoritmathrepetitoritmathrepetitoritmathrepetitoritmathrepetitor");
            foreach (var e in linkedList)
                Console.WriteLine(e);
            Console.WriteLine();
            LinkedListNode<string> node;

            Stopwatch timer = new Stopwatch();
            timer.Start();
            var wordBefore = "itmathrepetitor";
            for (node = linkedList.First; node != null; node = node.Next)
            {
                for (int i = 0; i < node.Value.Length; i++)
                { // лучшая проверка, которая была создана человечеством в 21 веке (очень быстрая, кстати)
                    if (node.Value[i] == 'i' && node.Value[i + 1] == 't' && node.Value[i + 2] == 'm' && node.Value[i + 3] == 'a'
                        && node.Value[i + 4] == 't' && node.Value[i + 5] == 'h' && node.Value[i + 6] == 'r' && node.Value[i + 7] == 'e'
                         && node.Value[i + 8] == 'p' && node.Value[i + 9] == 'e' && node.Value[i + 10] == 't' && node.Value[i + 11] == 'i'
                             && node.Value[i + 12] == 't' && node.Value[i + 13] == 'o' && node.Value[i + 14] == 'r')
                    {
                        var before = node.Value.Substring(0, i);
                        var after = node.Value.Substring(i + 15, node.Value.Length - before.Length - wordBefore.Length);
                        node.Value = before + "silence" + after;
                    }
                }
            }
            timer.Stop();

            foreach (var e in linkedList)
                Console.WriteLine(e);
            Console.WriteLine("\n" + timer.ElapsedMilliseconds);
        }
        public static void Prog7()
        {
            //============ чтение из файла в массив ============
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var filePath = Path.Combine(desktopPath, "text.txt");
            var text = File.ReadAllLines(filePath);
            var linkedList = new LinkedList<int>();

            for (int i = 0; i < text.Length; i++)
                linkedList.AddLast(text[i].Length);

            foreach (var e in linkedList)
                Console.WriteLine(e);
        }
        public static void Prog8()
        {
            var linkedlist = new LinkedList<List<string>>();
            var group0 = new List<string>();
            var group1 = new List<string>();
            var group2 = new List<string>();
            var group3 = new List<string>();
            group0.Add("Petrov");
            group0.Add("Bukin");
            group0.Add("Genov");
            group0.Add("Petrov");

            group1.Add("Pushnoi");
            group1.Add("Zhirinovskiy");
            group1.Add("Derevyanniy");

            group2.Add("Pushkin");
            group2.Add("Lermontov");
            group2.Add("Tolstoy");

            group3.Add("Solovev");
            group3.Add("Ananasov");
            group3.Add("Geniy");
            group3.Add("Seriy");
            group3.Add("Krutoi");

            linkedlist.AddLast(group0);
            linkedlist.AddLast(group1);
            linkedlist.AddLast(group2);
            linkedlist.AddLast(group3);

            LinkedListNode<List<string>> node;
            for (node = linkedlist.First; node != null; node = node.Next)
            {
                Console.WriteLine($"Группа {IndexOf(linkedlist, node.Value)}");
                for (int i = 0; i < node.Value.Count; i++)
                    Console.WriteLine(node.Value[i]);

                Console.WriteLine();
            }
        }

        class Students
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Patronymic { get; set; } // отчество
            public int Course { get; set; }
            public int Group { get; set; }
            public int YearOfBirth { get; set; }
            public int Grade1 { get; set; }
            public int Grade2 { get; set; }
            public int Grade3 { get; set; }
            public int Grade4 { get; set; }
            public int Grade5 { get; set; }
        }
        public static void Prog9()
        {
            var linkedList = new LinkedList<Students>();
            var students = new Students();

            linkedList.AddLast(new Students()
            {
                Name = "Сергей",
                Surname = "Петров",
                Patronymic = "Гогич",
                YearOfBirth = 2000,
                Course = 2,
                Group = 1,
                Grade1 = 4,
                Grade2 = 4,
                Grade3 = 3,
                Grade4 = 5,
                Grade5 = 4
            });
            linkedList.AddLast(new Students()
            {
                Name = "Антон",
                Surname = "Черный",
                Patronymic = "Сергеевич",
                YearOfBirth = 2001,
                Course = 1,
                Group = 2,
                Grade1 = 4,
                Grade2 = 4,
                Grade3 = 4,
                Grade4 = 5,
                Grade5 = 4
            });
            linkedList.AddLast(new Students()
            {
                Surname = "Крюкова",
                Name = "Ольга",
                Patronymic = "Петровна",
                YearOfBirth = 2000,
                Course = 2,
                Group = 1,
                Grade1 = 3,
                Grade2 = 4,
                Grade3 = 3,
                Grade4 = 3,
                Grade5 = 5
            });
            linkedList.AddLast(new Students()
            {
                Surname = "Дудник",
                Name = "Андрей",
                Patronymic = "Романович",
                YearOfBirth = 2002,
                Course = 1,
                Group = 2,
                Grade1 = 5,
                Grade2 = 5,
                Grade3 = 5,
                Grade4 = 5,
                Grade5 = 4
            });
            linkedList.AddLast(new Students()
            {
                Surname = "Васильев",
                Name = "Михаил",
                Patronymic = "Петрович",
                YearOfBirth = 1997,
                Course = 3,
                Group = 3,
                Grade1 = 3,
                Grade2 = 5,
                Grade3 = 3,
                Grade4 = 5,
                Grade5 = 5
            });
            linkedList.AddLast(new Students()
            {
                Surname = "Дуденко",
                Name = "Василий",
                Patronymic = "Алексеевич",
                YearOfBirth = 1998,
                Course = 3,
                Group = 3,
                Grade1 = 4,
                Grade2 = 4,
                Grade3 = 4,
                Grade4 = 4,
                Grade5 = 4
            });

            linkedList = new LinkedList<Students>(linkedList.OrderBy(val => val.Course)); // сортировка по курсу
            var courseLinkedList = new LinkedList<Students>(); // linkedlist студентов по курсу
            var tempLinkedList = new LinkedList<Students>(); // временный linkedlist
            LinkedListNode<Students> node;
            for (int course = 1; course < 4; course++)
            {
                for (node = linkedList.First; node != null; node = node.Next)
                {
                    if (node.Value != null)
                        if (node.Value.Course == course)
                            courseLinkedList.AddLast(node.Value); // добавляем людей из одного курса        
                }
                courseLinkedList = new LinkedList<Students>(courseLinkedList.OrderBy(val => val.Surname)); // сортировка фамильная
                tempLinkedList = new LinkedList<Students>(tempLinkedList.Concat(courseLinkedList)); // переносим курсовиков во временный список

                courseLinkedList.Clear(); // удаляем курс             
            }

            linkedList.Clear(); // удаляем начальный список
            linkedList = new LinkedList<Students>(linkedList.Concat(tempLinkedList));
            tempLinkedList.Clear(); // удаляем временный список
            foreach (var e in linkedList)
                Console.WriteLine($"ФИО: {e.Name} { e.Surname} {e.Patronymic}, Birth: {e.YearOfBirth}," +
                    $" Course: {e.Course}, Group: {e.Group}, Grade1: {e.Grade1}, Grade2: {e.Grade2}," +
                    $" Grade3: {e.Grade3}, Grade4: {e.Grade4}, Grade5: {e.Grade5}");

            linkedList = new LinkedList<Students>(linkedList.OrderBy(val => val.YearOfBirth)); // сортировка по году рождения
            Console.WriteLine();
            Console.WriteLine($"Самый старший студент: {linkedList.First.Value.Name} {linkedList.First.Value.Surname} {linkedList.First.Value.Patronymic}");
            Console.WriteLine($"Самый младший студент: {linkedList.Last.Value.Name} {linkedList.Last.Value.Surname} {linkedList.Last.Value.Patronymic}");
        }

        public static void Main()
        {
            progDelegates progs = Pp;
            Console.Write("Выберите номер задачи (1-9): ");
            int choose = int.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (choose)
            {
                case 1:
                    progs = Prog1;
                    break;
                case 2:
                    progs = Prog2;
                    break;
                case 3:
                    progs = Prog3;
                    break;
                case 4:
                    progs = Prog4;
                    break;
                case 5:
                    progs = Prog5;
                    break;
                case 6:
                    progs = Prog6;
                    break;
                case 7:
                    progs = Prog7;
                    break;
                case 8:
                    progs = Prog8;
                    break;
                case 9:
                    progs = Prog9;
                    break;
                default:
                    break;
            }

            progs();
            Console.ReadKey();
        }
    }
}
