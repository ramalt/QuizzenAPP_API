using MediatR;
using AnswerModel = QuizzenApp.Domain.Entities.AnswerAggregate.Answer;
using UserModel = QuizzenApp.Domain.Entities.UserAggregate.User;
using QuizzerApp.Application.Common.Interfaces;
using QuizzenApp.Shared.Dto;
using QuizzenApp.Shared.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace QuizzerApp.Application.Features.Commands.Answer.CreateAnswer;

public class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommand, Response<Guid>>
{
    private readonly IRepositoryManager _manager;
    private readonly UserManager<UserModel> _userManager;

    public CreateAnswerCommandHandler(IRepositoryManager manager, UserManager<UserModel> userManager)
    {
        _manager = manager;
        _userManager = userManager;
    }

    public async Task<Response<Guid>> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
    {
        var dbQ = await _manager.Question.GetAsync(request.questionId);
        var dbU = await _userManager.FindByIdAsync(request.userId);

        if (dbQ is null) throw new NotFoundException("Question", request.questionId.ToString());

        if (dbU is null) throw new NotFoundException("User", request.userId);


        AnswerModel answer = new(id: Guid.NewGuid(),
                                    text: request.text,
                                    userId: request.userId,
                                    questionId: request.questionId);

        await _manager.Answer.CreateAsync(answer: answer);

        var res = await _manager.SaveAsync();

        if (!res) throw new DbSaveException("Answer");

        return new Response<Guid>(request.questionId);
    }
}
