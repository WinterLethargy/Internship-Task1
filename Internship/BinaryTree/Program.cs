using System;
using System.Diagnostics;

namespace BinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var intArray = GenerateIntArray(500, 1000);

            var tree = new NaturalBinaryTree(intArray);

            tree.SaveToFile(AppDomain.CurrentDomain.BaseDirectory + "\\tree.xml");

            Console.WriteLine("Обход в глубину. Простые числа:");

            Stopwatch stopWatch = new Stopwatch();
            Action<BinaryTreeNode> visit = (node) =>
            {
                if (IsPrime(node.Data))
                    Console.Write($"{node.Data} ");
            };

            stopWatch.Start();
            tree.TraverseInOrder(visit);
            stopWatch.Stop();

            Console.WriteLine();
            Console.WriteLine($"Время выполнения (такты таймера): {stopWatch.ElapsedTicks}");

            Console.WriteLine();

            Console.WriteLine("Обход в ширину. Простые числа:");

            stopWatch.Reset();
            stopWatch.Start();
            tree.TraverseLevelOrder(visit);
            stopWatch.Stop();

            Console.WriteLine();
            Console.WriteLine($"Время выполнения (такты таймера): {stopWatch.ElapsedTicks}");

            Console.ReadLine();

            int[] GenerateIntArray(int count, int maxValue)
            {
                Random random = new Random();
                var intArray = new int[count];

                for (int i = 0; i < intArray.Length; i++)
                {
                    intArray[i] = random.Next(maxValue);
                }

                return intArray;
            }

            bool IsPrime(int number)
            {
                if (number < 2) return false;

                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0) return false;
                }
                return true;
            }
        }

    }
}
