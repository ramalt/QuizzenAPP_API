using System.Net;

namespace QuizzenApp.Shared.Exceptions;

public class AlreadyExistException : Exception
{
    public AlreadyExistException(string objectName) : base($"{objectName} already exist")
    {

    }

    public HttpStatusCode statusCode = HttpStatusCode.BadRequest;
}
