using QuizzenApp.Domain.Entities.AnswerAggregate;
using QuizzenApp.Domain.Entities.ExamAggregate;
using QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;
using QuizzenApp.Domain.Entities.UserAggregate;
using QuizzenApp.Domain.Enums;
using QuizzenApp.Domain.Exceptions.AnswerExceptions;
using QuizzenApp.Shared.Domain;

namespace QuizzenApp.Domain.Entities.QuestionAggregate;

public class Question(Guid id, QuestionTitle title, QuestionDescription description, Exam exam, User user) : AggregateRoot<QuestionId>
{
    public new QuestionId Id { get; private set; } = id;
    public QuestionTitle Title {get; private set;} = title;
    public QuestionDescription Description {get; private set;} = description;
    public Exam Exam { get; private set; } = exam;
    public QuestionStatus Status { get; private set; } = QuestionStatus.active;
    public List<Answer>? Answers { get; private set; }
    public User User { get; private set; } = user;

        public void UpdateStatus(QuestionStatus status)
    {
        if (!Enum.IsDefined(typeof(QuestionStatus), status))
        {
            throw new InvalidStatusException(typeof(QuestionStatus), status);
        }
        Status = status;
    }
}
