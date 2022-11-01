namespace CSharp;

public static class Program
{
    private static int[][] ReadAndParseInput(string filePath) => 
        File.ReadAllLines(filePath)
            .ToEnumerable()
            .ToArray();

    private static IEnumerable<int[]> ToEnumerable(this string[] s) => 
        s.Select(i => i.ToCharArray().Select(i => i - '0').ToArray());

    private static void Part1(string inputPath)
    {
        var input = ReadAndParseInput(inputPath);

        var result = new int[input[0].Length];

        foreach (var list in input)
        {
            for (int i = 0; i < list.Length; i++)
            {
                result[i] += list[i];
            }
        }

        var gamma = 0;
        var epsilon = 0;
        for (int i = 0; i < result.Length; i++)
        {
            gamma <<= 1;
            epsilon <<= 1;

            if (result[i] > input.Length/2)
            {
                gamma += 1;
            }
            else
            {
                epsilon += 1;
            }
        }

        Console.WriteLine("Part1 result is: " + gamma * epsilon);
    }

    private static void Part2(string inputPath)
    {
        var input = ReadAndParseInput(inputPath);

        var oxygenGeneratorRating = 0;
        var cO2ScrubberRating = 0;

        // Console.WriteLine("Part2 result: " + result);
    }

    public static void Main(string[] args)
    {
        Part1(args[0]);
        Part2(args[0]);
    }
}
