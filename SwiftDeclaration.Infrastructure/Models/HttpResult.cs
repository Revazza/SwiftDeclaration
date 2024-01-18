using SwiftDeclaration.Infrastructure.Enums;

namespace SwiftDeclaration.Infrastructure.Models;

/// <summary>
/// Class representing HTTP results with a default payload of type 'object'
/// </summary>
public class HttpResult : HttpResultBase<object>
{
    private HttpResult(HttpResultStatus status, string? message = default, object? payload = default)
    {
        Message = message;
        Status = status;
        Payload = payload;
    }

    /// <summary>
    /// Creates an HTTP result with a status of 'Error'
    /// </summary>
    public static HttpResult NotOk(string? errorMsg = default, object? payload = default)
        => new(HttpResultStatus.Error, errorMsg, payload);

    /// <summary>
    /// Creates an HTTP result with a status of 'Ok'
    /// </summary>
    public static HttpResult Ok(object? payload = default, string? message = default)
        => new(HttpResultStatus.Ok, message, payload);
}

