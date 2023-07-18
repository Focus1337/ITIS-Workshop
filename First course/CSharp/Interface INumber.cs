using System;
using System.Numerics;

namespace CSHARP
{
    class Program
    {
        static void Main()
        {
            var sum1 = new VeryLongNumber();
            var sum2 = new SimpleLongNumber();
            var numbersVery = new VeryLongNumber[5];
            var numbersSimple = new SimpleLongNumber[5];

            Console.WriteLine("Введите 5 чисел: ");
            for (int i = 0; i < numbersVery.Length; i++)
                numbersVery[i] = new VeryLongNumber(Console.ReadLine());

            Console.WriteLine("Введите 5 чисел: ");
            for (int i = 0; i < numbersSimple.Length; i++)
                numbersSimple[i] = new SimpleLongNumber(Console.ReadLine());

            for (int i = 0; i < numbersVery.Length; i++)
                sum1 = sum1.Add(numbersVery[i]);

            for (int i = 0; i < numbersSimple.Length; i++)
                sum2 = sum2.Add(numbersSimple[i]);

            Console.WriteLine($"sum1: {sum1.Number}");
            Console.WriteLine($"sum2: {sum2.Number}");
            Console.WriteLine($"total sum: {int.Parse(sum1.Number) + int.Parse(sum2.Number)}");
        }
    }

    interface INumber<T>
    {
        string Number { get; set; }
        T Add(T number);
        T Sub(T number);
        int CompareTo(T number);
    }

    public class VeryLongNumber : INumber<VeryLongNumber>
    {
        public string Number { get; set; }
        public VeryLongNumber() => Number = "0";
        public VeryLongNumber(string newNumber) => Number = newNumber;

        public VeryLongNumber Add(VeryLongNumber newNumber)
        {
            var res = new VeryLongNumber();
            res.Number = (BigInteger.Parse(newNumber.Number) + BigInteger.Parse(Number)).ToString();
            return res;
        }

        public VeryLongNumber Sub(VeryLongNumber newNumber)
        {
            var res = new VeryLongNumber();
            res.Number = (BigInteger.Parse(newNumber.Number) - BigInteger.Parse(Number)).ToString();
            return res;
        }

        public int CompareTo(VeryLongNumber newNumber)
        {
            if (BigInteger.Parse(newNumber.Number) > BigInteger.Parse(Number))
                return 1;
            else if (BigInteger.Parse(newNumber.Number) < BigInteger.Parse(Number))
                return -1;
            else
                return 0;
        }

    }

    public class SimpleLongNumber : INumber<SimpleLongNumber>
    {
        public string Number { get; set; }
        public SimpleLongNumber() => Number = "0";
        public SimpleLongNumber(string newNumber) => Number = newNumber;

        public SimpleLongNumber Add(SimpleLongNumber newNumber)
        {
            var res = new SimpleLongNumber();
            res.Number = (int.Parse(newNumber.Number) + int.Parse(Number)).ToString();
            return res;
        }

        public SimpleLongNumber Sub(SimpleLongNumber newNumber)
        {
            var res = new SimpleLongNumber();
            res.Number = (long.Parse(Number) - long.Parse(newNumber.Number)).ToString();
            return res;
        }

        public int CompareTo(SimpleLongNumber newNumber)
        {
            if (BigInteger.Parse(newNumber.Number) > BigInteger.Parse(Number))
                return 1;
            else if (BigInteger.Parse(newNumber.Number) < BigInteger.Parse(Number))
                return -1;
            else
                return 0;
        }
    }
}
