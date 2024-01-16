

namespace QuizzenApp.PhotoStock.Services;

public interface IPhotoService
{
    Task<string?> SaveQuestionPhoto(IFormFile file, string imgId, CancellationToken cancellationToken);
    bool DeleteQuestionPhoto(string url);

    Task<string?> SaveUserPhoto(IFormFile file, string imgId, CancellationToken cancellationToken);
    bool DeleteUserPhoto(string url);

    Task<string?> SaveAnswerPhoto(IFormFile file, string imgId, CancellationToken cancellationToken);
    bool DeleteAnswerPhoto(string url);


}
