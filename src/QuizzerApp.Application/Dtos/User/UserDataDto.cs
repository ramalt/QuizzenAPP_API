namespace QuizzerApp.Application.Dtos.User;

public record UserDataDto(string Id,
                              string FirstName,
                              string LastName,
                              string UserName,
                              string Exam,
                              string Email,
                              string? ProfileImg = null);
