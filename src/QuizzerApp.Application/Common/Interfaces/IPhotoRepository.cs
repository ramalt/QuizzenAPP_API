using QuizzenApp.Domain.Entities.QuestionAggregate;
using QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;

namespace QuizzerApp.Application.Common.Interfaces;

public interface IPhotoRepository
{
    Task AddQuestionImageAsync(QuestionId questionId, Guid imgId);
    Task DeleteQuestionImageAsync(Guid ImageId);
    List<QuestionImage> GetDbQuestionImgPaths(Guid questionId);
}
