using System;

namespace CSharp_1kurs
{
    class Program
    {
        static void Main()
        {
            var sum = new Number<long>(0);
            var numbers = new Number<long>[5];
            Console.WriteLine("Введите 5 чисел: ");
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = new Number<long>(long.Parse(Console.ReadLine()));

            for (int i = 0; i < numbers.Length; i++)
                sum = sum.Add(numbers[i]);
           
            Console.WriteLine($"sum: {sum.Num}");
        }

        class Number<T>
        {
            public T Num { get; set; }
            public Number() => Num = default(T);
            public Number(T number) => Num = number;
            public Number<T> Add(Number<T> number)
            {
                var res = new Number<T>();
                res.Num = (dynamic)number.Num + (dynamic)Num; 
                return res;
            }

            public Number<T> Sub(Number<T> number)
            {
                var res = new Number<T>();
                res.Num = (dynamic)Num - (dynamic)number.Num;
                return res;
            }

            public int CompareTo(Number<T> number)
            {
                if ((dynamic)Num > (dynamic)number.Num)
                    return 1;
                else
                {
                    if ((dynamic)number.Num > (dynamic)Num)
                        return -1;
                    else
                        return 0;
                }
            }

        }
    }
}