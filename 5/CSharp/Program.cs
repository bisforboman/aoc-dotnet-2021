namespace CSharp;

public static class Program
{
    private record Coordinate(int X, int Y);
    private record Line(Coordinate Start, Coordinate End);

    private static IEnumerable<Coordinate> GetPoints(this Line l, bool diagonal = false)
    {
        if (l.Start.X == l.End.X)
        {
            if (l.Start.Y > l.End.Y)
            {
                for (int y = l.Start.Y; y >= l.End.Y; y--)
                {
                    yield return new Coordinate(l.Start.X, y);
                }
            }
            else
            {
                for (int y = l.Start.Y; y <= l.End.Y; y++)
                {
                    yield return new Coordinate(l.Start.X, y);
                }
            }
        } 
        else if (l.Start.Y == l.End.Y)
        {
            if (l.Start.X > l.End.X)
            {
                for (int x = l.Start.X; x >= l.End.X; x--)
                {
                    yield return new Coordinate(x, l.Start.Y);
                }
            }
            else
            {
                for (int x = l.Start.X; x <= l.End.X; x++)
                {
                    yield return new Coordinate(x, l.Start.Y);
                }
            }
        }
        else if (diagonal)
        {
            if (l.Start.X < l.End.X)
            {
                if (l.Start.Y < l.End.Y)
                {
                    for (int x = l.Start.X, y = l.Start.Y; x <= l.End.X && y <= l.End.Y; x++, y++)
                    {
                        yield return new Coordinate(x, y);
                    }
                }
                else
                {
                    for (int x = l.Start.X, y = l.Start.Y; x <= l.End.X && y >= l.End.Y; x++, y--)
                    {
                        yield return new Coordinate(x, y);
                    }
                }
            }
            else
            {
                if (l.Start.Y < l.End.Y)
                {
                    for (int x = l.Start.X, y = l.Start.Y; x >= l.End.X && y <= l.End.Y; x--, y++)
                    {
                        yield return new Coordinate(x, y);
                    }
                }
                else
                {
                    for (int x = l.Start.X, y = l.Start.Y; x >= l.End.X && y >= l.End.Y; x--, y--)
                    {
                        yield return new Coordinate(x, y);
                    }
                }
            }
        }
    }

    private static IEnumerable<Line> ReadAndParseInput(string filePath)
    {
        var strings = File.ReadAllLines(filePath);

        foreach (var s in strings)
        {
            var tot = s.Split(" -> ").ToArray();

            yield return new(ParseCoordinate(tot[0]), ParseCoordinate(tot[1]));
        }
    }

    private static Coordinate ParseCoordinate(string s)
    {
        var tot = s.Split(",").Select(int.Parse).ToArray();
        return new Coordinate(X: tot[0], Y: tot[1]);
    }

    private static void Part1(string inputPath)
    {
        var lines = ReadAndParseInput(inputPath);

        var list = lines.SelectMany(l => l.GetPoints());

        var plot = new int[1000,1000];

        int ret = 0;
        foreach (var coord in list)
        {
            plot[coord.X, coord.Y]++;

            if (plot[coord.X, coord.Y] == 2)
            {
                ret++;
            }
        }

        Console.WriteLine("Part1 result is: " + ret);
    }

    private static void Part2(string inputPath)
    {
        var lines = ReadAndParseInput(inputPath);

        var list = lines.SelectMany(l => l.GetPoints(true));

        var plot = new int[1000,1000];

        int ret = 0;
        foreach (var coord in list)
        {
            plot[coord.X, coord.Y]++;

            if (plot[coord.X, coord.Y] == 2)
            {
                ret++;
            }
        }

        Console.WriteLine("Part2 result is: " + ret);
    }

    public static void Main(string[] args)
    {
        Part1(args[0]);
        Part2(args[0]);
    }
}
