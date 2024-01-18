using MediatR;
using Entity = QuizzenApp.Domain.Entities.AnswerAggregate;
using QuizzerApp.Application.Common.Interfaces;
using QuizzenApp.Shared.Dto;

namespace QuizzerApp.Application.Features.Commands.Answer.CreateAnswer;

public class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommand, Response<Guid>>
{
    private readonly IRepositoryManager _manager;

    public CreateAnswerCommandHandler(IRepositoryManager manager) => _manager = manager;

    public async Task<Response<Guid>> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
    {
        Entity.Answer answer = new(id: Guid.NewGuid(),
                                    text: request.text,
                                    userId: request.userId,
                                    questionId: request.questionId);

        await _manager.Answer.CreateAsync(answer: answer);

        var res = await _manager.SaveAsync();

        if (res) throw new Exception("TODO: write an error message here");

        return new Response<Guid>(answer.Id.Value);
    }
}
