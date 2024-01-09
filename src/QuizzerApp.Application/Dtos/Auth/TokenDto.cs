namespace QuizzerApp.Application.Dtos.Auth;

public record TokenDto(string Token, string RefreshToken = "1234");
