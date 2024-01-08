using MediatR;
using QuizzerApp.Application.Dtos.Answer;

namespace QuizzerApp.Application.Features.Queries.Answer.ReadAnswers;

public record ReadAnswersQuery(string? QuestionId, string? userId = null) : IRequest<List<AnswerDto>>;
