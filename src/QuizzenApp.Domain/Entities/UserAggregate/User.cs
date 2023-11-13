using Microsoft.AspNetCore.Identity;
using QuizzenApp.Domain.Entities.AnswerAggregate;
using QuizzenApp.Domain.Entities.QuestionAggregate;
using QuizzenApp.Domain.Entities.UserAggregate.ValueObjects;
using QuizzenApp.Domain.Enums;

namespace QuizzenApp.Domain.Entities.UserAggregate;

public class User : IdentityUser 
{
    public User(){}
    public User(string userName, UserProfileImage profilePic, Gender gender) : base(userName)
    {
        ProfilePic = profilePic;
        Gender = gender;
    }

    public UserProfileImage ProfilePic { get; private set; }
    public Gender Gender { get; private set; }
    public ICollection<Question> Questions { get; set; }
    public ICollection<Answer> Answers { get; set; }
}
