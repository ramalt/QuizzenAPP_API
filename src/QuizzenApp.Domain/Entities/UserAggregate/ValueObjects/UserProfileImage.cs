namespace QuizzenApp.Domain.Entities.UserAggregate.ValueObjects;

public record UserProfileImage
{
    public string Url { get; init; }    
    public UserProfileImage(string url)
    {
        Url = url;
    }
}
