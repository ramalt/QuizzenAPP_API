using MediatR;
using QuizzenApp.Shared.Dto;

namespace QuizzerApp.Application.Features.Commands.Answer.CreateAnswer;

public record CreateAnswerCommand(string text,
                                  Guid questionId,
                                  string userId) : IRequest<Response<Guid>>;

