using System;
using System.Linq;

class Baekjoon_14888
{
    static int[] numbers;
    static int[] operators;
    static int max = int.MinValue;
    static int min = int.MaxValue;

    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        operators = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Solution(numbers[0], 1);

        Console.WriteLine(max);
        Console.WriteLine(min);
    }

    static void Solution(int current, int index)
    {
        if (index == numbers.Length)
        {
            max = Math.Max(max, current);
            min = Math.Min(min, current);
            return;
        }

        for (int i = 0; i < 4; i++)
        {
            if (operators[i] > 0)
            {
                operators[i]--;
                int next = Calculate(current, numbers[index], i);
                Solution(next, index + 1);
                operators[i]++;
            }
        }
    }

    static int Calculate(int a, int b, int op)
    {
        switch (op)
        {
            case 0: return a + b;
            case 1: return a - b;
            case 2: return a * b;
            case 3: return a / b;
            default: throw new ArgumentException("Invalid operator");
        }
    }
}