using QuizzenApp.Domain.Exceptions.Common;

namespace QuizzenApp.Domain.Entities.ExamAggregate.ValueObjects;

public record ExamId
{
    public Guid Value { get; init; }

    public ExamId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyValueException(nameof(ExamId));
        }
        Value = value;
    }
}
