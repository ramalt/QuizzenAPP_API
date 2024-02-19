using MediatR;

namespace QuizzerApp.Application.Features.Commands.Question;

public record CreateQuestionCommand(string Title,
                                    string Description,
                                    Guid ExamId,
                                    Guid SubjectId,
                                    Guid TopicId,
                                    string UserId) : IRequest<Guid>
{


}
