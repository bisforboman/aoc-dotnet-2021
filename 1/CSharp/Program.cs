namespace CSharp;

public static class Program
{
    private static IEnumerable<int> ReadAndParseInput(string filePath) => 
        File.ReadAllLines(filePath)
            .Select(int.Parse);

    private static int CountMeasurementIncreases(this IEnumerable<int> tuples) => 
        tuples.Prepend(0)
              .Zip(tuples)
              .Skip(1)
              .Count(d => d.First < d.Second);

    private static void Part1(string inputPath)
    {
        var input = ReadAndParseInput(inputPath);

        var result = input.CountMeasurementIncreases();

        Console.WriteLine("Part1 result: " + result);
    }

    private static void Part2(string inputPath)
    {
        var input = ReadAndParseInput(inputPath);

        // first transform data to 'three-measurement sliding window'
        var slidingWindows = input
            .Prepend(0)
            .Prepend(0)
            .Zip(input.Prepend(0), input)
            .Skip(2)
            .Select(i => i.First + i.Second + i.Third);

        var result = slidingWindows.CountMeasurementIncreases();

        Console.WriteLine("Part2 result: " + result);
    }

    public static void Main(string[] args)
    {
        Part1(args[0]);
        Part2(args[0]);
    }
}
