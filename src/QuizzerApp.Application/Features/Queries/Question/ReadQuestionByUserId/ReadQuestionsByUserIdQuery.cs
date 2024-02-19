using MediatR;
using QuizzenApp.Shared.Dto;
using QuizzerApp.Application.Dtos.Question;

namespace QuizzerApp.Application.Features.Queries.Question.ReadQuestionByUserId;

public record ReadQuestionsByUserIdQuery(string UserId) : IRequest<List<QuestionDto>>;
