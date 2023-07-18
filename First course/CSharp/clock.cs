/*using System;
using System.Linq;

namespace CSharp_1kurs
{

    class clock
    {
        /// <summary>
        /// угол между часовой и минутной
        /// </summary>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        static double angleHM(double hour, double minute)
        {
            double hourAngle = (hour % 12) * 30 + minute / 2;
            double minuteAngle = minute * 6.5; // при * 6 код ломается и не выдаёт нужный результат
            double difference = Math.Abs(hourAngle - minuteAngle); // модуль угла между часовой и минутной стрелкой
            return (Math.Min(difference, 360 - difference)); // возращает угол <= 180
            // учёт движения часовой и минутной стрелки - погрешность. Если и не считать это за погрешность,
            // то можно заменить в 10 строчке "minute * 6.5" на "minute * 6"
        }

        /// <summary>
        /// угол между часовой и секундной
        /// </summary>
        /// <param name="hour"></param>
        /// <param name="sec"></param>
        /// <returns></returns>
        static double angleHS(double hour, double sec)
        {
            double hourAngle = (hour % 12) * 30 + sec / 2;
            double secAngle = sec * 6.5;
            double difference = Math.Abs(hourAngle - secAngle);
            return (Math.Min(difference, 360 - difference));
        }

        static double angleMS(double sec, double minute)
        {
            double secAngle = sec * 6.5;
            double minuteAngle = (minute % 60) * 6 + sec / 2;
            double difference = Math.Abs(secAngle - minuteAngle);
            return (Math.Min(difference, 360 - difference));
        }

        public static void error_digit()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка! Вводить значение строго в положительном цифровом виде!");
            Console.WriteLine("Перезапустите программу.");
            Console.ResetColor();
        }

        public static void error_time()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка! Введены неверные данные! \nДолжно быть: Часы [0-24], Минуты [0-60], Секунды [0-60]");
            Console.WriteLine("Перезапустите программу.");
            Console.ResetColor();
        }

        public static void zadachi()
        {
            Console.WriteLine("Выберите задачу:");
            Console.WriteLine("1) Найти угол между часовой и минутной стрелкой;\n2) Найти угол между часовой и секундной стрелкой;");
            Console.WriteLine("3) Найти угол между минутной и секундной стрелкой;");
        }

        /// <summary>
        /// Получение времени системы и вывод всех углов
        /// </summary>
        public static void parse_time_auto()
        {
            double hauto, mauto, sauto;
            string[] s_arrauto = DateTime.Now.ToString("HH:mm:ss").Split(':');
            hauto = double.Parse(s_arrauto[0]);
            mauto = double.Parse(s_arrauto[1]);
            sauto = double.Parse(s_arrauto[2]);
            Console.WriteLine("Угол между часовой и минутной: {0}", angleHM(hauto, mauto));
            Console.WriteLine("Угол между часовой и секундной: {0}", angleHS(hauto, sauto));
            Console.WriteLine("Угол между минутной и секундной: {0}", angleMS(sauto, mauto));
            Console.WriteLine("Введено время: {0}:{1}:{2}", hauto, mauto, sauto);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Выберите тип задачи: \n1) Вычислить углы введённой даты; 2) Вычислить углы системной даты");
            int vibor = Convert.ToInt32(Console.ReadLine());
            if (vibor == 1)
            {
                zadachi();
                int choose = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите дату (чч:мм:сс)");
                double hour = 0, minute = 0, secs = 0;
                string s = Console.ReadLine();
                string[] s_arr = s.Split(':');
                bool digitsOnly1 = s_arr[0].All(char.IsDigit);
                bool digitsOnly2 = s_arr[1].All(char.IsDigit);
                bool digitsOnly3 = s_arr[2].All(char.IsDigit);
                if (digitsOnly1 && digitsOnly2 && digitsOnly3) // проверка на то, что это положительная цифра
                {
                    hour = double.Parse(s_arr[0]);
                    minute = double.Parse(s_arr[1]);
                    secs = double.Parse(s_arr[2]);
                    if (hour < 24 && minute < 60 && secs < 60) // проверка на выход из рамок
                    {
                        switch (choose)
                        {
                            case 1: // hour/min
                                Console.WriteLine("Выбрана 1 задача \n");
                                Console.WriteLine("Угол между часовой и минутной: {0}", angleHM(hour, minute));
                                Console.WriteLine("Введено время: {0}:{1}:{2}", hour, minute, secs);
                                break;
                            case 2: // hour/sec
                                Console.WriteLine("Выбрана 2 задача \n");
                                Console.WriteLine("Угол между часовой и секундной: {0}", angleHS(hour, secs));
                                Console.WriteLine("Введено время: {0}:{1}:{2}", hour, minute, secs);
                                break;
                            case 3: // min/sec
                                Console.WriteLine("Выбрана 3 задача \n");
                                Console.WriteLine("Угол между минутной и секундной: {0}", angleMS(secs, minute));
                                Console.WriteLine("Введено время: {0}:{1}:{2}", hour, minute, secs);
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка. Вы должны выбирать числа от 1 до 3!");
                                break;
                        }
                    }
                    else
                        error_time();
                }
                else
                    error_digit();
            }
            else if (vibor == 2)
                parse_time_auto();
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка! Нужно выбрать либо 1, либо 2!");
                Console.WriteLine("Перезапустите программу.");
                Console.ResetColor();
            }
        }
    }
}
*/