using MediatR;
using QuizzenApp.Shared.Dto;
using QuizzerApp.Application.Common.Interfaces;
using QuizzerApp.Application.Dtos.Exam;

namespace QuizzerApp.Application.Features.Queries.Exam.GetSubjects;

public class GetSubjectsByExamIdQueryHandler : IRequestHandler<GetSubjectsByExamIdQuery, Response<List<SubjecDto>>>
{

    private readonly IRepositoryManager _manager;

    public GetSubjectsByExamIdQueryHandler(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public async Task<Response<List<SubjecDto>>> Handle(GetSubjectsByExamIdQuery request, CancellationToken cancellationToken)
    {

        var subjects = await _manager.Exam.GetSubjectsByExamId(request.ExamId);

        List<SubjecDto> res = new();

        subjects.ForEach(s =>
        {
            res.Add(new SubjecDto(s.Id, s.Name));
        });

        return new Response<List<SubjecDto>>(res);

    }
}
