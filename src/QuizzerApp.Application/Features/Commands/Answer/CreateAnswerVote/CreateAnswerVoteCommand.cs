using MediatR;

namespace QuizzerApp.Application.Features.Commands.Answer.CreateAnswerVote;

public record CreateAnswerVoteCommand(Guid AnswerId, string UserId) : IRequest;
