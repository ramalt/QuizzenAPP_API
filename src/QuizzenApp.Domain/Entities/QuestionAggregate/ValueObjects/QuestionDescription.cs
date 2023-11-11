namespace QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;

public record QuestionDescription
{
    public string Text { get; init; }
    public List<QuestionImage> Images { get; init; }
}
