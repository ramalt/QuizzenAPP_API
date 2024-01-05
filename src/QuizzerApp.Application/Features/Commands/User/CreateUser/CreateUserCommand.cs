using MediatR;
using QuizzenApp.Domain.Enums;

namespace QuizzerApp.Application.Features.Commands.User.CreateUser;

public record CreateUserCommand(string firstName,
                                string lastName,
                                string email,
                                string password,
                                string userName,
                                Gender gender) : IRequest<bool>;
