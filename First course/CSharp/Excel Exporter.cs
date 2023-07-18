using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Prog
{
    class ExcelExporter
    {
        public static void Main()
        {
            //============ чтение из файла в массив ============
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var filePath = Path.Combine(desktopPath, "Sample - Superstore Sales (Excel).csv");
            var allLines = File.ReadAllLines(filePath);

            //============ объявление переменных ============
            var list = new List<OrderInfo>();
            int seperateCount = 0;
            var seperateIndexes = new int[20];

            for (int lineIndex = 1; lineIndex < 151; lineIndex++)
            {
                //============ поиск индексов для ';' и их сохранение в массив ============
                for (int symbolIndex = 0; symbolIndex < allLines[lineIndex].Length; symbolIndex++)
                {
                    if (allLines[lineIndex][symbolIndex].Equals(';'))
                    {
                        seperateIndexes[seperateCount] = symbolIndex; // сохраняем индекс ';' в массив с размером 20 (т.к. ';' всего 20 на строку)
                        seperateCount++;
                    }
                }

                //============ добавление элементов в List ============
                // ФОРМАТ ДОБАВЛЕНИЯ:
                // тип.PARSE(следующий элемент после ';', предыдущий элемент ';' - следующий элемент ';' - 1)
                list.Add(new OrderInfo()
                {
                    RowID = int.Parse(allLines[lineIndex].Substring(0, seperateIndexes[0])),
                    OrderID = int.Parse(allLines[lineIndex].Substring(seperateIndexes[0] + 1, seperateIndexes[1] - seperateIndexes[0] - 1)),
                    OrderDate = DateTime.Parse(allLines[lineIndex].Substring(seperateIndexes[1] + 1, seperateIndexes[2] - seperateIndexes[1] - 1)),
                    OrderPriority = allLines[lineIndex].Substring(seperateIndexes[2] + 1, seperateIndexes[3] - seperateIndexes[2] - 1),
                    OrderQuantity = int.Parse(allLines[lineIndex].Substring(seperateIndexes[3] + 1, seperateIndexes[4] - seperateIndexes[3] - 1)),
                    Sales = double.Parse(allLines[lineIndex].Substring(seperateIndexes[4] + 1, seperateIndexes[5] - seperateIndexes[4] - 1)),
                    Discount = double.Parse(allLines[lineIndex].Substring(seperateIndexes[5] + 1, seperateIndexes[6] - seperateIndexes[5] - 1)),
                    ShipMode = allLines[lineIndex].Substring(seperateIndexes[6] + 1, seperateIndexes[7] - seperateIndexes[6] - 1),
                    Profit = double.Parse(allLines[lineIndex].Substring(seperateIndexes[7] + 1, seperateIndexes[8] - seperateIndexes[7] - 1)),
                    UnitPrice = double.Parse(allLines[lineIndex].Substring(seperateIndexes[8] + 1, seperateIndexes[9] - seperateIndexes[8] - 1)),
                    ShippingCost = double.Parse(allLines[lineIndex].Substring(seperateIndexes[9] + 1, seperateIndexes[10] - seperateIndexes[9] - 1)),
                    CustomerName = allLines[lineIndex].Substring(seperateIndexes[10] + 1, seperateIndexes[11] - seperateIndexes[10] - 1),
                    Province = allLines[lineIndex].Substring(seperateIndexes[11] + 1, seperateIndexes[12] - seperateIndexes[11] - 1),
                    Region = allLines[lineIndex].Substring(seperateIndexes[12] + 1, seperateIndexes[13] - seperateIndexes[12] - 1),
                    CustomerSegment = allLines[lineIndex].Substring(seperateIndexes[13] + 1, seperateIndexes[14] - seperateIndexes[13] - 1),
                    ProductCategory = allLines[lineIndex].Substring(seperateIndexes[14] + 1, seperateIndexes[15] - seperateIndexes[14] - 1),
                    ProductSubCategory = allLines[lineIndex].Substring(seperateIndexes[15] + 1, seperateIndexes[16] - seperateIndexes[15] - 1),
                    ProductName = allLines[lineIndex].Substring(seperateIndexes[16] + 1, seperateIndexes[17] - seperateIndexes[16] - 1),
                    ProductContainer = allLines[lineIndex].Substring(seperateIndexes[17] + 1, seperateIndexes[18] - seperateIndexes[17] - 1),
                    ProductBaseMargin = seperateIndexes[18] + 1 == seperateIndexes[19] ? 0d : double.Parse(allLines[lineIndex].Substring(seperateIndexes[18] + 1, seperateIndexes[19] - seperateIndexes[18] - 1)),
                    ShipDate = DateTime.Parse(allLines[lineIndex].Substring(seperateIndexes[19] + 1, allLines[lineIndex].Length - seperateIndexes[19] - 1))
                });

                //============ вывод всех параметров (откладка) ============
               /*Console.WriteLine($"RowID: {list[lineIndex - 1].RowID}\nOrderID: {list[lineIndex - 1].OrderID}" +
                    $"\nOrderDate: {list[lineIndex - 1].OrderDate}\nOrderPriority: {list[lineIndex - 1].OrderPriority}" +
                    $"\nOrderQuantity: {list[lineIndex - 1].OrderQuantity}\nSales: {list[lineIndex - 1].Sales}" +
                    $"\nDiscount: {list[lineIndex - 1].Discount}\nShipMode: {list[lineIndex - 1].ShipMode}" +
                    $"\nProfit: {list[lineIndex - 1].Profit}\nUnitPrice: {list[lineIndex - 1].UnitPrice}" +
                    $"\nShippingCost: {list[lineIndex - 1].ShippingCost}\nCustomerName: {list[lineIndex - 1].CustomerName}" +
                    $"\nProvince: {list[lineIndex - 1].Province}\nRegion: {list[lineIndex - 1].Region}" +
                    $"\nCustomerSegment: {list[lineIndex - 1].CustomerSegment}\nProductCategory: {list[lineIndex - 1].ProductCategory}" +
                    $"\nProductSubCategory: {list[lineIndex - 1].ProductSubCategory}\nProductName: {list[lineIndex - 1].ProductName}" +
                    $"\nProductContainer: {list[lineIndex - 1].ProductContainer}\nProductBaseMargin: {list[lineIndex - 1].ProductBaseMargin}" +
                    $"\nShipDate: {list[lineIndex - 1].ShipDate}");
                Console.WriteLine();*/

                seperateCount = 0; // обнуляем индекс массива для следующего поиска
            }

            //============ Сортировка по порядку: 1) По приоритету 2) По дате заказа 3) По дате прибытия ============
            list = new List<OrderInfo>(list.OrderBy(val => val.OrderPriority).ThenBy(val => val.OrderDate).ThenBy(val => val.ShipDate));

            //============ Вывод отсортированного списка ============
            foreach (var e in list)
            {
                Console.WriteLine($"RowID: {e.RowID}\nOrderID: {e.OrderID}" +
                     $"\nOrderDate: {e.OrderDate.ToString("dd/MM/yyyy")}\nOrderPriority: {e.OrderPriority}" +
                     $"\nOrderQuantity: {e.OrderQuantity}\nSales: {e.Sales}" +
                     $"\nDiscount: {e.Discount}\nShipMode: {e.ShipMode}" +
                     $"\nProfit: {e.Profit}\nUnitPrice: {e.UnitPrice}" +
                     $"\nShippingCost: {e.ShippingCost}\nCustomerName: {e.CustomerName}" +
                     $"\nProvince: {e.Province}\nRegion: {e.Region}" +
                     $"\nCustomerSegment: {e.CustomerSegment}\nProductCategory: {e.ProductCategory}" +
                     $"\nProductSubCategory: {e.ProductSubCategory}\nProductName: {e.ProductName}" +
                     $"\nProductContainer: {e.ProductContainer}\nProductBaseMargin: {e.ProductBaseMargin}" +
                     $"\nShipDate: {e.ShipDate.ToString("dd/MM/yyyy")}");
                Console.WriteLine();
            }
             
            //============ Удаление последнего элемента ============
            Console.WriteLine("\n\n\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Удалить последний элемент? + / -\n");
            while (Console.ReadLine().Equals("+") ? true : false)
            {
                list.RemoveAt(list.Count - 1);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Размер листа = {list.Count}\n");
            }
           
        }

        /// <summary>
        /// Класс, в котором хранятся все заголовки из csv файла (имена совпадают)
        /// </summary>
        class OrderInfo
        {
            public int RowID { get; set; }
            public int OrderID { get; set; }
            public DateTime OrderDate { get; set; }
            public string OrderPriority { get; set; }
            public int OrderQuantity { get; set; }
            public double Sales { get; set; }
            public double Discount { get; set; }
            public string ShipMode { get; set; }
            public double Profit { get; set; }
            public double UnitPrice { get; set; }
            public double ShippingCost { get; set; }
            public string CustomerName { get; set; }
            public string Province { get; set; }
            public string Region { get; set; }
            public string CustomerSegment { get; set; }
            public string ProductCategory { get; set; }
            public string ProductSubCategory { get; set; }
            public string ProductName { get; set; }
            public string ProductContainer { get; set; }
            public double ProductBaseMargin { get; set; }
            public DateTime ShipDate { get; set; }
        }
    }
}
