using System;
using System.Diagnostics;

namespace Asd1
{
    public class Lab1
    {
        public static void Main()
        {
            Menu();
        }
        public static void Menu()
        {
            char exi; //змінна для виходу з програми
            char command; //змінна для вибору завдання

            do
            {
                Console.WriteLine("\n=============== menu ==================");
                Console.WriteLine("1. create an array.");
                Console.WriteLine("2. linear search.");
                Console.WriteLine("3. barrier search.");
                Console.WriteLine("4. binary search.");
                Console.WriteLine("5. golden ratio search.");
                Console.WriteLine("0. stop the program.");
                Console.WriteLine("==========================================");
                do
                {

                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("select command to execute.");
                    while (!Char.TryParse(Console.ReadLine(), out command)) //перевірка на правильність вводу
                    {
                        Console.WriteLine("wrong command, try again: ");
                    }

                    switch (command) //меню
                    {
                        case '1': //перший пункт
                            {
                                CreatingArray();
                                OutputArray(arr);
                                break;
                            }
                        case '2': //другий пункт
                            {
                                Task1();
                                break;
                            }
                        case '3': //третій пункт 
                            {
                                Task2();
                                break;
                            }
                        case '4': //четвертий пункт
                            {
                                Task3();
                                break;
                            }
                        case '5': //п'ятий пункт
                            {
                                Task4();
                                break;
                            }
                        case '0': //вихід з меню
                            break;
                        default: //за замовченням
                            Console.WriteLine("wrong command, try again.");
                            break;
                    }
                } while (command != 48); //код клавіші 0
                Console.WriteLine("press any key to restart or 0 to stop"); //виведення повідомлень на екран
                exi = Convert.ToChar(Console.ReadLine());
            } while (exi != '0'); //умова за якої продовжується цикл; 27 - код клавіши esc
        }

        // ====================== глобальні змінні =======================
        public static int key;
        public static int[] arr = new int[0];
        public static LinkedList linklist = new LinkedList();
        public static Stopwatch stopWatch = new Stopwatch();
        // ====================== допоміжні функції =======================
        public static void CreatingArray()
        {
            ushort size;
            Console.Write("enter array size: ");
            while (!UInt16.TryParse(Console.ReadLine(), out size)) //перевірка на правильність вводу
            {
                Console.Write("wrong! enter array size: ");
            }
            Array.Resize(ref arr, size);

            Random arrRand = new Random();
            for (int i = 0; i < size; i++)
            {
                arr[i] = arrRand.Next(-500, 500);
            }
            Console.WriteLine("array created!");
            linklist.GetList(linklist, arr);
        }
        public static void OutputArray(int[] array)
        {
            Console.Write("array:    ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "\t");
            }
            Console.WriteLine();
        }

        // ========================== завдання 1 ==========================
        public static void Task1()
        {
            Console.Write("enter value of element to search: ");
            while (!Int32.TryParse(Console.ReadLine(), out key)) //перевірка на правильність вводу
            {
                Console.Write("wrong! enter value of element to search: ");
            }
            LinearSearchArray(key);
            Console.WriteLine();
            LinearSearchList(key);
        }
        public static void LinearSearchArray(int key)
        {
            stopWatch.Start();
            bool flag = false;
            int index = 0;
            while ((index < arr.Length) && !flag)
            {
                if (arr[index] == key)
                {
                    flag = true;
                    Console.WriteLine("element " + key + " index is " + index);
                }
                index++;
            }
            if (!flag)
                Console.WriteLine("element wasn't found.");
            stopWatch.Stop();
            Console.WriteLine($"elapsed time (array): {stopWatch.Elapsed.TotalMilliseconds * 1000000} ns.");
            stopWatch.Reset();
        }
        public static void LinearSearchList(int key)
        {
            int index = 0;
            bool flag = false;
            Node iterator = linklist.head;

            stopWatch.Start();
            while ((iterator != null) && !flag)
            {
                if (iterator.value == key)
                {
                    flag = true;
                    Console.WriteLine("element " + key + " index is " + --index);
                }
                index++;
                iterator = iterator.next;
            }

            if (!flag)
                Console.WriteLine("element wasn't found.");
            stopWatch.Stop();
            Console.WriteLine($"elapsed time (list): {stopWatch.Elapsed.TotalMilliseconds*1000000} ns.");
            stopWatch.Reset();
        }

        // ========================== завдання 2 ==========================
        public static void Task2()
        {
            Console.Write("enter value of element to search: ");
            while (!Int32.TryParse(Console.ReadLine(), out key)) //перевірка на правильність вводу
            {
                Console.Write("wrong! enter value of element to search: ");
            }
            BarrierSearchArray(key);
            Console.WriteLine();
            BarrierSearchList(key);
        }
        public static void BarrierSearchArray(int key)
        {
            int index = 0;
            bool flag = false;
            int[] arrCopy = new int[arr.Length + 1];
            Array.Copy(arr, arrCopy, arr.Length);
            arrCopy[arrCopy.Length - 1] = key;

            stopWatch.Start();
            while (!flag)
            {
                if (arrCopy[index] == key)
                    flag = true;
                index++;
            }
            if (index == arrCopy.Length)
                Console.WriteLine("element wasn't found.");
            else
                Console.WriteLine("element " + key + " index is " + --index);
            stopWatch.Stop();
            Console.WriteLine($"elapsed time (array): {stopWatch.Elapsed.TotalMilliseconds * 1000000} ns.");
            stopWatch.Reset();
        }
        public static void BarrierSearchList(int key)
        {
            int index = -1;
            bool flag = false;
            Node iterator = linklist.head;
            linklist.AddLast(key);

            stopWatch.Start();
            while (!flag)
            {
                if (iterator.value == key)
                    flag = true;
                index++;
                iterator = iterator.next;
            }

            if (index == linklist.ListLength(linklist))
                Console.WriteLine("element wasn't found.");
            else
                Console.WriteLine("element " + key + " index is " + --index);
            linklist.head = LinkedList.RemoveLast(linklist.head);
            stopWatch.Stop();
            Console.WriteLine($"elapsed time (list): {stopWatch.Elapsed.TotalMilliseconds * 1000000} ns.");
            stopWatch.Reset();
        }

        // ========================== завдання 3 ==========================
        public static void Task3()
        {
            Console.Write("enter value of element to search: ");
            while (!Int32.TryParse(Console.ReadLine(), out key)) //перевірка на правильність вводу
            {
                Console.Write("wrong! enter value of element to search: ");
            }
            BinarySearchArray(key);
            Console.WriteLine();
            BinarySearchList(key);
        }
        public static void BinarySearchArray(int key)
        {
            int left = 0, right = (arr.Length - 1), mid = 0;
            bool flag = false;
            int[] arrSorted = arr;
            Array.Sort(arrSorted);
            Console.WriteLine("array sorted!");
            OutputArray(arrSorted);

            stopWatch.Start();
            while (!flag && left < (right - 1))
            {
                mid = (left + right) / 2;
                if (arrSorted[mid] == key)
                    flag = true;
                else if (key > arrSorted[mid])
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            if (flag)
                Console.WriteLine("element " + key + " index is " + mid);
            else
                Console.WriteLine("element wasn't found.");
            stopWatch.Stop();
            Console.WriteLine($"elapsed time (array): {stopWatch.Elapsed.TotalMilliseconds * 1000000} ns.");
            stopWatch.Reset();
        }
        public static void BinarySearchList(int key)
        {
            LinkedList listSorted = new LinkedList();
            listSorted = LinkedList.Sort(arr);
            listSorted.OutputList();

            Node iterator = listSorted.head;
            int index = -1, left = 0, right = (listSorted.ListLength(listSorted) - 1);
            int mid = (left + right) / 2;
            bool flag = false;

            stopWatch.Start();

            while (iterator != null && !flag)
            {
                if (index == mid)
                {
                    if (key == iterator.value)
                        flag = true;
                    else if (key > iterator.value)
                    {
                        left = mid + 1;
                        index++;
                        iterator = iterator.next;
                    }
                    else
                    {
                        right = mid - 1;
                        index = -1;
                        iterator = listSorted.head;
                    }
                    mid = (left + right) / 2;
                }
                else
                {
                    index++;
                    iterator = iterator.next;
                }
            }

            if (flag)
                Console.WriteLine("element " + key + " index is " + index);
            else
                Console.WriteLine("element wasn't found.");
            stopWatch.Stop();
            Console.WriteLine($"elapsed time (list): {stopWatch.Elapsed.TotalMilliseconds * 1000000} ns.");
            stopWatch.Reset();

        }

        // ========================== завдання 4 ==========================
        public static void Task4()
        {
            Console.Write("enter value of element to search: ");
            while (!Int32.TryParse(Console.ReadLine(), out key)) //перевірка на правильність вводу
            {
                Console.Write("wrong! enter value of element to search: ");
            }

            GoldenRatioSearchArray(key);
            Console.WriteLine();
            GoldenRatioSearchList(key);
        }
        public static void GoldenRatioSearchArray(int key)
        {
            // GoldenRatio = (1 + Math.Sqrt(5)) / 2;
            const double GoldenRatio = 1.61803398874989484820458683436; // golden number

            int left = 0, right = (arr.Length - 1), mid = 0;
            bool flag = false;
            int[] arrSorted = arr;
            Array.Sort(arrSorted);
            Console.WriteLine("array sorted!");
            OutputArray(arrSorted);

            stopWatch.Start();
            while (!flag && left < (right - 1))
            {
                mid = (int)((left + right) / GoldenRatio);
                if (arrSorted[mid] == key)
                    flag = true;
                else if (key > arrSorted[mid])
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            if (flag)
                Console.WriteLine("element " + key + " index is " + mid);
            else
                Console.WriteLine("element wasn't found.");
            stopWatch.Stop();
            Console.WriteLine($"elapsed time (array): {stopWatch.Elapsed.TotalMilliseconds * 1000000} ns.");
            stopWatch.Reset();
        }
        public static void GoldenRatioSearchList(int key)
        {
            const double GoldenRatio = 1.61803398874989484820458683436; // golden number
            LinkedList listSorted = new LinkedList();
            listSorted = LinkedList.Sort(arr);
            listSorted.OutputList();

            Node iterator = listSorted.head;
            int index = -1, left = 0, right = (listSorted.ListLength(listSorted) - 1);
            int mid = (int)((left + right) / GoldenRatio);
            bool flag = false;

            stopWatch.Start();
            while (iterator != null && !flag)
            {
                if (index == mid)
                {
                    if (key == iterator.value)
                        flag = true;
                    else if (key > iterator.value)
                    {
                        left = mid + 1;
                        index++;
                        iterator = iterator.next;
                    }
                    else
                    {
                        right = mid - 1;
                        index = -1;
                        iterator = listSorted.head;
                    }
                    mid = (int)((left + right) / GoldenRatio);
                }
                else
                {
                    index++;
                    iterator = iterator.next;
                }
            }

            if (flag)
                Console.WriteLine("element " + key + " index is " + index);
            else
                Console.WriteLine("element wasn't found.");
            stopWatch.Stop();
            Console.WriteLine($"elapsed time (list): {stopWatch.Elapsed.TotalMilliseconds * 1000000} ns.");
            stopWatch.Reset();

        }
    }
}