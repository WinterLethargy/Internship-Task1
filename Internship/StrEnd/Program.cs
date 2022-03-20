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
            Console.WriteLine(StringHelper.StrEnd(firstStr, secondStr));

            Console.ReadLine();
        }
    }
}