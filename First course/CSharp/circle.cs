using System;
/*
namespace CSharp_Shell
{
    public static class Program 
    {
        public static void Main() 
       {
       	double radius;
       	Console.WriteLine("Введите число n");
       	while (!double.TryParse(Console.ReadLine(), out radius) || radius <= 0)
       	Console.WriteLine("Ошибка! Введите число n");
       
    		double radiusin = radius - 0.4;
            double radiusout = radius + 0.4;

            for (double y = radius; y >= -radius; --y)
    		{
                for (double x = -radius; x < radiusout; x += 0.5)
                {
                    double squaresum = Math.Pow(x, 2) + Math.Pow(y, 2);
                    if (squaresum >= Math.Pow(radiusin, 2) && squaresum <= Math.Pow(radiusout, 2))
                        Console.Write(".");
                     else if (squaresum < Math.Pow(radiusin, 2) && squaresum < Math.Pow(radiusout, 2))
                        Console.Write(".");
                    else
                        Console.Write(" ");
                }
               Console.WriteLine();
            }
       }
    }
}*/