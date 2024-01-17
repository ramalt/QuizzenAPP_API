using QuizzenApp.Domain.Entities.ExamAggregate;
using QuizzenApp.Domain.Entities.UserAggregate;

namespace QuizzerApp.Application.Common.Interfaces;

public interface IUserRepository
{
    Task<Exam> GetUserExamAsync(Guid examId);
    IQueryable<User> GetQueriable();
}
