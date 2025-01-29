using CookBook.Services.Abstractions;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Services.Core;
public class HttpService : IHttpService
{
    private readonly HttpClient _client;

    public HttpService()
    {
        HttpClientHandler handler = new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.All
        };

        _client = new HttpClient();
    }

    public async Task<HttpResponseMessage> GetAsync(params string[] uriParts)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(Constants.SERVER_URL);
        builder.Append(':');
        builder.Append(Constants.SERVER_PORT);

        foreach (var uriPart in uriParts)
        {
            builder.Append('/');
            builder.Append(uriPart);
        }

        return await _client.GetAsync(builder.ToString());
    }

    public async Task<string> PostAsync(string uri, string data, string contentType)
    {
        using HttpContent content = new StringContent(data, Encoding.UTF8, contentType);

        HttpRequestMessage requestMessage = new HttpRequestMessage()
        {
            Content = content,
            Method = HttpMethod.Post,
            RequestUri = new Uri(uri)
        };

        using HttpResponseMessage response = await _client.SendAsync(requestMessage);

        return await response.Content.ReadAsStringAsync();
    }
}

