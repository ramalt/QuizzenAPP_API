using QuizzenApp.Domain.Exceptions.Common;

namespace QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;

public record QuestionId
{
    public Guid Value { get; init; }

    public QuestionId(Guid value)
    {
        if (value == Guid.Empty)
            throw new EmptyValueException(nameof(QuestionId));

        Value = value;
    }

    public static implicit operator Guid(QuestionId id) => id.Value;
    public static implicit operator QuestionId(Guid value) => new(value);
}
