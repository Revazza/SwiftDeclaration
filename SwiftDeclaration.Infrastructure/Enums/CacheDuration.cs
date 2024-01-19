namespace SwiftDeclaration.Infrastructure.Enums;

/// <summary>
/// Represents predefined cache durations in seconds
/// </summary>
public enum CacheDuration
{
    OneMinute = 3600,
    FiveMinutes = OneMinute * 5,
    TenMinutes = OneMinute * 10,
    ThirtyMinutes = OneMinute * 30,
    OneHour = OneMinute * 60
}
