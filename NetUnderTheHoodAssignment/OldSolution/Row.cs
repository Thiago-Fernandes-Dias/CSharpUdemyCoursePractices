namespace CsvDataAccess.OldSolution;

public class Row
{
    private Dictionary<string, object> _data;

    public Row(Dictionary<string, object> data)
    {
        _data = data;
    }

    public object GetAtColumn(string columnName)
    {
        if (_data.TryGetValue(columnName, out var value))
            return value;
        return null;
    }
}