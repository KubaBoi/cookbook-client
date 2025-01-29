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
    /// Builds url from Constatns SERVER_URL and SERVER_PORT
    /// and uri parts joined with ":"
    /// </summary>
    /// <param name="uriParts">Parts of url</param>
    /// <returns></returns>
    Task<HttpResponseMessage> GetAsync(params string[] uriParts);

    Task<string> PostAsync(string url, string data, string contentType);
}

