using MediatR;
using QuizzerApp.Application.Dtos.Question;

namespace QuizzerApp.Application.Features.Queries.Question.ReadQuestions;

public record ReadQuestionQuery(string? Exam = null, string? Subject = null, string? Topic = null) : IRequest<List<QuestionDto>>;
