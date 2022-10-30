namespace CSharp;

public static class Program
{
    private static IEnumerable<int> ReadAndParseInput(string filePath) => 
        File.ReadAllLines(filePath)
            .Select(int.Parse);

    public record DataPoint(int Previous, int Current);

    private static IEnumerable<DataPoint> TransformToDataPoints(this IEnumerable<int> tuples) => 
        tuples.Prepend(int.MaxValue)
              .Zip(tuples)
              .Skip(1)
              .Select(i => new DataPoint(i.First, i.Second));

    private static int CountMeasurementIncreases(this IEnumerable<int> ints) => 
        ints.TransformToDataPoints()
            .Count(d => d.Previous < d.Current);

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
            .Prepend(int.MaxValue)
            .Prepend(int.MaxValue)
            .Zip(input.Prepend(int.MaxValue), input)
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
