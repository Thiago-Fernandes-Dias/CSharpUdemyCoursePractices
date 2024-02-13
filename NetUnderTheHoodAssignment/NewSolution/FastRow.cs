namespace NetUnderTheHoodAssignment.NewSolution;

public class FastRow
{
    private readonly Dictionary<string, int> _intData = new();
    private readonly Dictionary<string, bool> _boolData = new();
    private readonly Dictionary<string, decimal> _decimalData = new();
    private readonly Dictionary<string, string> _stringData = new();

    public void AssignBool(string columnName, bool value)
    {
        _boolData[columnName] = value;
    }

    public void AssignInt(string columnName, int value)
    {
        _intData[columnName] = value;
    }

    public void AssignDecimal(string columnName, decimal value)
    {
        _decimalData[columnName] = value;
    }

    public void AssignString(string columnName, string value)
    {
        _stringData[columnName] = value;
    }

    public object GetAtColumn(string columnName)
    {
        if (_intData.TryGetValue(columnName, out int intValue))
            return intValue;
        else if (_decimalData.TryGetValue(columnName, out decimal decimalValue))
            return decimalValue;
        else if (_boolData.TryGetValue(columnName, out bool boolValue))
            return boolValue;
        else if (_stringData.TryGetValue(columnName, out string stringValue))
            return stringValue;
        return null;
    }
}