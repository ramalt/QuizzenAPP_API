using QuizzenApp.Domain.Entities.AnswerAggregate.ValueObjects;
using QuizzenApp.Domain.Entities.UserAggregate;
using QuizzenApp.Domain.Enums;
using QuizzenApp.Domain.Exceptions.AnswerExceptions;
using QuizzenApp.Shared.Domain;

namespace QuizzenApp.Domain.Entities.AnswerAggregate;

public class Answer(Guid id, AnswerText text, User user, List<AnswerImage> images) : AggregateRoot<AnswerId>
{
    public new AnswerId Id { get; private set; } = id;
    public AnswerText Text { get; private set; } = text;
    public List<AnswerImage> Images { get; private set; } = images;
    public AnswerStatus Status { get; private set; } = AnswerStatus.active;
    public User User { get; private set; } = user;

    public void UpdateStatus(AnswerStatus status)
    {
        if (!Enum.IsDefined(typeof(AnswerStatus), status))
        {
            throw new InvalidStatusException(typeof(AnswerStatus), status);
        }
        Status = status;
    }
}
