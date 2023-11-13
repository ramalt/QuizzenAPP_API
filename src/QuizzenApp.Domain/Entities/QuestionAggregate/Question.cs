using QuizzenApp.Domain.Entities.AnswerAggregate;
using QuizzenApp.Domain.Entities.ExamAggregate;
using QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;
using QuizzenApp.Domain.Entities.UserAggregate;
using QuizzenApp.Domain.Enums;
using QuizzenApp.Domain.Exceptions.AnswerExceptions;
using QuizzenApp.Shared.Domain;

namespace QuizzenApp.Domain.Entities.QuestionAggregate;

public class Question : AggregateRoot<QuestionId>
{
    public new QuestionId Id { get; private set; } 
    public QuestionTitle Title { get; private set; } 
    public QuestionDescription Description { get; private set; } 
    public Exam Exam { get; private set; } 
    public QuestionStatus Status { get; private set; } 
    public List<Answer>? Answers { get; private set; }

    public List<QuestionImage> Images = new();
    public string UserId { get; private set; }
    public User User { get; private set; } 
    public DateTime CreatedDate { get; private set; }
    public DateTime UpdatedDate { get; private set; }

    public void UpdateStatus(QuestionStatus status)
    {
        if (!Enum.IsDefined(typeof(QuestionStatus), status))
        {
            throw new InvalidStatusException(typeof(QuestionStatus), status);
        }
        Status = status;
    }

    public Question(){}

    public Question(Guid id, QuestionTitle title, QuestionDescription description,List<QuestionImage> images , Exam exam, User user)
    {
        Id = id;
        Title = title;
        Description = description;
        Exam = exam;
        User = user;
        Status = QuestionStatus.active;
        Images = images ?? new List<QuestionImage>();
        CreatedDate = DateTime.Now;
        UpdatedDate = DateTime.Now;
        Answers = new List<Answer>();
    }

    public void AddAnswer(Answer answer)
    {
        Answer newAnswer = new(Guid.NewGuid(), answer.Text, answer.Images, answer.User, answer.QuestionId);
        Answers.Add(newAnswer);
    }


    public void AddImages(List<QuestionImage> images)
    {
        images.ForEach(qi => {
            Images.Add(qi);
        });
    }

}
