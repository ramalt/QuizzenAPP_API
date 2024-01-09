using QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;
using QuizzenApp.Domain.Entities.UserAggregate;
using QuizzenApp.Domain.Enums;

namespace QuizzenApp.Domain.Entities.QuestionAggregate;

public class QuestionVote
{
    public Guid Id { get; private set; }
    public QuestionId QuestionId { get; private set; }
    public Question Question { get; private set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public VoteType VoteType { get; private set; }
    public DateTime CreatedDate { get; private set; }

    public QuestionVote() { }
    public QuestionVote(Guid id, QuestionId questionId, string userId, VoteType voteType)
    {
        Id = id;
        QuestionId = questionId;
        VoteType = voteType;
        CreatedDate = DateTime.Now;
        UserId = userId;
    }
}
