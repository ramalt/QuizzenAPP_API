using MediatR;
using QuizzerApp.Application.Common.Interfaces;
using QuizzerApp.Application.Dtos.Question;

namespace QuizzerApp.Application.Features.Queries.Question.ReadQuestionById;

public class ReadQuestionQueryHandler : IRequestHandler<ReadQuestionByIdQuery, QuestionDto>
{
    private readonly IRepositoryManager _manager;

    public ReadQuestionQueryHandler(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public async Task<QuestionDto> Handle(ReadQuestionByIdQuery request, CancellationToken cancellationToken)
    {
        var dbQuestion = await _manager.Question.GetAsync(request.QuestionId);
        QuestionDto res = new(Id: dbQuestion.Id,
                              Title: dbQuestion.Title,
                              Description: dbQuestion.Description,
                              Status: dbQuestion.Status.ToString(),
                              ownerId: dbQuestion.UserId,
                              ExamId: dbQuestion.ExamId,
                              SubjectId: dbQuestion.SubjectId,
                              TopicId: dbQuestion.TopicId,
                              CreatedDate: dbQuestion.CreatedDate
                              );

        return res;
    }
}
