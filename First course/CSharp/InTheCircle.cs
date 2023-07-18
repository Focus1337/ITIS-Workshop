using System;
/*
namespace InTheCircle
{
	class Program
	{
		static string CheckDot(double xCenter, double yCenter, double radius, double xDot, double yDot)
		{
			if (Math.Pow(xDot - xCenter, 2) + Math.Pow(yDot - yCenter, 2) <= radius*radius)
				return "Точка принадлежит окружности";
			else
				return "Точка не принадлежит окружности";
		}

		static void Main()
		{
			// ADIEV ADEL - 11-010
			// ЗАДАЧА: ПРОГРАММА ПРОВЕРЯЕТ, ПРИНАДЛЕЖИТ ЛИ ТОЧКА ОКРУЖНОСТИ (выполнены пункты 1.0, 1.1)
			double radius = 0, xDot = 0, yDot = 0, xCenter = 0, yCenter = 0;
			Console.WriteLine("Введите координаты центра 1) X; 2) Y окружности; 3) радиус окр-ти;\nКоординаты 4) X; 5) Y точки (всё через пробел)");
			string[] enteredData = Console.ReadLine().Split();
			try
			{
				if (!double.TryParse(enteredData[0], out xCenter))
					Console.WriteLine("Ошибка ввода!");
				if (!double.TryParse(enteredData[1], out yCenter))
					Console.WriteLine("Ошибка ввода!");
				if (!double.TryParse(enteredData[2], out radius) || radius < 0)
					Console.WriteLine("Ошибка ввода!");
				if (!double.TryParse(enteredData[3], out xDot))
					Console.WriteLine("Ошибка ввода!");
				if (!double.TryParse(enteredData[4], out yDot))
					Console.WriteLine("Ошибка ввода!");

				Console.WriteLine(CheckDot(xCenter, yCenter, radius, xDot, yDot));
			}
			catch (IndexOutOfRangeException) // выводит текст об ошибке, если string остался пустым
			{
			}
		}
	}
}*/