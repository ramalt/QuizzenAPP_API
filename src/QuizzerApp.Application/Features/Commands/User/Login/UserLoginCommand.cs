using MediatR;
using QuizzerApp.Application.Dtos.Auth;

namespace QuizzerApp.Application.Features.Commands.User.Login;

public record UserLoginCommand(string Email, string Password) : IRequest<TokenDto>;
