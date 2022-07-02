using System;

namespace Программа
{
    class Program
    {
        static void GetRazmer(ref int a, string text)
        {
            while (true)
            {
                try
                {
                    Console.Write($"Введите количество {text}: ");
                    a = Convert.ToInt32(Console.ReadLine());
                    if (a < 2)
                    {
                        Console.WriteLine($"{text} должно быть не менее двух! Повторите ввод");
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Введены некорректные данные!");
                }
            }
        }

        static void GetMatr(ref int[,] matr, int r, int c, string text)
        {
            int i = 0, j = 0;//переменные для циклов
            Console.WriteLine($"Ввод таблицы затрат на {text} продукции:");//ввод данных в таблицу затрат
            for (i = 0; i < matr.GetLength(0); i++)
            {
                for (j = 0; j < matr.GetLength(1); j++)
                {

                    while (true)
                    {
                        try
                        {
                            Console.Write($"Введите стоимость {text} от {i + 1} поставщика  к {j + 1} потребителю: ");
                            matr[i, j] = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Введены некорректные данные!");
                        }
                    }

                }
                Console.WriteLine();
            }

            Console.WriteLine($"Таблица затрат на {text} продукции:");//вывод таблицы затрат на экран
            for (i = 0; i < matr.GetLength(0); i++)
            {
                for (j = 0; j < matr.GetLength(1); j++)
                {
                    Console.Write(matr[i, j] + "\t");
                }
                Console.WriteLine();
            }
            char otv;//переменная для диалога с пользователем
            //Изменение матрицы
            while (true)
            {
                while (true)
                {
                    try
                    {
                        Console.Write("\nХотите изменить данные о таблице?\nДа(любая клавиша)/Нет(N)\nОтвет: ");
                        otv = Convert.ToChar(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Введены некорректные данные!");
                    }
                }
                if (otv.Equals('n') || otv.Equals('т') || otv.Equals('N') || otv.Equals('Т'))
                {
                    break;
                }
                else
                {
                    Console.Write("Введите номер поставщика, нажмите Enter, затем номер потребителя, который вы хотите изменить\nОтвет:\n");
                    while (true)
                    {
                        i = Convert.ToInt32(Console.ReadLine());
                        j = Convert.ToInt32(Console.ReadLine());
                        if (i < c + 1 && j < r + 1)
                        {
                            while (true)
                            {
                                try
                                {
                                    Console.Write("Введите новое значение: ");
                                    int temp = Convert.ToInt32(Console.ReadLine());
                                    if (temp != 0)
                                    {
                                        Console.WriteLine($" Была изменена {i} {j} ячейка таблицы c {matr[i - 1, j - 1]} на {temp}");
                                        matr[i - 1, j - 1] = temp;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Вы ввели нулевое значение! Повторите ввод");
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("Введены некорректные данные!");
                                }
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Введенная размерность не соответствует матрице! Повторите ввод");
                        }
                    }
                }
            }
        }
        static void vector(ref int[] m, int i, int j, string text)
        {
            Console.WriteLine($"Ввод данных о количестве продукции {text}:");//ввод данных в вектор мощности поставщиков
            for (i = 0; i < m.Length; i++)
            {
                while (true)
                {
                    try
                    {
                        Console.Write($"Введите количество продукции у {i + 1} {text}: ");
                        m[i] = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Введены некорректные данные!");
                    }
                }
            }
        }
        static void GetVectora(ref int[] m, ref int[] n)
        {
            int i = 0, j = 0;//переменные для циклов
            int valueM = 0, valueN = 0;
            while (true)
            {
                vector(ref m, i, j, "Поставщика");
                vector(ref n, i, j, "Потребителя");
                for (i = 0; i < m.Length; i++)
                {
                    valueM += m[i];
                }
                for (i = 0; i < n.Length; i++)
                {
                    valueN += n[i];
                }
                if (valueM == valueN)
                {
                    break;
                }
                else//проверка на равенство суммы элементов векторов
                {
                    Console.WriteLine("Вектор мощности (m) и cпроса (n) должны быть равны, повторите ввод!");
                    valueM = 0;
                    valueN = 0;
                }
            }
            Console.WriteLine("Вектор мощности (m):");//вывод на экран
            for (i = 0; i < m.Length; i++)
            {
                Console.Write($"{m[i]} ");
            }
            Console.WriteLine("\nВектор спроса (n):");//вывод на экран
            for (i = 0; i < n.Length; i++)
            {
                Console.Write($"{n[i]} ");
            }
        }
        static void GetSumma(ref int[,] c, int[,] a, int[,] b) // Мктод для для заполнения массива суммы
        {
            int i = 0, j = 0;//переменные для циклов
            for (i = 0; i < c.GetLength(0); i++)
            {
                for ( j = 0; j < c.GetLength(1); j++)
                {
                    c[i,j] = a[i,j] + b[i,j];
                }
            }
            Console.WriteLine($"Матрица суммы:");// вывод матрицы суммы
            for (i = 0; i < c.GetLength(0); i++)
            {
                for (j = 0; j < c.GetLength(1); j++)
                {
                    Console.Write(c[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static void GetNewMassive(ref string[,] d, int[] a, int[] b, int[,] c)
        {
            // Цикл для заполнения спросов в новом массиве
            for (int i = 0; i < b.Length; i++)
            {
                d[0, i+1] = Convert.ToString(b[i]);
            }
            // Цикл для заполнения мощностей поставщиков в новом массиве
            for (int j = 0; j < a.Length; j++)
            {
                d[j + 1, 0] = Convert.ToString(a[j]);
            }
            // Цикл для заполнения суммы массивов
            for (int i = 0; i < c.GetLength(0); i++)
            {
                for (int j = 0; j < c.GetLength(1); j++)
                {
                    d[i+1,j+1] = Convert.ToString(c[i,j]);
                }
            }
        }
        static int GetDistribution(ref string[,] a) //Выполнения распредления и подсчёта суммы
        {
            int summa = 0; // Переменная для хранения суммы
            for (int i = 1; i < a.GetLength(0); i++) // Цикл по строкам массива
            {
                for (int j = 1; j < a.GetLength(1); j++) // Цикл по столбцам массива
                {
                    if(Convert.ToInt32(a[0,j]) != 0) // Проверка, если в ячейке спрос равен 0, то идём дальше
                    {
                        if(Convert.ToInt32(a[i, 0]) != 0) // Проверка, если в ячейке предложение равно 0, то переходим на новую строчку
                        {
                            if (Convert.ToInt32(a[i,0]) > Convert.ToInt32(a[0,j])) // Проверка, если предложение больше спроса
                            {
                                summa = summa + Convert.ToInt32(a[i,j]) * Convert.ToInt32(a[0,j]); // К сумме прибавляем произведение цены с поставкой
                                a[i,j] = a[i,j] + " / " + a[0,j]; // В ячекй добавляем символ / и максимальную поставку
                                a[i, 0] = Convert.ToString(Convert.ToInt32(a[i, 0]) - Convert.ToInt32(a[0, j])); // Вычитаем из предложения сделанную поставку
                                a[0,j] = "0"; // Зануляем спрос, так как весь спрос удовлетворён
                            }
                            else if (Convert.ToInt32(a[i,0]) < Convert.ToInt32(a[0,j]))// Проверка, если предложение меньше спроса
                            {
                                summa = summa + (Convert.ToInt32(a[i,j]) * Convert.ToInt32(a[i,0])); // К сумме прибавляем произведение цены с поставкой
                                a[i,j] = a[i,j] + " / " + a[i,0]; // В ячекй добавляем символ / и максимальную поставку
                                a[0,j] = Convert.ToString(Convert.ToInt32(a[0,j]) - Convert.ToInt32(a[i,0])); // Вычитаем из спроса сделанную поставку
                                a[i,0] = "0"; // Зануляем предложение, так как у данного поставщика закончилась продукция
                                // Переходим на новую строку на тот же магазин
                                if(i != i - 1)
                                {
                                    i++;
                                    j--;
                                }
                            }
                            else
                            {
                                summa = summa + (Convert.ToInt32(a[i,j]) * Convert.ToInt32(a[i,0])); // К сумме прибавляем произведение цены с поставкой
                                a[i,j] = a[i, j] + " / " + a[i, 0]; // В ячекй добавляем символ / и максимальную поставку
                                a[i,0] = "0"; // Зануляем предложение, так как у данного поставщика закончилась продукция
                                a[0,j] = "0"; // Зануляем спрос, так как весь спрос удовлетворён
                                // Переходим на новую строку на тот же магазин
                                if (i != i - 1)
                                {
                                    i++;
                                    j--;
                                }
                            }
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
            }
            return summa;
        }
        static void ShowRurult(string [,] d) // метод для вывода результата
        {
            int p = 1; // Переменная хранящая номер записи
            // Циклы для прохождения по массиву распределения
            for (int i = 0; i < d.GetLength(0); i++)
            {
                for (int j = 0; j < d.GetLength(1); j++)
                {
                    if (i == 0 && j == 0)
                    {
                        j++;
                    }
                    string str = d[i,j]; // Переменная для хранения содержимого ячейки
                    int k = 0; // Количесво символов / в ячейке
                    int index = 0; // Переменная, которая хранит индекс символа /
                    for (int e = 0; e < str.Length; e++)
                    {
                        if (str[e] == '/')
                        {
                            k++;
                            index = e;
                        }
                    }
                    if (k != 0) // Если в ячейке есть символ /
                    {
                        // Вывод записи кому и с кем нужно заключить договор
                        Console.WriteLine(p + ") " + i + " поставщику требуется заключить договор с " + j + " магазином на поставку " + str.Substring(index + 1) + " единиц продукции\n");
                        p++;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Нахождение первоначального распределения транспортной задачи по метод северо-заподного угла");
                int r = 0, c = 0;//размерности матрицы и векторов
                GetRazmer(ref r, "Потребителей"); //ввод потребителей(размерности по столбцам)
                GetRazmer(ref c, "Поставщиков"); //ввод поставщиков(размерности по стокам)
                int[,] matrxA = new int[r, c];//матрица затрат перевозку единицы процукции
                int[,] matrxB = new int[r, c];//матрица затрат на хранение единицы процукции
                Console.Clear();
                GetMatr(ref matrxA, r, c, "Перевозки");
                Console.Clear();
                GetMatr(ref matrxB, r, c, "Хранения");
                Console.Clear();
                int[] m = new int[r];//вектор мощности поставщиков
                int[] n = new int[c];//вектор спроса потребителей
                GetVectora(ref m, ref n);
                Console.Clear();
                int[,] matrxC = new int[r, c];//матрица суммы матриц затрат на хранение и перевозку единицы продукции
                GetSumma(ref matrxC, matrxA, matrxB);
                string[,] matrxD = new string[r+1, c+1];//матрица для распределения с дополнительной строкой и столбцом для спроса и предложения
                GetNewMassive(ref matrxD, m, n, matrxC); // Формирование новой матрицы
                double summa; // Переменная для хранения значения целевой функции
                summa = GetDistribution(ref matrxD);
                Console.Clear();
                Console.WriteLine($"Матрица суммы:");// вывод матрицы с рапределёнными поставками
                for (int i = 0; i < matrxD.GetLength(0); i++)
                {
                    for (int j = 0; j < matrxD.GetLength(1); j++)
                    {
                        Console.Write(matrxD[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("\nОбщие затраты денег: " + summa + " у. д. е.");
                Console.ReadKey();
                Console.Clear();
                ShowRurult(matrxD);
                char otv; // Переменная для диалога с пользователем
                while (true)
                {
                    try
                    {
                        Console.Write("\nПовторить программу?\nДа(Y)/Нет(N)\nОтвет: ");
                        otv = Convert.ToChar(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Введены некорректные данные!");
                    }
                }
                if (!(otv.Equals('Y') || otv.Equals('y') || otv.Equals('н') || otv.Equals('Н')))
                {
                    break;
                }
                else if (!(otv.Equals('N') || otv.Equals('N') || otv.Equals('Т') || otv.Equals('т')))
                {
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                }
            }
        }
    }
}