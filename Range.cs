namespace obiwan;

public class Range(double from, double to)
{
    private readonly bool _isAscending = from <= to;
    public readonly double From = from;
    public readonly double To = to;
    private double CurrentCursor { get; set; } = from;

    public double Cursor => CurrentCursor;

    public bool HasNext => _isAscending ? Cursor < To : Cursor > To;

    public double Next(double step = 1)
    {
        var previous = Cursor;
        CurrentCursor += step;
        return previous;
    }

    public double CursorSet(double cursor)
    {
        var previous = Cursor;
        CurrentCursor = cursor;
        return previous;
    }

    public void Reset()
    {
        CurrentCursor = From;
    }
}