

namespace QuizzenApp.PhotoStock.Services;

public interface IPhotoService
{
    Task<string?> SaveQuestionPhoto(IFormFile file, string questionId, CancellationToken cancellationToken);
    bool DeleteQuestionPhoto(string url);

    Task<string?> SaveUserPhoto(IFormFile file, string userId, CancellationToken cancellationToken);
    bool DeleteUserPhoto(string url);

    Task<string?> SaveAnswerPhoto(IFormFile file, string answerId, CancellationToken cancellationToken);
    bool DeleteAnswerPhoto(string url);


}
