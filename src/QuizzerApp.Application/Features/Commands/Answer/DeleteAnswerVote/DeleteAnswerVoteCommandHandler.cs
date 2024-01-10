using MediatR;
using QuizzenApp.Shared;
using QuizzenApp.Shared.Events.Answer;
using QuizzenApp.Shared.Infrastructure;

namespace QuizzerApp.Application.Features.Commands.Answer.DeleteAnswerVote;

public class DeleteAnswerVoteCommandHandler : IRequestHandler<DeleteAnswerVoteCommand, bool>
{
    public async Task<bool> Handle(DeleteAnswerVoteCommand request, CancellationToken cancellationToken)
    {
        DeleteAnswerVoteEvent @event = new(AnswerId: request.AnswerId, UserId: request.UserId);

        QProvider.SendMessage(exchangeName: QConstants.VOTE_EXCHANE,
                      exchangeType: QConstants.DEFAULT_EXCHANGE_TYPE,
                      queueName: QConstants.DELETE_ANSWER_VOTE_QUEUE,
                      obj: @event);

        return await Task.FromResult(true);
    }
}

