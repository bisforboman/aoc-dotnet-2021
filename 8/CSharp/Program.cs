namespace CSharp;

public static class Program
{
    private static string[] ReadAndParseInput(string filePath) => 
        File.ReadAllLines(filePath).ToArray();

    private static void Part1(string inputPath)
    {
        Console.WriteLine("Part1 result is: ");
    }

    private static void Part2(string inputPath)
    {
        Console.WriteLine("Part2 result is: ");
    }

    public static void Main(string[] args)
    {
        Part1(args[0]);
        Part2(args[0]);
    }
}
