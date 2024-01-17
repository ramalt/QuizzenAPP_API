using MediatR;
using QuizzerApp.Application.Dtos.Exam;

namespace QuizzerApp.Application.Features.Queries.Exam.GetTopics;

public record GetTopicsBySubjectIdQuery(Guid SubjectId) : IRequest<List<TopicDto>>;
