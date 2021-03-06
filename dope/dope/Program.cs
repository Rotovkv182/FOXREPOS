﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dope
{
    class Program
    {
        /* По каналу связи передаётся последовательность положительных целых чисел. Все числа не превышают 1000, 
их количество известно, но может быть очень велико. 
Затем передаётся контрольное значение — наибольшее число R, удовлетворяющее следующим условиям:
1) R — произведение двух различных переданных элементов последовательности 
2) R не делится на 10.
В результате помех при передаче как сами числа, так и контрольное значение могут быть искажены.
Напишите программу которая будет проверять правильность контрольного значения. 
Программа должна напечатать отчёт по следующей форме:
Получено чисел: …
Принятое контрольное значение: …
Вычисленное контрольное значение: …
Контроль пройден (или Контроль не пройден)
Если удовлетворяющее условию контрольное значение определить невозможно, вычисленное контрольное значение не выводится,
но выводится фраза «Контроль не пройден».
         */
        public static void log(string message) //метод для логгирования
        {
           try
           { File.AppendAllText("E:\\fox.log", message); /*класс и метод для записи в файл*/ }
           catch (FileNotFoundException)
           { Console.WriteLine("File not found!"); }
        }
        static void Main(string[] args)
        {
            try
            {
                log("\n" + DateTime.Now + "\n");
                Console.Write("Количество Чисел: ");
                int N = Convert.ToInt32(Console.ReadLine()); /*количество чисел на входе*/
                log("Введено кол-во чисел: " + N + '\n');
                int x; /*исходные данные*/
                int a2 = 0, b2 = 0; /*макс. числа, кратные 2, но не кратные 5*/
                int a5 = 0, b5 = 0; /*макс. числа, кратные 5, но не кратные 2*/
                int a0 = 0, b0 = 0; /*максимальные числа, не кратные 5 и 2*/
                int R; /*введенное контрольное значение*/
                int m; /*вычисленное контрольное значение*/
                for (int i = 1; i <= N; ++i)
                {
                    Console.Write("Исходные Данные: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    log("Введено значение для: Исходные Данные " + x + '\n');
                    if (x % 10 == 0) continue; /*ничего не делать*/
                    if (x % 2 == 0)
                    {
                        if (x > a2) { b2 = a2; a2 = x; }
                        else if (x > b2) b2 = x;
                    }
                    else if (x % 5 == 0)
                    {
                        if (x > a5) { b5 = a5; a5 = x; }
                        else if (x > b5) b5 = x;
                    }
                    else
                    {
                        if (x > a0) { b0 = a0; a0 = x; }
                        else if (x > b0) b0 = x;
                    }
                }
                Console.Write("Введите Контрольное Значение(R): ");
                R = Convert.ToInt32(Console.ReadLine());
                log("Введенно значение для: Контрольное Значение(R): " + R + '\n');
                m = a0 * a2;
                if (a0 * a5 > m) m = a0 * a5;
                if (a0 * b0 > m) m = a0 * b0;
                if (a2 * b2 > m) m = a2 * b2;
                if (a5 * b5 > m) m = a5 * b5;
                Console.WriteLine("     Получено Чисел: " + N);
                log("Вывод: Получено Чисел: " + N + '\n');
                Console.WriteLine("     Принятое Контрольное Значение(R): " + R);
                log("Вывод: Принятое Контрольное Значение(R): " + R + '\n');
                if (m > 0) Console.WriteLine("     Вычисленное Контрольное Значение: " + m);
                log("Выполнен расчет: Вычисленное Контрольное Значение - " + m + '\n');
                log("Сравнение результатов: Принятое Контрольное Значение и Вычисленное Контрольное Значение." + '\n');
                if (R > 0 && R == m)
                {
                    Console.WriteLine("     Контрольное Значение Соответствует Введеному.");
                    log("Вывод: Вывод в консоль соответствия" + '\n');
                }
                else
                {
                    Console.WriteLine("     Контрольное Значение НЕ Соответствует.");
                    log("Вывод: Вывод в консоль НЕ соответствия" + '\n');
                }
            }
            catch(Exception)
            { Console.WriteLine("Error!"); }
        }
    }
}
