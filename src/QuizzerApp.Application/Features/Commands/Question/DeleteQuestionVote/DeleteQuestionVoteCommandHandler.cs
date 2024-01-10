using MediatR;
using QuizzenApp.Shared;
using QuizzenApp.Shared.Events.Question;
using QuizzenApp.Shared.Infrastructure;

namespace QuizzerApp.Application.Features.Commands.Question.DeleteQuestionVote;

public class DeleteQuestionVoteCommandHandler : IRequestHandler<DeleteQuestionVoteCommand, bool>
{
    public async Task<bool> Handle(DeleteQuestionVoteCommand request, CancellationToken cancellationToken)
    {

        DeleteQuestionVoteEvent @event = new(QuestionId: request.QuestionId, UserId: request.UserId);

        QProvider.SendMessage(exchangeName: QConstants.VOTE_EXCHANE,
                              exchangeType: QConstants.DEFAULT_EXCHANGE_TYPE,
                              queueName: QConstants.DELETE_QUESTION_VOTE_QUEUE,
                              obj: @event);

        return await Task.FromResult(true);
    }
}

