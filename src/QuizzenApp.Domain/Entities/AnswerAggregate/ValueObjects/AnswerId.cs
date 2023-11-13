using QuizzenApp.Domain.Exceptions.Common;

namespace QuizzenApp.Domain.Entities.AnswerAggregate.ValueObjects;

public record AnswerId
{
    public Guid Value { get; init; }

    public AnswerId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyValueException(nameof(AnswerId));
        }

        Value = value;
    }

    public static implicit operator Guid(AnswerId id) => id.Value;
    public static implicit operator AnswerId(Guid value) => new(value);
}
