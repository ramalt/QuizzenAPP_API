using QuizzenApp.Domain.Exceptions.Common;

namespace QuizzenApp.Domain.Entities.AnswerAggregate.ValueObjects;

public record AnswerImageId
{
    public Guid Value { get; init; }

    public AnswerImageId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyValueException(nameof(AnswerImageId));
        }
        Value = value;
    }

    public static implicit operator Guid(AnswerImageId id) => id.Value;
    public static implicit operator AnswerImageId(Guid value) => new(value);
}
