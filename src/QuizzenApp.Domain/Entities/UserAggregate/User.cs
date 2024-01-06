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
        // ProfilePic = profilePic;
        Gender = gender;
    }

    // public UserProfileImage ProfilePic { get; private set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid ExamId { get; set; }
    public Exam Exam { get; set; }

    public Gender Gender { get; private set; }
    public ICollection<Question> Questions { get; private set; }
    public ICollection<Answer> Answers { get; private set; }
}
