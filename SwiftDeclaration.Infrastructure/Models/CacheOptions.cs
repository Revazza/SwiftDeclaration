
using SwiftDeclaration.Infrastructure.Enums;

namespace SwiftDeclaration.Infrastructure.Models;

public class CacheOptions
{
    public string Key { get; set; }
    public CacheDuration Duration { get; set; }

    public CacheOptions()
    {
        Key = string.Empty;
    }
}