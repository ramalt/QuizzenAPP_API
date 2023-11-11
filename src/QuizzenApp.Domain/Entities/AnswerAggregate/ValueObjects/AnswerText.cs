using QuizzenApp.Domain.Exceptions.Common;

namespace QuizzenApp.Domain.Entities.AnswerAggregate.ValueObjects;

public record AnswerText
{
    public string Value { get; init; }

    public AnswerText(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyValueException(nameof(AnswerText));

        }
        Value = value;
    }


    public static implicit operator string(AnswerText text) => text.Value;
    public static implicit operator AnswerText(string value) => new(value);
}
