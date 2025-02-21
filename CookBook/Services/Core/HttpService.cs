using CookBook.Services.Abstractions;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Services.Core;
public class HttpService : IHttpService
{
    private readonly HttpClient? _client;
    private readonly ISettings _settings;

    public HttpService(ISettings settings)
    {
        HttpClientHandler handler = new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.All
        };

        _client = new HttpClient();
        _settings = settings;
    }

    public async Task<HttpResponseMessage> GetCookBookAsync(params string[] urlParts)
    {
        return await GetAsync(_settings.Urls.CookBook, urlParts);
    }

    public async Task<HttpResponseMessage> GetAsync(string serverAddr, params string[] urlParts)
    {
        Debug.Assert(_client is not null);

        var url = BuildUrl(serverAddr, urlParts);
        return await _client.GetAsync(url);
    }

    public async Task<string> PostCookBookAsync(string data, params string[] urlParts)
    {
        return await PostAsync(data, _settings.Urls.CookBook, urlParts);
    }

    public async Task<string> PostAsync(string data, string serverAddr, params string[] urlParts)
    {
        Debug.Assert(_client is not null);

        using HttpContent content = new StringContent(data,
                                                      Encoding.UTF8,
                                                      "application/json");
        var url = BuildUrl(serverAddr, urlParts);
        HttpRequestMessage requestMessage = new HttpRequestMessage()
        {
            Content = content,
            Method = HttpMethod.Post,
            RequestUri = new Uri(url)
        };

        using HttpResponseMessage response = await _client.SendAsync(requestMessage);
        return await response.Content.ReadAsStringAsync();
    }

    private string BuildUrl(string? url, params string[] urlParts)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(url);

        foreach (var uriPart in urlParts)
        {
            builder.Append('/');
            builder.Append(uriPart);
        }
        return builder.ToString();
    }
}

