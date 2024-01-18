using MediatR;

namespace QuizzerApp.Application.Features.Commands.Question.DeleteQuestionVote;

public record DeleteQuestionVoteCommand(Guid QuestionId, string UserId) : IRequest;

