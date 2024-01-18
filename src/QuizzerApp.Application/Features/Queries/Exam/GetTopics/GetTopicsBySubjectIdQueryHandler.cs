using MediatR;
using QuizzenApp.Shared.Dto;
using QuizzerApp.Application.Common.Interfaces;
using QuizzerApp.Application.Dtos.Exam;

namespace QuizzerApp.Application.Features.Queries.Exam.GetTopics;

public class GetTopicsBySubjectIdQueryHandler : IRequestHandler<GetTopicsBySubjectIdQuery, Response<List<TopicDto>>>
{

    private readonly IRepositoryManager _manager;

    public GetTopicsBySubjectIdQueryHandler(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public async Task<Response<List<TopicDto>>> Handle(GetTopicsBySubjectIdQuery request, CancellationToken cancellationToken)
    {

        var subjects = await _manager.Exam.GetTopicsBySubjectId(request.SubjectId);

        List<TopicDto> res = new();

        subjects.ForEach(s =>
        {
            res.Add(new TopicDto(s.Id, s.Name));
        });

        return new Response<List<TopicDto>>(res);

    }
}