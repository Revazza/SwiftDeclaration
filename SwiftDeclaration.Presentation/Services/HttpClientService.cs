using Newtonsoft.Json;
using System.Text;

namespace SwiftDeclaration.Presentation.Services;

public interface IHttpClientService
{
    Task<TResponse> GetAsync<TResponse>(string url);
    Task<TResponse> PostAsync<TResponse>(string url, object data);
    Task PostAsync(string url, object data);
}

public class HttpClientService : IHttpClientService
{
    private readonly HttpClient _httpClient;

    public HttpClientService(IConfiguration configuration)
    {
        _httpClient = new()
        {
            BaseAddress = new Uri(configuration.GetSection("SwiftDeclarationApi").Value!)
        };
    }

    public async Task<TResponse> GetAsync<TResponse>(string url)
    {
        var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}{url}");
        var data = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<TResponse>(data)
            ?? throw new Exception("Can't deserialize object"); ;
    }

    public async Task<TResponse> PostAsync<TResponse>(string url, object data)
    {
        var content = await SendPostRequestAsync(url, data);

        return JsonConvert.DeserializeObject<TResponse>(content)
            ?? throw new Exception("Can't deserialize object"); ;
    }

    public async Task PostAsync(string url, object data)
    {
        await SendPostRequestAsync(url, data);
    }

    private async Task<string> SendPostRequestAsync(string url, object data)
    {
        var content = SerializeObject(data);
        var response = await _httpClient.PostAsync(url, content);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.ReasonPhrase);
        }
        return await response.Content.ReadAsStringAsync();
    }

    private static StringContent SerializeObject(object data)
        => new(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
}
