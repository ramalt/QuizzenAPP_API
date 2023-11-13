using QuizzenApp.Domain.Exceptions.Common;
using QuizzenApp.Domain.Exceptions.QuestionExceptions;

namespace QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;

public record QuestionTitle
{
    public string Value { get; init; }
    public QuestionTitle(string value)
    {
        int valueMaxLength = 200;
        if (string.IsNullOrWhiteSpace(value))
            throw new EmptyValueException(nameof(QuestionTitle));

        if (value.Length > valueMaxLength)
            throw new QuestionOverLimitException(nameof(QuestionTitle), valueMaxLength.ToString());

        Value = value;
    }

    public static implicit operator string(QuestionTitle title) => title.Value;
    public static implicit operator QuestionTitle(string title) => new(title);
}