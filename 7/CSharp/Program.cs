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
        var numbers = ReadAndParseInput(inputPath);

        var results = new int[numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            results[i] = numbers
                .Select(n => Math.Abs(n - i))
                .Sum();
        }

        var result = results.Min();

        Console.WriteLine("Part1 result is: " + result);
    }

    private static void Part2(string inputPath)
    {
        var numbers = ReadAndParseInput(inputPath);

        var results = new int[numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            results[i] = numbers
                .Select(n => 
                {
                    var a = Math.Abs(n - i);
                    return a * (a+1) / 2;
                })
                .Sum();
        }

        var result = results.Min();
        
        Console.WriteLine("Part2 result is: " + result);
    }

    public static void Main(string[] args)
    {
        Part1(args[0]);
        Part2(args[0]);
    }
}
