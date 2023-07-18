using System;
using System.Collections.Generic;

namespace Prog
{
    class Programm
    {
        enum ErrorKeys
        {
            RightBracketCountGreater, // кол-во правых скобок > левых
            LeftBracketCountGreater, // кол-во правых скобок < левых
            RightBracketIndexError, // правая скобка идёт спереди левой

            BracesInsideError, // {} внутри какой-то функции или индексатора: Pow({}) или arr[{}]
            SquareBracketsEmpty, // [] пустые (нет значения индексатора)
            SquareBracketsNoIndentifier // нет индефикатора у [] (т.е. просто [], а не mass[])
        }

        static void GetStringList(List<string> str)
        {
            // ПУНКТ А
            str.Add("(())");
            str.Add("())"); // ошибка
            str.Add("(()"); // ошибка
            str.Add("if (Math.Add())");
            str.Add("if (Math.Add))"); // ошибка
            str.Add("Math.Add("); // ошибка
            str.Add("else if (Math.Pow (1, 2)"); // ошибка
            str.Add("Console.WriteLine(mass.Length, Math.Pow(1,2), intList.ToString()))"); // ошибка
            str.Add("Console.WriteLine(mass.Length, Math.Pow(1,2), intList.ToString())");
            str.Add(")(("); // ошибка
            str.Add(")()("); // ошибка

            // ПУНКТ Б
            str.Add("if (yes) { test(); }");
            str.Add("Add({test()})"); // ошибка
            str.Add("if (mass[] > 0)"); // ошибка
            str.Add("else if (mass[i] > 10");
            str.Add("array[{}]"); // ошибка
            str.Add("if (test) {}");
            str.Add("]["); // ошибка
            str.Add("[]"); // ошибка
            str.Add("ad[e]]"); // ошибка
            str.Add(")(( ][]] [][ {}} }{"); // ошибка
        }

        static void GetErrors(Dictionary<ErrorKeys, string> errors)
        {
            // ПУНКТ А
            errors.Add(ErrorKeys.RightBracketCountGreater, "Кол-во правых скобок больше, чем левых (возможно, у метода / операции и др. нет левой скобки)");
            errors.Add(ErrorKeys.LeftBracketCountGreater, "Кол-во левых скобок больше, чем правых (возможно, у метода / операции и др. нет правой скобки)");
            errors.Add(ErrorKeys.RightBracketIndexError, "правая скобка оказалась спереди левой. Либо у метода / операции и др. нет левой скобки");
            // ПУНКТ Б
            errors.Add(ErrorKeys.BracesInsideError, "{} оказалось внутри метода / индексатора");
            errors.Add(ErrorKeys.SquareBracketsEmpty, "[] требуется значение индексатора, т.е. [] пустой");
            errors.Add(ErrorKeys.SquareBracketsNoIndentifier, "требуется идентификатор для [], т.е. нет имени массива");
        }

        public static void Main()
        {
            //============ объявление словаря из ошибок ============
            var errors = new Dictionary<ErrorKeys, string>();
            GetErrors(errors);

            //============ объявление списка строк ============
            var testStrings = new List<string>();
            GetStringList(testStrings);

            //============ объявление переменных ============
            var length = testStrings.Count;
            var rightRoundBracketCount = new int[length];
            var leftRoundBracketCount = new int[length];
            var rightSquareBracketCount = new int[length];
            var leftSquareBracketCount = new int[length];
            var rightBraceCount = new int[length];
            var leftBraceCount = new int[length];

            var rightRoundBracketIndex = 100;
            var leftRoundBracketIndex = 100;
            var rightSquareBracketIndex = 100;
            var leftSquareBracketIndex = 100;
            var rightBraceIndex = 100;
            var leftBraceIndex = 100;

            var rightRoundBracketInFrontError = new bool[length];
            var rightSquareBracketInFrontError = new bool[length];
            var rightBraceInFrontError = new bool[length];

            var SquareBracketsEmptyError = new bool[length];
            var SquareBracketsNoIndentifierError = new bool[length];

            var BraceInsideError = new bool[length];

            //============ подсчёт кол-ва скобочек скобочек ============
            for (int i = 0; i < testStrings.Count; i++) // Проход по листу строк
            {
                // Проход по каждому элементу строки
                for (int charIndex = 0; charIndex < testStrings[i].Length; charIndex++)
                {
                    if (testStrings[i][charIndex].Equals('('))
                    {
                        leftRoundBracketCount[i]++; // увелич. счетчик "("
                        leftRoundBracketIndex = charIndex;
                    }

                    if (testStrings[i][charIndex].Equals(')'))
                    {
                        rightRoundBracketCount[i]++; // увелич. счетчик ")"
                        rightRoundBracketIndex = charIndex;
                    }

                    if (testStrings[i][charIndex].Equals('['))
                    {
                        leftSquareBracketCount[i]++; // увелич. счетчик "["
                        leftSquareBracketIndex = charIndex;
                    }

                    if (testStrings[i][charIndex].Equals(']'))
                    {
                        rightSquareBracketCount[i]++; // увелич. счетчик "]"
                        rightSquareBracketIndex = charIndex;
                    }

                    if (testStrings[i][charIndex].Equals('{'))
                    {
                        leftBraceCount[i]++; // увелич. счетчик "{"
                        leftBraceIndex = charIndex;
                    }

                    if (testStrings[i][charIndex].Equals('}'))
                    {
                        rightBraceCount[i]++; // увелич. счетчик "}"
                        rightBraceIndex = charIndex;
                    }

                    if (rightRoundBracketIndex == 0 || rightRoundBracketIndex < leftRoundBracketIndex && rightRoundBracketCount[i] > leftRoundBracketCount[i])
                        rightRoundBracketInFrontError[i] = true;

                    if (rightSquareBracketIndex == 0 || rightSquareBracketIndex < leftSquareBracketIndex && rightSquareBracketCount[i] > leftSquareBracketCount[i])
                        rightSquareBracketInFrontError[i] = true;

                    if (rightBraceIndex == 0 || rightBraceIndex < leftBraceIndex && rightBraceCount[i] > leftBraceCount[i])
                        rightBraceInFrontError[i] = true;

                    if (leftSquareBracketIndex + 1 < testStrings[i].Length && testStrings[i][leftSquareBracketIndex + 1].Equals(']'))
                        SquareBracketsEmptyError[i] = true;

                    if (leftSquareBracketIndex < testStrings[i].Length && leftSquareBracketIndex - 1 < testStrings[i].Length &&
                        (leftSquareBracketIndex == 0 || !char.IsLetterOrDigit(testStrings[i][leftSquareBracketIndex - 1])))
                        SquareBracketsNoIndentifierError[i] = true;

                    if (rightBraceIndex < testStrings[i].Length && leftBraceIndex < testStrings[i].Length &&
                        (((leftRoundBracketIndex < leftBraceIndex && leftBraceIndex < rightRoundBracketIndex) ||
                        (leftSquareBracketIndex < leftBraceIndex && leftBraceIndex < rightSquareBracketIndex)) &&
                        (rightRoundBracketIndex > rightBraceIndex || rightSquareBracketIndex > rightBraceIndex)))
                        BraceInsideError[i] = true;

                }
                rightRoundBracketIndex = 100;
                leftRoundBracketIndex = 100;
                rightSquareBracketIndex = 100;
                leftSquareBracketIndex = 100;
                rightBraceIndex = 100;
                leftBraceIndex = 100;
            }

            //============ вывод ошибок ============
            for (int i = 0; i < testStrings.Count; i++) // Проход по листу строк
            {
                Console.WriteLine(testStrings[i]);
                testStrings[i] = testStrings[i].Replace(" ", ""); // чтобы он не считал пробелы


                // ПУНКТ А
                if (rightRoundBracketCount[i] == leftRoundBracketCount[i] && !rightRoundBracketInFrontError[i])
                    Console.WriteLine($"():   OK");
                else
                {
                    if (rightRoundBracketCount[i] > leftRoundBracketCount[i]) // кол-во правых больше левых
                        Console.WriteLine($"():   " + errors[ErrorKeys.RightBracketCountGreater]);

                    if (rightRoundBracketInFrontError[i])
                        Console.WriteLine($"():   " + errors[ErrorKeys.RightBracketIndexError]);

                    if (rightRoundBracketCount[i] < leftRoundBracketCount[i]) // кол-во правых меньше левых
                        Console.WriteLine($"():   " + errors[ErrorKeys.LeftBracketCountGreater]);
                }

                // ПУНКТ Б
                if (rightSquareBracketCount[i] == leftSquareBracketCount[i] &&
                    !rightSquareBracketInFrontError[i] && !SquareBracketsEmptyError[i] && !SquareBracketsNoIndentifierError[i])
                    Console.WriteLine($"[]:   OK");
                else
                {
                    if (rightSquareBracketCount[i] > leftSquareBracketCount[i]) // кол-во правых больше левых
                        Console.WriteLine($"[]:   " + errors[ErrorKeys.RightBracketCountGreater]);

                    if (rightSquareBracketInFrontError[i])
                        Console.WriteLine($"[]:   " + errors[ErrorKeys.RightBracketIndexError]);

                    if (rightSquareBracketCount[i] < leftSquareBracketCount[i]) // кол-во правых меньше левых
                        Console.WriteLine($"[]:   " + errors[ErrorKeys.LeftBracketCountGreater]);

                    if (SquareBracketsEmptyError[i])
                        Console.WriteLine($"[]:   " + errors[ErrorKeys.SquareBracketsEmpty]);

                    if (SquareBracketsNoIndentifierError[i])
                        Console.WriteLine($"[]:   " + errors[ErrorKeys.SquareBracketsNoIndentifier]);
                }

                if (rightBraceCount[i] == leftBraceCount[i] && !rightBraceInFrontError[i] && !BraceInsideError[i])
                    Console.WriteLine($"{{}}:   OK");
                else
                {
                    if (rightBraceCount[i] > leftBraceCount[i]) // кол-во правых больше левых
                        Console.WriteLine($"{{}}:   " + errors[ErrorKeys.RightBracketCountGreater]);

                    if (rightBraceInFrontError[i])
                        Console.WriteLine($"{{}}:   " + errors[ErrorKeys.RightBracketIndexError]);

                    if (rightBraceCount[i] < leftBraceCount[i]) // кол-во правых меньше левых
                        Console.WriteLine($"{{}}:   " + errors[ErrorKeys.LeftBracketCountGreater]);

                    if (BraceInsideError[i])
                        Console.WriteLine($"{{}}:   " + errors[ErrorKeys.BracesInsideError]);
                }

                Console.WriteLine();
            }
        }
    }
}