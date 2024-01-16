using QuizzenApp.Domain.Entities.AnswerAggregate;
using QuizzenApp.Domain.Entities.AnswerAggregate.ValueObjects;
using QuizzenApp.Domain.Entities.QuestionAggregate;
using QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;

namespace QuizzerApp.Application.Common.Interfaces;

public interface IPhotoRepository
{
    Task AddQuestionImageAsync(QuestionId questionId, Guid imgId);
    Task AddAnswerImageAsync(AnswerId answerId, Guid imgId);
    Task AddUserImageAsync(string userId, Guid imgId);
    Task DeleteQuestionImageAsync(Guid ImageId);
    List<QuestionImage> GetDbQuestionImgPaths(Guid questionId);
    List<AnswerImage> GetDbAnswerImgPaths(Guid answerId);
}
