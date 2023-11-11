namespace QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;

public record QuestionImage
{
    public string Url { get; init; }

    public QuestionImage(string url)
    {
        Url = url;   
    }
}
