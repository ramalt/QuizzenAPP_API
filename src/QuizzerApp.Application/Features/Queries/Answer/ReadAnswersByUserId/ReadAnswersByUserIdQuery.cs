using MediatR;
using QuizzerApp.Application.Dtos.Answer;

namespace QuizzerApp.Application.Features.Queries.Answer.ReadAnswersByUserId;

public record ReadAnswersByUserIdQuery(string UserId) : IRequest<List<AnswerDto>>;

