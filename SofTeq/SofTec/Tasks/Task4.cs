using System;

namespace SofTec
{
    /// <summary>
    /// Задача №4.
    /// <para>Условие:</para>
    /// <para>
    /// Тошик проснулся ночью с жаждой охоты. Наловив N белых и M черных мышей,
    /// он принес их утром хозяйке. Ожидая, когда она проснется и порадуется,
    /// он разложил их следующим образом:
    /// <para>
    /// N...N — M...M
    /// </para>
    /// <para>Его хозяйка очень любит поспать.
    /// Тошик заскучал и решил переложить мышей так, чтобы черные лежали слева,
    /// а белые справа. При этом он соблюдает следующие правила перекладывания:
    /// <list type="bullet">Белую мышь можно переложить на соседнюю от нее справа клетку, если она не занята</list>
    /// <list type="bullet">Черную мышь можно переложить на соседнюю от нее слева клетку, если она не занята</list>
    /// <list type="bullet">Белую мышь можно переложить через одну черную на свободную клетку справа от нее</list>
    /// <list type="bullet">Черную мышь можно переложить через одну белую на свободную клетку слева от нее</list>
    /// </para>
    /// <para>
    /// Тошик, как и всякий кот, ленив, и поэтому он хочет поменять мышей местами за
    /// наименьшее число перекладываний. Ниже приведена оптимальная последовательность
    /// перекладываний для случая N = M = 2.
    /// </para>
    /// В данном случае Тошику потребовалось 8 перекладываний.
    /// Напишите программу, которая находит минимальное число перекладываний,
    /// необходимых, чтобы поменять местами N белых и M черных мышей.
    /// </para>
    /// </summary>
    public class Task4
    {
        /// <summary>
        /// Метод запуска задачи №4.
        /// <para>
        /// Принимает N и M, введённые через пробел.
        /// </para>
        /// </summary>
        /// <returns>
        /// Выводит на экран наименьшее число количество перекладываний мышек Тошиком.
        /// </returns>
        public static void Run()
        {
            Console.Title = "Task №4";
            while (true)
            {
                try
                {
                    string[] input = Console.ReadLine().Split();

                    if (input.Length == 2)
                    {
                        int whiteMouses = int.Parse(input[0].Trim());
                        int blackMouses = int.Parse(input[1].Trim());

                        if (whiteMouses >= 1 && blackMouses <= 1000 && blackMouses >= 0)
                        {
                            Console.WriteLine("\n" + getMovementsCount(whiteMouses, blackMouses));
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

        /// <summary>
        /// Рассчитывает, сколько перекладываний должен совершить Тошик,
        /// исходя из количества белых и чёрных мышей.
        /// </summary>
        /// <returns>Наименьшее число перекладываний.</returns>
        private static int getMovementsCount(int whiteMouses, int blackMouses)
        {
            int h = whiteMouses > blackMouses ? whiteMouses : blackMouses;
            int l = whiteMouses < blackMouses ? whiteMouses : blackMouses;

            return h * (l + 1) + l;
        }
    }
}
