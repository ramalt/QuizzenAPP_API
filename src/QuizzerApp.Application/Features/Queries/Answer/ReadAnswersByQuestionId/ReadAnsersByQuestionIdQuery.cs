using MediatR;
using QuizzerApp.Application.Dtos.Answer;

namespace QuizzerApp.Application.Features.Queries.Answer.ReadAnswersByQuestionId;

public record ReadAnsersByQuestionIdQuery(Guid QuestionId) : IRequest<List<AnswerDto>>;

