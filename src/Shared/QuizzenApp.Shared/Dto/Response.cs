namespace QuizzenApp.Shared.Dto;

public class Response<T>
{
    public bool Success { get; set; }
    public T Data { get; set; }

    public Response( T data, bool success = true)
    {
        Success = success;
        Data = data;
    }
}
