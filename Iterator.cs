namespace obiwan;

public class Iterator
{
    private readonly IEnumerator<KeyValuePair<string, ObValue>>? _dictEnum;
    private readonly IEnumerator<ObValue>? _listEnum;

    public Iterator(Dictionary<string, ObValue> data)
    {
        _dictEnum = data.GetEnumerator();
        Advance();
    }

    public Iterator(List<ObValue> data)
    {
        _listEnum = data.GetEnumerator();
        Advance();
    }

    public bool HasNext { get; private set; }

    public ObValue[] CurrentCursor => _dictEnum != null
        ? [ObValue.FromString(_dictEnum.Current.Key), _dictEnum.Current.Value]
        : [_listEnum!.Current];

    public ObValue[] Next()
    {
        if (!HasNext)
            return [];

        ObValue[] result = _dictEnum != null
            ? [ObValue.FromString(_dictEnum.Current.Key), _dictEnum.Current.Value]
            : [_listEnum!.Current];

        Advance();
        return result;
    }

    private void Advance()
    {
        HasNext = _dictEnum?.MoveNext() ?? _listEnum!.MoveNext();
    }
}