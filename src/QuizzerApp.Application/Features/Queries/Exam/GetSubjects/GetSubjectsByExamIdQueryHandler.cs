using MediatR;
using QuizzerApp.Application.Common.Interfaces;
using QuizzerApp.Application.Dtos.Exam;

namespace QuizzerApp.Application.Features.Queries.Exam.GetSubjects;

public class GetSubjectsByExamIdQueryHandler : IRequestHandler<GetSubjectsByExamIdQuery, List<SubjecDto>>
{

    private readonly IRepositoryManager _manager;

    public GetSubjectsByExamIdQueryHandler(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public async Task<List<SubjecDto>> Handle(GetSubjectsByExamIdQuery request, CancellationToken cancellationToken)
    {

        var subjects = await _manager.Exam.GetSubjectsByExamId(request.ExamId);

        List<SubjecDto> res = new();

        subjects.ForEach(s =>
        {
            res.Add(new SubjecDto(s.Id, s.Name));
        });

        return new List<SubjecDto>(res);

    }
}
