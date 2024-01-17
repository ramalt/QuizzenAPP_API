using MediatR;
using QuizzerApp.Application.Dtos.Exam;

namespace QuizzerApp.Application.Features.Queries.Exam.GetSubjects;

public record GetSubjectsByExamIdQuery(Guid ExamId) : IRequest<List<SubjecDto>>;
