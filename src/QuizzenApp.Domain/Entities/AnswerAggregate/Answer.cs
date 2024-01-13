using QuizzenApp.Domain.Entities.AnswerAggregate.ValueObjects;
using QuizzenApp.Domain.Entities.QuestionAggregate;
using QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;
using QuizzenApp.Domain.Entities.UserAggregate;
using QuizzenApp.Domain.Enums;
using QuizzenApp.Domain.Exceptions.AnswerExceptions;
using QuizzenApp.Shared.Domain;

namespace QuizzenApp.Domain.Entities.AnswerAggregate;

public sealed class Answer : AggregateRoot<AnswerId>
{
    public new AnswerId Id { get; private set; }
    public AnswerText Text { get; private set; }
    public AnswerStatus Status { get; private set; }
    // public List<AnswerImage> Images;

    public string UserId { get; private set; }
    public User User { get; private set; }

    public QuestionId QuestionId { get; private set; }
    public Question Question { get; private set; }

    public ICollection<AnswerVote> AnswerVotes { get; set; }
    public ICollection<AnswerImage> Images;

    public DateTime CreatedDate { get; private set; }
    public DateTime UpdatedDate { get; private set; }

    public Answer() { }

    public Answer(AnswerId id, AnswerText text, string userId, Guid questionId)
    {
        Id = id;
        Text = text;
        // Images = images ?? new List<AnswerImage>();
        Status = AnswerStatus.active;
        UserId = userId;
        QuestionId = questionId;
        CreatedDate = DateTime.Now;
        UpdatedDate = DateTime.Now;
    }

    public void UpdateStatus(AnswerStatus status)
    {
        if (!Enum.IsDefined(typeof(AnswerStatus), status))
            throw new InvalidStatusException(typeof(AnswerStatus), status);

        Status = status;
    }

    // public void AddImages(List<AnswerImage> images)
    // {
    //     images.ForEach(ai => Images.Add(ai));
    //     UpdatedDate = DateTime.Now;
    // }

}
