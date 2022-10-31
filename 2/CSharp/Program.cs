namespace CSharp;

public static class Program
{
    private static IEnumerable<(int, int)> ReadAndParseInput(string filePath) => 
        File.ReadAllLines(filePath)
            .Select(ToCoordinate);

    private static (int, int) ToCoordinate(string s)
    {
        var split = s.Split(' ');

        return FromString(split[0], int.Parse(split[1]));
    }

    private static (int, int) FromString(string s, int x) => s switch
    {
        "forward" => (x, 0),
        "up"      => (0, -x),
        "down"    => (0, x),
        _         => (0, 0)
    };

    private static void Part1(string inputPath)
    {
        var input = ReadAndParseInput(inputPath);

        var xLevel = input.Sum(c => c.Item1);
        var yLevel = input.Sum(c => c.Item2);

        Console.WriteLine("Part1 result is: " + xLevel * yLevel);
    }

    private static int CalculateUsingNewWay(this IEnumerable<(int, int)> coordinates)
    {
        int aim = 0;
        int depth = 0;
        int horizontal = 0;
        foreach (var coord in coordinates)
        {
            switch (coord)
            {
                // up / down
                case (int a, int b) when a <= 0:
                    aim += b;
                    break;

                // forward
                case (int a, int b) when a > 0:
                    depth += aim * a;
                    horizontal += a;
                    break;

                default: 
                    break;
            };
        }

        return horizontal * depth;
    }

    private static void Part2(string inputPath)
    {
        var input = ReadAndParseInput(inputPath);

        var result = input.CalculateUsingNewWay();

        Console.WriteLine("Part2 result: " + result);
    }

    public static void Main(string[] args)
    {
        Part1(args[0]);
        Part2(args[0]);
    }
}
