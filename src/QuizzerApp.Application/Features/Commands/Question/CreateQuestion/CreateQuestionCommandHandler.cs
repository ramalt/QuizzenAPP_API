using MediatR;
using QuizzerApp.Application.Common.Interfaces;
using Entity = QuizzenApp.Domain.Entities;

namespace QuizzerApp.Application.Features.Commands.Question.CreateQuestion;

public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, bool>
{
    private readonly IRepositoryManager _manager;

    public CreateQuestionCommandHandler(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public async Task<bool> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {

        Entity.QuestionAggregate.Question question = new(id: Guid.NewGuid(),
                                                        title: request.Title,
                                                        description: request.Description,
                                                        examId: request.ExamId,
                                                        subjectId: request.SubjectId,
                                                        topicId: request.TopicId,
                                                        userId: "f4bcd779-a978-436f-b816-bf806fc0886d");

        await _manager.Question.CreateAsync(question);
        await _manager.SaveAsync();

        return true;

    }
}
