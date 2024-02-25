using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using QuizzenApp.Domain.Entities.AnswerAggregate;
using QuizzenApp.Domain.Entities.ExamAggregate;
using QuizzenApp.Domain.Entities.QuestionAggregate;
using QuizzenApp.Domain.Enums;

namespace QuizzenApp.Domain.Entities.UserAggregate;

public class User : IdentityUser
{
    public User() { }
    public User(string userName, Gender gender) : base(userName)
    {
        Gender = gender;
    }

    public string? ProfileImg { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid ExamId { get; set; }
    public Exam Exam { get; set; }

    public Gender Gender { get; set; }
    public ICollection<Question> Questions { get; private set; }
    public ICollection<QuestionVote> QuestionVotes { get; private set; }
    public ICollection<Answer> Answers { get; private set; }
    public ICollection<AnswerVote> AnswerVotes { get; private set; }

}
