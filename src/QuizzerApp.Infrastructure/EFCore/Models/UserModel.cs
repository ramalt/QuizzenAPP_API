using Microsoft.AspNetCore.Identity;

namespace QuizzerApp.Infrastructure.EFCore.Models;

public class UserModel : IdentityUser
{
    public UserProfileImage ProfilePic { get; private set; }
    public Gender Gender { get; private set; }

    public List<QuestionModel> Questions { get; set; }
    public List<AnswerModel> Answers { get; set; }
}

public enum Gender
{
    Male,
    Female,
}

public class UserProfileImage
{
    public string Url { get; set; }

}