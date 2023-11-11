using QuizzenApp.Domain.Exceptions.Common;

namespace QuizzenApp.Domain.Entities.ExamAggregate;

public record ExamTopic
{
    public string Value { get; init; }

    public ExamTopic(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyValueException(nameof(ExamTopic));
        }
        Value = value;
    }
}
