using Microsoft.AspNetCore.Identity;
using QuizzenApp.Domain.Entities.UserAggregate.ValueObjects;
using QuizzenApp.Domain.Enums;

namespace QuizzenApp.Domain.Entities.UserAggregate;

public class User : IdentityUser 
{
    public User(string userName, UserProfileImage profilePic, Gender gender) : base(userName)
    {
        ProfilePic = profilePic;
        Gender = gender;
    }

    public UserProfileImage ProfilePic { get; private set; }
    public Gender Gender { get; private set; }
}
