
namespace CustomCache;

public class Cache<TKey, TValue> where TKey : notnull where TValue : class?
{
    private readonly Dictionary<TKey, TValue> _cache = [];

    public TValue? GetValue(TKey key)
    {
        if (_cache.TryGetValue(key, out TValue? value))
            return value;
        return null;
    }

    public void SaveOrUpdate(TKey resourceId, TValue downloadedData) =>
        _cache[resourceId] = downloadedData;
}