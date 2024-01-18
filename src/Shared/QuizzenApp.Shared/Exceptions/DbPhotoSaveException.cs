using System.Net;

namespace QuizzenApp.Shared.Exceptions;

public class DbPhotoSaveException : Exception
{
    public DbPhotoSaveException() : base(message: $"An error occurred while saving photo to db.")
    {

    }

    public HttpStatusCode StatusCode = HttpStatusCode.InternalServerError;
}
