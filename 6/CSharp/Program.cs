using System.Diagnostics;

namespace CSharp;

public static class Program
{
    private static int[] ReadAndParseInput(string filePath) => 
        File.ReadAllText(filePath)
            .Split(',')
            .Select(int.Parse)
            .ToArray();

    private static void Part1(string inputPath)
    {
        var fishes = ReadAndParseInput(inputPath)
            .ToList();

        int newFishesCount;
        for (int i = 0; i < 80; i++)
        {
            newFishesCount = 0; 
            for (int j = 0; j < fishes.Count; j++)
            {
                if (fishes[j] == 0)
                {
                    newFishesCount++;
                    fishes[j] = 6;
                }
                else
                {
                    fishes[j]--;
                }
            }

            fishes.AddRange(Enumerable.Repeat(8, newFishesCount));
        }

        Console.WriteLine("Part1 result is: " + fishes.Count);
    }

    private static void Part2(string inputPath)
    {
        var fishes = ReadAndParseInput(inputPath)
            .GroupBy(i => i)
            .ToDictionary(i => i.Key, i => i.Count());

        var arr = new long[9];
        foreach (var f in fishes)
        {
            arr[f.Key] = f.Value;
        }

        long newFishesCount;
        for (int i = 0; i < 256; i++)
        {
            newFishesCount = arr[0];

            for (int j = 1; j < arr.Length; j++)
            {
                arr[j-1] = arr[j];
            }

            arr[8] = newFishesCount;
            arr[6] += newFishesCount;
        }

        Console.WriteLine("Part2 result is: " + arr.Sum());
    }

    public static void Main(string[] args)
    {
        Part1(args[0]);
        Part2(args[0]);
    }
}
