using System;
using System.Collections.Generic;
using System.Linq;

namespace SofTec
{
    /// <summary>
    /// Задача №3.
    /// <para>Условие:</para>
    /// <para>
    /// Шины, установленные на одном и той же автомобиле,
    /// могут изнашиваться с различной скоростью в зависимости от позиции шин.
    /// Например, шины на ведущих колесах обычно изнашиваются быстрее,
    /// чем шины на ведомых колесах. Эту проблему обычно решают,
    /// переставляя шины время от времени.
    /// </para>
    /// <para>
    /// Допустим, что автомобиль имеет N колес и имеется M новых шин(шины одинаковые).
    /// Кроме того, для каждого колеса известна скорость износа шины на этом колесе. 
    /// Напишите программу, которая определяет сколько максимально может проехать автомобиль,
    /// если перестановку шин производить оптимально.Вы можете предполагать,
    /// что шины изнашиваются равномерно и автомобиль движется прямолинейно.
    /// </para>
    /// </summary>
    public class Task3
    {
        //A, B, N — натуральные числа, т.е. > 0 и не дробные
        //1 < A
        //B < 10
        //10 < N < 100

        /// <summary>
        /// Меньшее число("Младшее" число)
        /// </summary>
        private static int lowerNumber;
        /// <summary>
        /// Большее число("Старшее" число) 
        /// </summary>
        private static int highterNumber;

        /// <summary>
        /// Список числовых последовательностей
        /// </summary>
        private static List<List<int>> collectionOfCombinations;

        /// <summary>
        /// Метод запуска задачи №3.
        /// <para>
        /// Принимает A, B и N, введённые в консоль через пробел.
        /// </para>
        /// </summary>
        /// <returns>
        /// Выводит на экран число, являющееся наибольшим произведением чисел из всех числовых последовательностей
        /// </returns>
        public static void Run()
        {
            Console.Title = "Task №3";
            while (true)
            {
                try
                {
                    string[] input = Console.ReadLine().Split();

                    if (input.Length == 3)
                    {
                        int A = int.Parse(input[0]);
                        int B = int.Parse(input[1]);
                        int N = int.Parse(input[2]);

                        if (A > 1 && B < 10 && B >= 0 && N > 10 && N < 100)
                        {
                            lowerNumber = A >= B ? B : A;
                            highterNumber = A == lowerNumber ? B : A;

                            collectionOfCombinations = new List<List<int>>();
                            Console.WriteLine("\n" + findChislPosledMultiplyResult(N));
                            return;
                        }
                    }
                    Console.WriteLine("Invalid Input");
                }
                catch
                {
                    Console.WriteLine("Invalid Input");
                }
                finally
                {
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        //Операции с числовой последовательностью (последовательность чисел A и B, которая равна N)
        /// <summary>
        /// Удаляет первое число в последовательности 
        /// </summary>
        /// <param name="collection">Текущая числовая последовательность в виде списка</param>
        private static void deleteFirstNumberInCollection(ref List<int> collection) { collection.Remove(collection[0]); }
        /// <summary>
        /// Заменяет последнее "младшее" число на "старшее"
        /// </summary>
        private static void replaceLastLowerNumberToHighter(ref List<int> collection)
        {
            if (collection.Contains(lowerNumber))
            {
                collection[collection.LastIndexOf(lowerNumber)] = highterNumber;
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Ищет совпадение текущей числовой последовательности с теми, что уже были найдены и добавлены
        /// </summary>
        /// <param name="collection"></param>
        /// <returns>
        /// <para>true  — числовая последовательность уникальна;</para> 
        /// <para>false — числовая последовательность уже была добавлена</para>
        /// </returns>
        private static bool findPosledInCollection(ref List<int> collection)
        {
            foreach (List<int> item in collectionOfCombinations)
            {
                //Сравнение коллекций методом из Linq (сравнение по содержанию)
                if (item.SequenceEqual(collection))
                {
                    return false;
                }
            }
            return true;
        }

        private static int findChislPosledMultiplyResult(double N)
        {
            //Проверка, совпадают ли "младшее" и "старшее" числа
            if (lowerNumber == highterNumber)
            {
                //Отношение "младшего" чилса к финальной сумме
                double ratioLtoN = N / lowerNumber;
                //Если при делении был остаток, то числовой последовательности не сущесвует 
                if (ratioLtoN % 1 != 0)
                {
                    return 0;
                }
                //Если при делении не было остатка, то возвращается финальный результат перемножения всех чисел в последовательности 
                else
                {
                    return Convert.ToInt32(Math.Pow(Convert.ToDouble(lowerNumber), ratioLtoN));
                }
            }
            else
            {
                //Числовая последовательность
                List<int> collection = new List<int>();
                
                //Заполнение списка с числовой последовательностью нижней цифрой
                for (int i = 0; i < N / lowerNumber; i++)
                {
                    collection.Add(lowerNumber);
                }

                //Заполнение списка нижней цифрой
                while (true)
                {
                    //Текущая сумма последовательности
                    int tmpSum = 0;
                    foreach (int number in collection)
                    {
                        tmpSum += number;
                    }
                    
                    //Если сумма последовательности больше, то из последовательности удаляется первое число в списке
                    if (tmpSum > N)
                    {
                        deleteFirstNumberInCollection(ref collection);
                    }
                    //Если сумма последовательности равна, то происходит проверка, была ли она уже добавлена в список последовательностей
                    //Если она(последовательность) уникальна - она добавляется в список последовательностей
                    else if (tmpSum == N && findPosledInCollection(ref collection))
                    {
                        collectionOfCombinations.Add(new List<int>(collection));
                        replaceLastLowerNumberToHighter(ref collection);
                    }
                    //Если в последовательности не осталось "младших" чисел и последовательность меньше, чем необходимая сумма
                    else if (!collection.Contains(lowerNumber))
                    {
                        break;
                    }
                    //Если в последовательности ещё присутствуют "младшие" числа и она меньше необходимой суммы, то первое с конца "младшее" число в ней заменяется на "старшее"
                    else
                    {
                        replaceLastLowerNumberToHighter(ref collection);
                    }
                }
            }

            //Проверка, удалось ли найти хоть одну числовую последовательность для получения числа N
            if (collectionOfCombinations.Count > 0)
            {
                //Лучший результат
                int topMultiply = 0;
                foreach (List<int> coll in collectionOfCombinations)
                {
                    //Промежуточный результат
                    int tmpMultiply = 0;
                    foreach (int chislo in coll)
                    {
                        if (tmpMultiply != 0)
                        {
                            tmpMultiply *= chislo;
                        }
                        else
                        {
                            tmpMultiply = coll[0];
                        }
                    }
                    //Тернарное сравнение текущего результата с наилучшим
                    topMultiply = topMultiply < tmpMultiply ? tmpMultiply : topMultiply;
                }
                return topMultiply;
            }
            //Если не было найдено ни одной последовательности
            else
            {
                return 0;
            }
        }
    }
}
