namespace QuizzerApp.Application.Dtos.User;

public record UserDto
{
    public string Id { get; init; }
    public string UserName { get; init; }
    public string FullName { get; init; }
    public string? ProfileImg { get; set; }

    public UserDto(string id, string userName, string firstName, string lastName, string? profileImg = null)
    {
        Id = id;
        UserName = userName;
        FullName = $"{firstName} {lastName}";
        ProfileImg = profileImg;
    }


}
