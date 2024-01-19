using Microsoft.Extensions.Caching.Memory;
using SwiftDeclaration.Infrastructure.Enums;
using SwiftDeclaration.Infrastructure.Services.Interfaces;

namespace SwiftDeclaration.Infrastructure.Services;

/// <summary>
/// Service providing caching functionality using MemoryCache
/// </summary>
public class CachingService : ICachingService
{
    private readonly IMemoryCache _cache;
    private readonly HashSet<string> _cacheKeys;

    /// <summary>
    /// Initializes a new instance of the CachingService class
    /// </summary>
    /// <param name="cache">The IMemoryCache implementation</param>
    public CachingService(IMemoryCache cache)
    {
        _cache = cache;
        _cacheKeys = new();
    }

    /// <summary>
    /// Retrieves cached data by the specified key
    /// </summary>
    /// <typeparam name="TData">The type of the cached data</typeparam>
    /// <param name="key">The unique key associated with the cached data</param>
    /// <returns>The cached data if available; otherwise, the default value for the data type.</returns>
    public TData? GetData<TData>(string key)
    {
        if (_cache.TryGetValue(key, out var data))
        {
            return (TData)data!;
        }

        return default;
    }

    /// <summary>
    /// Sets cached data with the specified key and duration
    /// </summary>
    /// <typeparam name="TData">The type of the data to be cached</typeparam>
    /// <param name="key">The unique key associated with the cached data</param>
    /// <param name="data">The data to be cached</param>
    /// <param name="duration">The duration for which the data should be cached</param>
    /// <returns>True if the data was successfully cached; otherwise, false if the key already exists</returns>
    public bool SetData<TData>(string key, TData data, CacheDuration duration)
    {
        if (KeyExists(key))
        {
            return false;
        }

        var cacheOptions = ConfigureCacheOptions((int)duration);
        _cache.Set(key, data, cacheOptions);
        _cacheKeys.Add(key);
        return true;
    }

    public void ClearCache()
    {
        var memoryCache = _cache as MemoryCache;
        memoryCache?.Clear();
    }

    private bool KeyExists(string key) => _cache.TryGetValue(key, out _);

    private MemoryCacheEntryOptions ConfigureCacheOptions(int durationInSeconds)
        => new MemoryCacheEntryOptions()
        {

        }
        .SetAbsoluteExpiration(DateTime.UtcNow.AddSeconds(durationInSeconds))
        .RegisterPostEvictionCallback((evictedKey, evictedValue, reason, state) =>
        {
            _cacheKeys.Remove(evictedKey.ToString()!);
        });
}
