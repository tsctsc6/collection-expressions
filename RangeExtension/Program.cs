using RangeExtension.Utilities;

namespace RangeExtension;

internal class Program
{
    static void Main(string[] args)
    {
        foreach(var i in 0..5)
        {
            Console.Write($"{i}, ");
        }
        Console.WriteLine();
        RangeCollention r1 = new([0..5, 10..15]);
        RangeCollention r2 = RangeCollentionBuilder.Create([0..5, 10..15]);
        //RangeCollention r3 = [0..5, 10..15];
        foreach (var i in r1)
        {
            Console.Write($"{i}, ");
        }
        Console.WriteLine();
    }
}
