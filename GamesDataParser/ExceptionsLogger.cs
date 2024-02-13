namespace GamesDataParser;

public class ExceptionsLogger
{
    public void LogException(Exception ex)
    {
        var log = $"[{DateTime.Now:yyyy/MM/dd HH:mm:ss tt}] " 
            + $"Exception message: {ex.Message} " 
            + $"Stack Trace: {ex.StackTrace}{Environment.NewLine}";
        File.AppendAllTextAsync("log.txt", log);
    }
}
