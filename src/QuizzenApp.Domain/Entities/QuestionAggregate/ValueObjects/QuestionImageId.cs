using QuizzenApp.Domain.Exceptions.Common;

namespace QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;

public record QuestionImageId
{
    public Guid Value { get; init; }

    public QuestionImageId(Guid value)
    {
        if (value == Guid.Empty)
            throw new EmptyValueException(nameof(QuestionImageId));
        
        Value = value;
    }

    public static implicit operator Guid(QuestionImageId id) => id.Value;
    public static implicit operator QuestionImageId(Guid value) => new(value);
}
