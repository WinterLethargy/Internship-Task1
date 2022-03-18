using System;

namespace StrEnd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstStr = "  \n qwertyui  \t";
            string secondStr = " yui\t";

            Console.WriteLine($"Первая строка: {firstStr}");
            Console.WriteLine($"Вторая строка: {secondStr}");
            Console.Write("Первая строка заканчивается второй строкой: ");
            Console.WriteLine(StrEnd(firstStr, secondStr));

            Console.ReadLine();

            bool StrEnd(string firstStr, string secondStr)
            {
                firstStr = firstStr.Trim();
                secondStr = secondStr.Trim();

                if (firstStr.Length < secondStr.Length)
                    return false;

                var firstStrEnd = firstStr.Substring(firstStr.Length - secondStr.Length);

                return firstStrEnd == secondStr;
            }
        }
    }
}