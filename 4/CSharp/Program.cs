namespace CSharp;

public static class Program
{
    private static (int[], BingoBoard[]) ReadAndParseInput(string filePath)
    {
        var input = File.ReadAllLines(filePath).ToArray();

        var numbers = input[0]
            .Split(',')
            .Select(int.Parse)
            .ToArray();

        return (numbers, YieldMe(input).ToArray());
    }

    private static IEnumerable<BingoBoard> YieldMe(string[] s)
    {
        for (int i = 2; i < s.Length; i+=6)
        {
            yield return BingoBoard.Create(s.Skip(i).Take(5));
        }
    }

    private static void Part1(string inputPath)
    {
        var (numbers, boards) = ReadAndParseInput(inputPath);

        foreach (var n in numbers)
        {
            foreach (var b in boards)
            {
                b.PickNumber(n);
            }

            if (boards.Any(b => b.HasBingo()))
            {
                foreach (var b in boards.Where(bi => bi.HasBingo()))
                {
                    var sum = b
                        .GetAllUnmarkedNumbers()
                        .Sum(bi => bi.Value);

                    Console.WriteLine("Part1 result is: " + n * sum);
                }
                break;
            }
        }
    }

    private static void Part2(string inputPath)
    {
        var (numbers, boards) = ReadAndParseInput(inputPath);

        var unfinishedBoards = new List<BingoBoard>(boards);
        foreach (var n in numbers)
        {
            foreach (var b in unfinishedBoards)
            {
                b.PickNumber(n);
            }

            if (unfinishedBoards.Count > 1)
            {
                unfinishedBoards.RemoveAll(b => b.HasBingo());
            }
            else if (unfinishedBoards[0].HasBingo())
            {
                var sum = unfinishedBoards[0].GetAllUnmarkedNumbers().Sum(bi => bi.Value);

                Console.WriteLine("Part2 result is: " + n * sum);
                break;
            }
        }
    }

    public static void Main(string[] args)
    {
        Part1(args[0]);
        Part2(args[0]);
    }
}
