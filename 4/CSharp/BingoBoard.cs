using System.Text;

namespace CSharp;

public class BingoBoard
{
    private BingoNumber[][] Board { get; }
    private BingoNumber[][] TransposedBoard { get; }

    private BingoBoard(BingoNumber[][] board)
    {
        Board = board;
        TransposedBoard = Transpose(board);
    }

    public void PickNumber(int v)
    {
        foreach (var r in Board)
        {
            foreach (var c in r)
            {
                c.CheckNumber(v);
            }
        }

        foreach (var r in TransposedBoard)
        {
            foreach (var c in r)
            {
                c.CheckNumber(v);
            }
        }
    }

    public IEnumerable<BingoNumber> GetAllUnmarkedNumbers() => 
        Board.SelectMany(s => s).Where(s => !s.IsPicked);

    private static BingoNumber[][] Transpose(BingoNumber[][] b) => 
        b.SelectMany(inner => inner.Select((item, index) => new { item, index }))
         .GroupBy(i => i.index, i => i.item)
         .Select(g => g.ToArray())
         .ToArray();

    public bool HasBingo() => 
        Board.Any(b => b.All(i => i.IsPicked)) || 
        TransposedBoard.Any(b => b.All(i => i.IsPicked));

    public static BingoBoard Create(IEnumerable<string> s)
    {
        var arr = s
            .ToArray();

        var ints = new BingoNumber[5][];

        for (var i = 0; i < arr.Length; i++)
        {
            ints[i] = arr[i]
                .Split(' ')
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(int.Parse)
                .Select(BingoNumber.Create)
                .ToArray();
        }

        return new(ints);
    }

    public override string ToString()
    {
        var s = new StringBuilder();
        var line = new StringBuilder();
        for (var r = 0; r < Board.Length; r++)
        {
            line.Clear();
            for (var c = 0; c < Board[r].Length; c++)
            {
                line.Append(Board[r][c].ToString() + "\t");
            }
            s.AppendLine(line.ToString());
        }

        return s.ToString();
    }
}
