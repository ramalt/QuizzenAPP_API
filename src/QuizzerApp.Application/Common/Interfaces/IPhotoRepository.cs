using QuizzenApp.Domain.Entities.AnswerAggregate;
using QuizzenApp.Domain.Entities.AnswerAggregate.ValueObjects;
using QuizzenApp.Domain.Entities.QuestionAggregate;
using QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;

namespace QuizzerApp.Application.Common.Interfaces;

public interface IPhotoRepository
{
    Task<bool> AddQuestionImageAsync(QuestionId questionId, Guid imgId, string imgPath);
    Task<bool> AddAnswerImageAsync(AnswerId answerId, Guid imgId, string imgPath);
    Task<bool> AddUserImageAsync(string userId, Guid imgId, string imgPath);
    Task DeleteQuestionImageAsync(Guid ImageId);
    List<QuestionImage> GetDbQuestionImgPaths(Guid questionId);
    List<AnswerImage> GetDbAnswerImgPaths(Guid answerId);
}
