using System.Net;

namespace QuizzenApp.Shared.Exceptions;

public class IdentityException : Exception
{
    public List<string> Errors { get; }
    public IdentityException(List<string> errors) : base("Identity operation failed")
    {
        Errors = errors ?? new List<string>();
    }

    public HttpStatusCode statusCode = HttpStatusCode.BadRequest;
}
