using System;
using System.Net;

namespace CookBook.Exceptions;
public class ServerException : Exception
{
    public HttpStatusCode ResponseStatus;
    public string Content;

    public ServerException(HttpStatusCode responseStatus, string content)
    {
        ResponseStatus = responseStatus;
        Content = content;
    }

    public ServerException(HttpStatusCode responseStatus, string content, string message)
        : base(message)
    {
        ResponseStatus = responseStatus;
        Content = content;
    }
}

