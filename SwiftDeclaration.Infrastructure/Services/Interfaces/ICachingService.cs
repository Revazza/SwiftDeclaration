using SwiftDeclaration.Infrastructure.Enums;

namespace SwiftDeclaration.Infrastructure.Services.Interfaces;

public interface ICachingService
{
    /// <summary>
    /// Retrieves cached data by the specified key
    /// </summary>
    /// <typeparam name="TData">The type of the cached data</typeparam>
    /// <param name="key">The unique key associated with the cached data</param>
    /// <returns>The cached data if available; otherwise, the default value for the data type.</returns>
    TData? GetData<TData>(string key);

    /// <summary>
    /// Sets cached data with the specified key and duration
    /// </summary>
    /// <typeparam name="TData">The type of the data to be cached</typeparam>
    /// <param name="key">The unique key associated with the cached data</param>
    /// <param name="data">The data to be cached</param>
    /// <param name="duration">The duration for which the data should be cached</param>
    /// <returns>True if the data was successfully cached; otherwise, false if the key already exists</returns>
    bool SetData<TData>(string key, TData data, CacheDuration duration = CacheDuration.OneMinute);

    void ClearCache();

}
