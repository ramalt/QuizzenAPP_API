using MediatR;
using QuizzenApp.Shared;
using QuizzenApp.Shared.Events.Answer;
using QuizzenApp.Shared.Infrastructure;

namespace QuizzerApp.Application.Features.Commands.Answer.CreateAnswerVote;

public class CreateAnswerVoteCommandHandler : IRequestHandler<CreateAnswerVoteCommand>
{
    public async Task Handle(CreateAnswerVoteCommand request, CancellationToken cancellationToken)
    {
        CreateAnswerUpVoteEvent @event = new(AnswerId: request.AnswerId, UserId: request.UserId);

        QProvider.SendMessage(exchangeName: QConstants.VOTE_EXCHANE,
                      exchangeType: QConstants.DEFAULT_EXCHANGE_TYPE,
                      queueName: QConstants.CREATE_ANSWER_VOTE_QUEUE,
                      obj: @event);

    }
}
