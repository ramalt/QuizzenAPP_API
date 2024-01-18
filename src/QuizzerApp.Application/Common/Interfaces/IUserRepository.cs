using QuizzenApp.Domain.Entities.ExamAggregate;
using QuizzenApp.Domain.Entities.UserAggregate;

namespace QuizzerApp.Application.Common.Interfaces;

public interface IUserRepository
{
    Task<Exam> GetUserExamAsync(Guid examId);

    bool CheckIsExist(string userId);
    IQueryable<User> GetQueriable();
}
