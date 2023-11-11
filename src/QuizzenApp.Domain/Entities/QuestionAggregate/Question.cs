using QuizzenApp.Domain.Entities.ExamAggregate;
using QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;
using QuizzenApp.Domain.Entities.UserAggregate;
using QuizzenApp.Domain.Enums;
using QuizzenApp.Shared.Domain;

namespace QuizzenApp.Domain.Entities.QuestionAggregate;

public class Question : AggregateRoot<QuestionId>
{
    public QuestionId Id { get; private set; }
    public QuestionTitle Title {get; private set;}
    public QuestionDescription Description {get; private set;}
    public Exam Exam { get; private set; }
    public QuestionStatus Status { get; private set; }

    public User User { get; private set; }
}
