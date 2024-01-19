using MediatR;
using Microsoft.Extensions.Configuration;
using SwiftDeclaration.Infrastructure.Models;
using SwiftDeclaration.Infrastructure.Services.Interfaces;

namespace SwiftDeclaration.Infrastructure.Behaviours;

/// <summary>
/// Pipeline behavior for caching query results based on specified criteria
/// </summary>
/// <typeparam name="TRequest">The type of the query request</typeparam>
/// <typeparam name="TResponse">The type of the query response</typeparam>
public class QueryCachingBehaviour<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICacheableQuery

{
    private readonly ICachingService _cachingService;
    private readonly IConfiguration _configuration;

    public QueryCachingBehaviour(
        ICachingService cachingService, IConfiguration configuration)
    {
        _cachingService = cachingService;
        _configuration = configuration;
    }

    /// <summary>
    /// Handles the query, either retrieving cached data or executing the query and caching the result
    /// </summary>
    /// <param name="request">The query request</param>
    /// <param name="next">The next step in the pipeline</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The query response</returns>
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var cacheOptions = GetCacheOptions(request);
        var cacheKey = CreateCacheKey(cacheOptions.Key, request.Salt);

        var data = _cachingService.GetData<TResponse>(cacheKey);

        if (data is not null)
        {
            return data;
        }

        var result = await next();

        // if result is default/null or empty IEnumerable, we skip caching
        if (IsDefaultOrEmpty(result))
        {
            return result;
        }

        _cachingService.SetData(cacheKey, result, cacheOptions.Duration);

        return result;
    }

    private static bool IsDefaultOrEmpty(TResponse result)
        => EqualityComparer<TResponse>.Default.Equals(result, default) ||
        result is not IEnumerable<object> enumerable ||
        !enumerable.Any();

    private static string CreateCacheKey(string key, string salt) => $"{key}-{salt}";

    private CacheOptions GetCacheOptions(TRequest request)
    {
        var cacheOptions = new CacheOptions();

        _configuration
            .GetSection($"Caching:{request.SectionName}")
                .Bind(cacheOptions);

        return cacheOptions;
    }

}