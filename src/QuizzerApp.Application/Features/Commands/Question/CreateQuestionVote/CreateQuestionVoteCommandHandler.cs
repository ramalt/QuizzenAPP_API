using MediatR;
using QuizzenApp.Shared;
using QuizzenApp.Shared.Events.Question;
using QuizzenApp.Shared.Infrastructure;

namespace QuizzerApp.Application.Features.Commands.Question.CreateQuestionVote;

public class CreateQuestionVoteCommandHandler : IRequestHandler<CreateQuestionVoteCommand>
{
    public async Task Handle(CreateQuestionVoteCommand request, CancellationToken cancellationToken)
    {
        QuestionUpVoteEvent @event = new(request.QuestionId, request.UserId);

        QProvider.SendMessage(exchangeName: QConstants.VOTE_EXCHANE,
                              exchangeType: QConstants.DEFAULT_EXCHANGE_TYPE,
                              queueName: QConstants.CREATE_QUESTION_VOTE_QUEUE,
                              obj: @event);

    }
}
