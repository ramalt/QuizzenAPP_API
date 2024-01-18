using System.Net;
using System.Reflection;

namespace QuizzenApp.Shared.Exceptions;

public class PhotoSaveException : Exception
{
    public PhotoSaveException(string objectName) : base(message: $"An error occurred while saving the {objectName} image file.")
    {
    }

    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;
}
