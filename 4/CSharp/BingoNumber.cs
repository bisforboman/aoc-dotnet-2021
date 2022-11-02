namespace CSharp;

public class BingoNumber
{
    public int Value { get; }
    public bool IsPicked { get; private set; }

    private BingoNumber(int v)
    {
        Value = v;
    }

    public void CheckNumber(int v)
    {
        if (Value == v)
        {
            IsPicked = true;
        }
    }

    public static BingoNumber Create(int v) => new(v);

    public override string ToString() => $"({Value,2},{(IsPicked ? "X" : string.Empty),1})";
}
