using QuizzenApp.Domain.Entities.AnswerAggregate.ValueObjects;
using QuizzenApp.Domain.Entities.UserAggregate;
using QuizzenApp.Domain.Enums;
using QuizzenApp.Shared.Domain;

namespace QuizzenApp.Domain.Entities.AnswerAggregate;

public class Answer : AggregateRoot<AnswerId>
{
    public AnswerId Id { get; private set; }
    public AnswerText Text { get; private set; }
    public List<AnswerImage> Images { get; private set; }
    public AnswerStatus Status { get; private set; }

    public User User { get; private set; }
}
