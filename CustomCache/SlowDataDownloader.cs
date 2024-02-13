namespace CustomCache;

public class SlowDataDownloader(Cache<string, string> cache) : IDataDownloader
{
    public string DownloadData(string resourceId)
    {
        if (cache.GetValue(resourceId) is {} cachedData)
            return cachedData;
        Thread.Sleep(1000);
        var downloadedData = $"Some data for {resourceId}";
        cache.SaveOrUpdate(resourceId, downloadedData);
        return downloadedData;
    }
}