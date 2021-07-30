using System;
using System.Collections.Generic;

namespace SofTec
{
    /// <summary>
    /// Задание №2.
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
    class Task2
    {
        //N(4 ≤ N ≤ 10, N четное) и M(N ≤ M ≤ 20).
        private static int wheelsCount; // N
        private static int tireCount;   // M

        /// <summary>
        /// Метод запуска задачи №2.
        /// <para>
        /// Принимает N и M, введённые в консоль через пробел.
        /// </para>
        /// </summary>
        /// <returns>
        /// Выводит на экран число, являющееся максимальным количеством километров, которые способен проехать автомобиль с заданными параметрами колёс и кол-вом шин
        /// </returns>
        public static void Run()
        {
            Console.Title = "Task №2";
            while (true)
            {
                try
                {
                    string[] input = Console.ReadLine().Split();
                    if (input.Length == 2)
                    {
                        wheelsCount = int.Parse(input[0]);
                        tireCount = int.Parse(input[1]);

                        if (wheelsCount >= 4 && wheelsCount <= 10 && wheelsCount % 2 == 0 && tireCount >= wheelsCount && tireCount <= 20)
                        {
                            List<int> wheelsEnduranceList = new List<int>();
                            for (int i = 0; i < wheelsCount; i++)
                            {
                                string inputWheelEndurance = Console.ReadLine();
                                if (int.Parse(inputWheelEndurance.Trim()) > 0 && int.Parse(inputWheelEndurance.Trim()) <= 3000)
                                {
                                    wheelsEnduranceList.Add(int.Parse(inputWheelEndurance.Trim()));
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input, please try again");
                                    Console.ReadLine();
                                }
                            }
                            Console.WriteLine("\n" + Math.Round(getMiddleHarmonicNumber(wheelsEnduranceList), 3, MidpointRounding.ToZero));
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
        /// Возвращает максимальное кол-во километров, которое способен проехать автомобиль, посредством нахождения среднего гармонического
        /// </summary>
        /// <param name="wheelsEnduranceList">Список со значениями износа шин на каждом из колёс</param>
        /// <returns></returns>
        private static double getMiddleHarmonicNumber(List<int> wheelsEnduranceList)
        {
            double middleHarmonicNumber = 0;

            foreach (int wheelEndurance in wheelsEnduranceList)
            {
                middleHarmonicNumber += 1.0 / wheelEndurance;
            }

            return tireCount / middleHarmonicNumber;
        }
    } 
}