using QuizzenApp.Domain.Entities.AnswerAggregate.ValueObjects;
using QuizzenApp.Domain.Entities.UserAggregate;
using QuizzenApp.Domain.Enums;

namespace QuizzenApp.Domain.Entities.AnswerAggregate;

public class AnswerVote
{
    public Guid Id { get; private set; }
    public AnswerId AnswerId { get; private set; }
    public Answer Answer { get; private set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public VoteType VoteType { get; private set; }
    public DateTime CreatedDate { get; private set; }

    public AnswerVote() { }
    public AnswerVote(Guid id, AnswerId answerId, string userId, VoteType voteType)
    {
        Id = id;
        AnswerId = answerId;
        VoteType = voteType;
        CreatedDate = DateTime.Now;
        UserId = userId;
    }
}
