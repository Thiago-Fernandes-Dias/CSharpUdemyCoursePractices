using CsvDataAccess.CsvReading;
using CsvDataAccess.Interface;

namespace NetUnderTheHoodAssignment.NewSolution;

public class FastTableDataBuilder : ITableDataBuilder
{
    public ITableData Build(CsvData csvData)
    {
        var resultRows = new List<FastRow>();

        foreach (var row in csvData.Rows)
        {
            FastRow newRow = new();
            for (int columnIndex = 0; columnIndex < csvData.Columns.Length; ++columnIndex)
            {
                var column = csvData.Columns[columnIndex];
                string valueAsString = row[columnIndex];
                AssignValueToTheRightRowColumn(valueAsString, column, newRow);
            }
            resultRows.Add(newRow);
        }

        return new FastTableData(csvData.Columns, resultRows);
    }

    private static void AssignValueToTheRightRowColumn(string value, string column, FastRow fastRow)
    {
        if (string.IsNullOrEmpty(value))
        {
            return;
        }
        else if (value == "TRUE")
        {
            fastRow.AssignBool(column, true);
        }
        else if (value == "FALSE")
        {
            fastRow.AssignBool(column, false);
        }
        else if (value.Contains('.') && decimal.TryParse(value, out var valueAsDecimal))
        {
            fastRow.AssignDecimal(column, valueAsDecimal);
        }
        else if (int.TryParse(value, out var valueAsInt))
        {
            fastRow.AssignInt(column, valueAsInt);
        }
    }
}

