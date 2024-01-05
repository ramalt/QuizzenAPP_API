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
    public ICollection<Answer> Answers;

    // public List<QuestionImage> Images;
    public string UserId { get; private set; }
    public User User { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public DateTime UpdatedDate { get; private set; }

    public void UpdateStatus(QuestionStatus status)
    {
        if (!Enum.IsDefined(typeof(QuestionStatus), status))
            throw new InvalidStatusException(typeof(QuestionStatus), status);

        Status = status;
    }

    public Question() { }

    public Question(Guid id, QuestionTitle title, QuestionDescription description, Exam exam, string userId)
    {
        Id = id;
        Title = title;
        Description = description;
        Exam = exam;
        UserId = userId;
        Status = QuestionStatus.active;
        // Images = images ?? new List<QuestionImage>();
        CreatedDate = DateTime.Now;
        UpdatedDate = DateTime.Now;
    }

    // public void AddAnswer(Answer answer)
    // {
    //     Answer newAnswer = new(Guid.NewGuid(), answer.Text, answer.Images, answer.User, answer.QuestionId);
    //     Answers.Add(newAnswer);
    // }


    // public void AddImages(List<QuestionImage> images)
    // {
    //     images.ForEach(qi => Images.Add(qi));
    //     UpdatedDate = DateTime.Now;
    // }

}
