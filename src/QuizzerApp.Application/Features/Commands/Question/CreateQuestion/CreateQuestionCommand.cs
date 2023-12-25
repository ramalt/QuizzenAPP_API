using MediatR;
using QuizzenApp.Domain.Entities.ExamAggregate;
using QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;

namespace QuizzerApp.Application.Features.Commands.Question;

public record CreateQuestionCommand(Guid Id,
                                    string Title,
                                    string Description,
                                    Exam Exam,
                                    List<QuestionImage> Images,
                                    string UserId) : IRequest<bool>
{


}
