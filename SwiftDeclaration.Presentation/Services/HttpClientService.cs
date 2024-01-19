using Newtonsoft.Json;
using SwiftDeclaration.Application.Declarations.Commands.AddDeclaration;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace SwiftDeclaration.Presentation.Services;

public interface IHttpClientService
{
    Task<TResponse> GetAsync<TResponse>(string url);
    Task<TResponse> PostAsync<TResponse>(string url, object data);
    Task PostMultipartFormDataAsync(string ulr, object data);
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
            ?? throw new Exception("Can't deserialize object");
    }

    public async Task<TResponse> PostAsync<TResponse>(string url, object data)
    {
        var content = await SendPostRequestAsync(url, data);

        return JsonConvert.DeserializeObject<TResponse>(content)
            ?? throw new Exception("Can't deserialize object");
    }

    public async Task PostAsync(string url, object data)
    {
        await SendPostRequestAsync(url, data);
    }

    public async Task PostMultipartFormDataAsync(string url, object data)
    {
        using var content = GenerateMultipartFormDataContent(data);

        var response = await _httpClient.PostAsync(url, content);

        if (!response.IsSuccessStatusCode)
        {
            string responseContent = await response.Content.ReadAsStringAsync();
            throw new Exception(response.ReasonPhrase);
        }

    }

    private static MultipartFormDataContent GenerateMultipartFormDataContent(object data)
    {
        var content = new MultipartFormDataContent();

        foreach (var property in data.GetType().GetProperties())
        {
            if (IsFile(property))
            {
                var file = property.GetValue(data) as IFormFile;
                if (file is null)
                {
                    continue;
                }
                var fileContent = new StreamContent(file.OpenReadStream());
                content.Add(fileContent, property.Name, file.FileName);
            }
            content.Add(new StringContent(property.GetValue(data)?.ToString() ?? ""), property.Name);
        }

        return content;
    }

    private static bool IsFile(PropertyInfo propertyInfo)
        => propertyInfo.PropertyType == typeof(IFormFile);

    private async Task<string> SendPostRequestAsync(string url, object data)
    {
        var serializedContent = JsonConvert.SerializeObject(data);
        var content = new StringContent(serializedContent, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, content);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.ReasonPhrase);
        }
        return await response.Content.ReadAsStringAsync();
    }

}
