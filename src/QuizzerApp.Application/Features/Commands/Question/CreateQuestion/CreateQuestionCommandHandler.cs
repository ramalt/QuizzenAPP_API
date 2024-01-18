using MediatR;
using QuizzenApp.Shared.Dto;
using QuizzerApp.Application.Common.Interfaces;
using Entity = QuizzenApp.Domain.Entities;

namespace QuizzerApp.Application.Features.Commands.Question.CreateQuestion;

public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, Response<Guid>>
{
    private readonly IRepositoryManager _manager;

    public CreateQuestionCommandHandler(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public async Task<Response<Guid>> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {

        Entity.QuestionAggregate.Question question = new(id: Guid.NewGuid(),
                                                        title: request.Title,
                                                        description: request.Description,
                                                        examId: request.ExamId,
                                                        subjectId: request.SubjectId,
                                                        topicId: request.TopicId,
                                                        userId: "f4bcd779-a978-436f-b816-bf806fc0886d"); //FIXME: take userId from http header

        await _manager.Question.CreateAsync(question);

        var res = await _manager.SaveAsync();

        if (!res) throw new Exception("Db save exception"); //TODO: create custom error messages

        return new Response<Guid>(question.Id.Value);

    }
}
