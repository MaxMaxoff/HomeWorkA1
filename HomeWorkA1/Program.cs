using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// Библиотека для упрощения работы с консолью.
// https://github.com/MaxMaxoff/SupportLibrary
using SupportLibrary;

/// <summary>
/// Максим Торопов
/// Ярославль
/// https://github.com/MaxMaxoff
/// Домашняя работа "Алгоритмы и структуры данных"
/// 1 урок
/// </summary>
namespace HomeWork1
{
    class Program
    {
        /// <summary>
        /// 14. * Автоморфные числа. 
        /// Натуральное число называется автоморфным, если оно равно последним цифрам своего квадрата.
        /// Например, 25 ^ 2 = 625.
        /// Напишите программу, которая вводит натуральное число N и выводит на экран все автоморфные числа, не превосходящие N.
        /// </summary>
        static void Task1()
        {
            SupportMethods.PrepareConsoleForHomeTask("14. * Автоморфные числа.\n" +
                "Натуральное число называется автоморфным, если оно равно последним цифрам своего квадрата.\n" +
                "Например, 25 ^ 2 = 625.\n" +
                "Напишите программу, которая вводит натуральное число N и выводит на экран все автоморфные числа, не превосходящие N.\n");

            int nn = SupportMethods.RequestIntValue("Plase type N:");

            // конвертирование Int в UInt            
            if (nn < 0) nn *= -1;
            uint n = Convert.ToUInt32(nn);

            // порядок
            ulong d = 1;

            // Перебираем все числа от 0 до n
            for (ulong i = 0; i <= n; i++)
            {
                // вычисления производим только с числами > 1
                if (i > 1)
                {
                    // все автоморфные сичла оканчиваются на 5 или 6, с ростом порядка, соответственно, на 25, 76 и т.д.,
                    // данное условие учитывает окончание только 5 или 6.
                    // На усложнение условий отбора, а в результате - ускорение вычисений, не хватило времени.
                    if (i % 10 == 5 || i % 10 == 6)
                    {
                        // если остаток от деления квадрата числа на порядок равен числу - число автоморфно
                        if ((i * i) % d == i)
                        {
                            Console.WriteLine($"Number: {i} is automorphic; square {i * i}");
                        }
                        // проверяем то же самое, но с большим порядком, в случае успеха увеличиваем порядок
                        else if ((i * i) % (d * 10) == i)
                        {
                            Console.WriteLine($"Number: {i} is automorphic; square {i * i}");
                            d *= 10;
                        }
                    }
                }
                // 0 и 1 по определению являются автоморфными числами
                else if (i == 0 || i == 1)
                {
                    Console.WriteLine($"Number: {i} is automorphic; square {i * i}");
                }

            }
            SupportMethods.Pause("All automorphic numbers here.\nPress any key to continue...");
        }

        /// <summary>
        /// 13. * Написать функцию, генерирующую случайное число от 1 до 100.
        /// a) с использованием стандартной функции rand()
        /// b) без использования стандартной функции rand()
        /// </summary>
        static void Task2()
        {
            int lenght = 10000000;
            int ms = 0;

            SupportMethods.PrepareConsoleForHomeTask("13. * Написать функцию, генерирующую случайное число от 1 до 100.\n" +
                "a) с использованием стандартной функции rand()\n");
            SupportMethods.Pause($"Random value using standard random function: {getRandom(1, 100)}\nPress any key to continue...");

            SupportMethods.PrepareConsoleForHomeTask("13. * Написать функцию, генерирующую случайное число от 1 до 100.\n" +
                "b) без использования стандартной функции rand()\n");
            int rndValue = getRandomPrivateFunc(1, 100, DateTime.Now.Millisecond, ref ms);
            SupportMethods.Pause($"Random value using private random function: {rndValue}\nPress any key to continue...");

            // uncomment to check Randomizer
            // checkRandom(lenght);
            // SupportMethods.Pause();
        }

        /// <summary>
        /// method getRandom
        /// </summary>
        /// <param name="min">from</param>
        /// <param name="max">up to</param>
        /// <returns>random value from min up to max</returns>
        static int getRandom(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        /// <summary>
        /// method getRandomPrivateFunc
        /// </summary>
        /// <param name="min">from</param>
        /// <param name="max">up to</param>
        /// <returns>random value from min up to max</returns>
        static int getRandomPrivateFunc(int min, int max, int prev, ref int ms)
        {
            int rndFor = DateTime.Now.Millisecond + ms;
            // Thread.Sleep(rndFor / 10);
            ms = rndFor;
            if (ms > 1000) ms %= 1000;
            int random = ((DateTime.Now.Millisecond + rndFor) * rndFor + prev) % max + min - 1;
            if (random < 0) random *= -1;
            return random;
        }

        /// <summary>
        /// Method frequency array for check randomizer
        /// </summary>
        /// <param name="length"></param>
        static void checkRandom(int length)
        {
            int[] arr = new int[100];
            int rndValue = 0;
            int ms = 0;

            // fill frequency array
            for (int i = 0; i <= length; i++)
            {
                rndValue = getRandomPrivateFunc(1, 100, rndValue, ref ms);
                // rndValue = getRandom(1, 100);

                // uncomment to see values;
                // Console.Write($"{rndValue:00} ");
                arr[rndValue]++;
            }
            Console.WriteLine();

            // print out frequency array
            for (int i = 0; i < 100; i++)
                Console.WriteLine($"[{i + 1:000}]: {arr[i] / Convert.ToDouble(length) * 100:00.00}%");
            //Console.WriteLine($"[{i + 1}]: {arr[i]}");
        }

        /// <summary>
        /// 12. Написать функцию нахождения максимального из трех чисел.
        /// </summary>
        static void Task3()
        {
            SupportMethods.PrepareConsoleForHomeTask("12. Написать функцию нахождения максимального из трех чисел.\n");

            int a = SupportMethods.RequestIntValue("Please type a: ");
            int b = SupportMethods.RequestIntValue("Please type b: ");
            int c = SupportMethods.RequestIntValue("Please type c: ");

            int max = a;

            if (b > max)
            {
                max = b;
            }

            if (c > max)
            {
                max = c;
            }

            SupportMethods.Pause($"Max between {a}, {b} & {c} is {max}");
        }

        /// <summary>
        /// 11. С клавиатуры вводятся числа, пока не будет введен 0.
        /// Подсчитать среднее арифметическое всех положительных четных чисел, оканчивающихся на 8.
        /// </summary>
        static void Task4()
        {
            int number = 0;
            int sum = 0;

            SupportMethods.PrepareConsoleForHomeTask("11. С клавиатуры вводятся числа, пока не будет введен 0.\n" +
                "Подсчитать среднее арифметическое всех положительных четных чисел, оканчивающихся на 8.\n");
            do
            {
                number = SupportMethods.RequestIntValue("Please type number, (0 - exit): ");
                if (number % 2 == 0 && number > 0 && number % 10 == 8) sum += number;
            } while (number != 0);

            SupportMethods.Pause($"Sum of positive EVEN numbers ends by 8 equal {sum}");

        }

        /// <summary>
        /// 10. Дано целое число N (> 0).
        /// С помощью операций деления нацело и взятия остатка от деления определить, имеются ли в записи числа N нечетные цифры.
        /// Если имеются, то вывести True, если нет — вывести False.
        /// </summary>
        static void Task5()
        {
            SupportMethods.PrepareConsoleForHomeTask("10. Дано целое число N (> 0).\n" +
                "С помощью операций деления нацело и взятия остатка от деления определить, имеются ли в записи числа N нечетные цифры.\n" +
                "Если имеются, то вывести True, если нет — вывести False.\n");

            int number = SupportMethods.RequestIntValue("Please type number: ");
            bool odd = false;

            if (number < 0) number *= -1;

            while (number > 0)
            {
                if (number % 10 % 2 == 1)
                {
                    odd = true;
                    break;
                }
                else number /= 10;
            }

            SupportMethods.Pause($"{odd}");
        }

        /// <summary>
        /// 9. Даны целые положительные числа N и K.
        /// Используя только операции сложения и вычитания, найти частное от деления нацело N на K, а также остаток от этого деления.
        /// </summary>
        static void Task6()
        {
            SupportMethods.PrepareConsoleForHomeTask("9. Даны целые положительные числа N и K.\n" +
                "Используя только операции сложения и вычитания, найти частное от деления нацело N на K, а также остаток от этого деления.\n");

            int n = SupportMethods.RequestIntValue("Please type positive N: ");
            int k = SupportMethods.RequestIntValue("Please type positive K: ");

            int quotient = 0;
            int reminder = 0;

            while (n - k >= 0)
            {
                n -= k;
                quotient++;
            }
            reminder = n;

            SupportMethods.Pause($"Quotient is: {quotient} and Reminder is: {reminder}");
        }

        static void Main(string[] args)
        {
            do
            {
                SupportMethods.PrepareConsoleForHomeTask("1 - Task 14\n" +
                  "2 - Task 13\n" +
                  "3 - Task 12\n" +
                  "4 - Task 11\n" +
                  "5 - Task 10\n" +
                  "6 - Task 9\n" +
                  "0 (Esc) - Exit\n");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        Task1();
                        break;
                    case ConsoleKey.D2:
                        Task2();
                        break;
                    case ConsoleKey.D3:
                        Task3();
                        break;
                    case ConsoleKey.D4:
                        Task4();
                        break;
                    case ConsoleKey.D5:
                        Task5();
                        break;
                    case ConsoleKey.D6:
                        Task6();
                        break;
                    case ConsoleKey.D0:
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }
            } while (true);
        }
    }
}

