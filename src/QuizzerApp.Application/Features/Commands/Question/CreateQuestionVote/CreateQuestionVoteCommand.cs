using MediatR;

namespace QuizzerApp.Application.Features.Commands.Question.CreateQuestionVote;

public record CreateQuestionVoteCommand(Guid QuestionId, string UserId) : IRequest;
