using MediatR;
using QuizzenApp.Domain.Enums;
using QuizzenApp.Shared.Dto;

namespace QuizzerApp.Application.Features.Commands.User.CreateUser;

public record CreateUserCommand(string FirstName,
                                string LastName,
                                string Email,
                                string Password,
                                string UserName,
                                Gender Gender,
                                Guid ExamId) : IRequest<Response<string>>;
