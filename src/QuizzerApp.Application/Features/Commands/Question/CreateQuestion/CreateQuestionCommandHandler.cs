using MediatR;
using QuizzenApp.Shared.Exceptions;
using QuizzerApp.Application.Common.Interfaces;
using Entity = QuizzenApp.Domain.Entities;

namespace QuizzerApp.Application.Features.Commands.Question.CreateQuestion;

public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, Guid>
{
    private readonly IRepositoryManager _manager;

    public CreateQuestionCommandHandler(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public async Task<Guid> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        var dbExm = await _manager.Exam.GetExamAsync(request.ExamId);
        var dbSubj = await _manager.Exam.GetSubjectAsync(request.SubjectId);
        var dbTopc = await _manager.Exam.GetTopicAsync(request.TopicId);
        var dbUser = _manager.User.CheckIsExist(request.UserId);

        if (!dbUser) throw new NotFoundException("User", request.UserId);
        if (dbExm is null) throw new NotFoundException("Exam", request.ExamId.ToString());
        if (dbSubj is null) throw new NotFoundException("Subject", request.SubjectId.ToString());
        if (dbTopc is null) throw new NotFoundException("Topic", request.TopicId.ToString());

        Entity.QuestionAggregate.Question question = new(id: Guid.NewGuid(),
                                                        title: request.Title,
                                                        description: request.Description,
                                                        examId: request.ExamId,
                                                        subjectId: request.SubjectId,
                                                        topicId: request.TopicId,
                                                        userId: "f4bcd779-a978-436f-b816-bf806fc0886d"); //FIXME: take userId from http header

        await _manager.Question.CreateAsync(question);

        var res = await _manager.SaveAsync();

        if (!res) throw new DbSaveException("Question");

        return question.Id.Value;

    }
}
