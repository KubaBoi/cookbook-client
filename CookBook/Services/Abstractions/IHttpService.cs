using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Services.Abstractions;
public interface IHttpService
{

    /// <summary>
    /// Call GET to Urls.CookBook and return response.
    /// </summary>
    /// <param name="uriParts">Parts of url except server and port</param>
    /// <returns>Returned response</returns>
    Task<HttpResponseMessage> GetCookBookAsync(params string[] urlParts);

    Task<HttpResponseMessage> GetAsync(string serverAddr, params string[] urlParts);

    /// <summary>
    /// Call POST to Urls.CookBook and return response content.
    /// Content type is always application/json
    /// and encoding UTF-8.
    /// </summary>
    /// <param name="data">JSON as string</param>
    /// <param name="urlParts">Parts of url except server and port</param>
    /// <returns>Returned response content</returns>
    Task<string> PostCookBookAsync(string data, params string[] urlParts);

    Task<string> PostAsync(string data, string serverAddr, params string[] urlParts);
}

