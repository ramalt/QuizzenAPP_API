using MediatR;

namespace QuizzerApp.Application.Features.Commands.Answer.CreateAnswer;

public record CreateAnswerCommand(string text,
                                  Guid questionId,
                                  string userId) : IRequest<Guid>;

