using MediatR;
using QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;
using QuizzenApp.Shared.Dto;

namespace QuizzerApp.Application.Features.Commands.Question;

public record CreateQuestionCommand(string Title,
                                    string Description,
                                    Guid ExamId,
                                    Guid SubjectId,
                                    Guid TopicId,
                                    string UserId) : IRequest<Response<Guid>>
{


}
