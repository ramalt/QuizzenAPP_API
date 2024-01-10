using MediatR;

namespace QuizzerApp.Application.Features.Commands.Answer.DeleteAnswerVote;

public record DeleteAnswerVoteCommand(Guid AnswerId, string UserId) : IRequest<bool>;

