using QuizzenApp.Domain.Exceptions.Common;
using QuizzenApp.Domain.Exceptions.QuestionExceptions;

namespace QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;

public record QuestionDescription
{
    public string Value { get; init; }

    public QuestionDescription(string value)
    {
        int textMaxLimit = 500;
        if (string.IsNullOrWhiteSpace(value))
            throw new EmptyValueException(nameof(value));


        if (value.Length > textMaxLimit)
            throw new QuestionOverLimitException(type: typeof(QuestionDescription), textMaxLimit.ToString());

        Value = value;
    }

    public static implicit operator string(QuestionDescription text) => text.Value;
    public static implicit operator QuestionDescription(string value) => new(value);


}
