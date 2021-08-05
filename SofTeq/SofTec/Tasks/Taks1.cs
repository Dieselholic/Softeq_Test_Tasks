using System;

namespace SofTec
{
    /// <summary>
    /// Задание №1.
    /// <para>Условие:</para>
    /// <para>
    /// Three famous scientists Voktaysed, Vokiruy and Veidafin decided to help well-known 
    /// brainy creature Rotsor to pass exams. Exams were on a very interesting and useful 
    /// subject - Approximate Optimization. The problem was to write a program that behaves
    /// like the one written by Cheetah (who gave only EXE file running away for playing
    /// Civilization III). As Cheetah's mind is not so powerful Rotsor believes that Cheetah
    /// could write only a program evaluating some polynomial. He is also sure that the
    /// polynomial degree is at most four (5 is too much for Cheetah). Help the scientists 
    /// to help Rotsor and write the desired program. Remember that Rotsor is too lazy and
    /// the scientists are too busy so the only hope is on you.
    /// </para>
    /// </summary>
    public class Task1
    {
        //f(x) = A* x^4 + B* x^3 + C* x^2 + D* x + E

        private const double A = 1;
        private const double B = 1.2;
        private const double C = -20;
        private const double D = 0;
        private const double E = 123.456;

        /// <summary>
        /// Метод запуска задачи №1.
        /// <para>
        /// On the first line of the input you will be given number of test cases 
        /// T (no greater than 100). T following lines will be numbers for evaluation 
        /// (in range [-1000; 1000])
        /// </para>
        /// </summary>
        /// <returns>
        /// T lines of output. Each line is the evaluation of the polynomial and should 
        /// be same as the result of Cheetah's program. As was already said Cheetah's program
        /// evaluates polynomial of the form f(x) = A*x^4 + B*x^3 + C*x^2 + D*x + E. Print the
        /// values of f(x) with precision of 3 digits.
        /// </returns>
        public static void Run()
        {
            Console.Title = "Task №1";
            while (true)
            {
                try
                {
                    //если необходимо ввести число с float
                    string[] input = Console.ReadLine().Split();
                    int testCasesCounter = int.Parse(input[0]);
                    if(input.Length == 1 && testCasesCounter < 100 && testCasesCounter > 0)
                    {
                        input = new string[testCasesCounter];
                        
                        for (int i = 0; i < testCasesCounter; i++)
                        {
                            input[i] = Console.ReadLine();
                            if(Convert.ToDouble(input[i]) > 1000 || Convert.ToDouble(input[i]) < -1000)
                            {
                                Console.WriteLine("Invalid Input : the number that does not fit the conditions is not suitable");
                                i--;
                                continue;
                            }
                        }
                    }
                    
                    Console.WriteLine();

                    foreach (string testCaseNumber in input)
                    {
                        double x = float.Parse(testCaseNumber);
                        Console.WriteLine(
                            Math.Round(
                                (A * Math.Pow(x, 4)) +
                                (B * Math.Pow(x, 3)) +
                                (C * Math.Pow(x, 2)) +
                                (D * x) + E, 3
                            )
                        );
                    }

                    return;
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
    }
}
