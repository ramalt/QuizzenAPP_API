using MediatR;
using QuizzerApp.Application.Common.Interfaces;
using Entity = QuizzenApp.Domain.Entities;

namespace QuizzerApp.Application.Features.Commands.Question.CreateQuestion;

public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, bool>
{
    private readonly IQuestionRepository _repository;

    public CreateQuestionCommandHandler(IQuestionRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {

        Entity.QuestionAggregate.Question question = new(id: Guid.NewGuid(),
                                       title: request.Title,
                                       description: request.Description,
                                       exam: request.Exam,
                                       userId: request.UserId);

        await _repository.CreateAsync(question);

        return true;


    }
}
