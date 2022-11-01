namespace CSharp;

public static class Program
{
    private static int[][] ReadAndParseInput(string filePath) => 
        File.ReadAllLines(filePath)
            .ToEnumerable()
            .ToArray();

    private static IEnumerable<int[]> ToEnumerable(this string[] s) => 
        s.Select(i => i.ToCharArray().Select(i => i - '0').ToArray());

    private record Bits(int Zeros, int Ones);

    private static Bits MostCommonValueAt(this IEnumerable<int[]> lists, int i)
    {
        var ones = lists.Sum(l => l[i]);
        return new(lists.Count() - ones, ones);
    }

    private static void Part1(string inputPath)
    {
        var input = ReadAndParseInput(inputPath);

        var gamma = 0;
        var epsilon = 0;
        for (int i = 0; i < input[0].Length; i++)
        {
            gamma <<= 1;
            epsilon <<= 1;

            if (input.MostCommonValueAt(i).HasMoreOnes())
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

    private static int FromIntArray(this int[] array)
    {
        var ret = 0;
        for (int i = 0; i < array.Length; i++)
        {
            ret <<= 1;
            ret += array[i];
        }
        return ret;
    }

    private static bool HasMoreOnes(this Bits b) => b.Ones >= b.Zeros;

    private static int[] Resolve(IEnumerable<int[]> input, int ifTrue, int ifFalse)
    {
        int i = 0;
        var listToReduce = new List<int[]>(input);
        while (listToReduce.Count > 1)
        {
            var pivot = listToReduce.MostCommonValueAt(i).HasMoreOnes() 
                ? ifTrue
                : ifFalse;

            listToReduce.RemoveAll(item => item[i] != pivot);

            i++;
        }

        return listToReduce.First();
    }

    private static void Part2(string inputPath)
    {
        var input = ReadAndParseInput(inputPath);

        var oxygen = Resolve(input, 1, 0).FromIntArray();
        var cO2Scrubber = Resolve(input, 0, 1).FromIntArray();
        
        Console.WriteLine("Part2 result: " + oxygen * cO2Scrubber);
    }

    public static void Main(string[] args)
    {
        Part1(args[0]);
        Part2(args[0]);
    }
}
