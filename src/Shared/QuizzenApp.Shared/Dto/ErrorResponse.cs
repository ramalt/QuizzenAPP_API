using System.Text.Json;

namespace QuizzenApp.Shared.Dto;

public class ErrorResponse
{
    public bool Success { get; set; } = false;

    public string? Error { get; set; }

    public List<string>? Details { get; set; }

    public Exception? InnerException { get; set; }


    public override string ToString() => JsonSerializer.Serialize(this);

}
