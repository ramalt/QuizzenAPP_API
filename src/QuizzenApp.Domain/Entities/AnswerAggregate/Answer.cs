using QuizzenApp.Domain.Entities.AnswerAggregate.ValueObjects;
using QuizzenApp.Domain.Entities.UserAggregate;
using QuizzenApp.Domain.Enums;
using QuizzenApp.Domain.Exceptions.AnswerExceptions;
using QuizzenApp.Shared.Domain;

namespace QuizzenApp.Domain.Entities.AnswerAggregate;

public class Answer : AggregateRoot<AnswerId>
{
    public new AnswerId Id { get; private set; } 
    public AnswerText Text { get; private set; } 
    public List<AnswerImage> Images { get; private set; } 
    public AnswerStatus Status { get; private set; } 
    public User User { get; private set; } 

    public Answer(AnswerId id, AnswerText text, List<AnswerImage> images, User user)
    {
        Id = id;
        Text = text;
        Images = images ?? new List<AnswerImage>();
        Status = AnswerStatus.active;
        User = user;
    }

    public void UpdateStatus(AnswerStatus status)
    {
        if (!Enum.IsDefined(typeof(AnswerStatus), status))
        {
            throw new InvalidStatusException(typeof(AnswerStatus), status);
        }
        Status = status;
    }

    public void AddImages(List<AnswerImage> images)
    {
        images.ForEach(ai => {
            Images.Add(ai);
        });
    }

}
