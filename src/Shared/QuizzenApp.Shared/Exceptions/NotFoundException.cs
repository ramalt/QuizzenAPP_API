using System.Net;

namespace QuizzenApp.Shared.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string objectName, string parameter) : base(message: $"{objectName} not found with param: {parameter}")
    {

    }

    public HttpStatusCode statusCode = HttpStatusCode.NotFound;
}
