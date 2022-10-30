namespace CSharp;

public static class Program
{
    private static IEnumerable<int> ReadAndParseInput() => 
        File.ReadAllLines("../largeinput.txt")
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

    private static void Part1()
    {
        var input = ReadAndParseInput();

        var result = input.CountMeasurementIncreases();

        Console.WriteLine(result);
    }

    private static void Part2()
    {
        var input = ReadAndParseInput();

        // first transform data to 'three-measurement sliding window'
        var slidingWindows = input
            .Prepend(int.MaxValue)
            .Prepend(int.MaxValue)
            .Zip(input.Prepend(int.MaxValue), input)
            .Skip(2)
            .Select(i => i.First + i.Second + i.Third);

        var result = slidingWindows.CountMeasurementIncreases();

        Console.WriteLine(result);
    }

    public static void Main() => Part2();
}
