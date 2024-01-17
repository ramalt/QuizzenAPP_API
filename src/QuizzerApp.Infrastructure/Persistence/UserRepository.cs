using Microsoft.EntityFrameworkCore;
using QuizzenApp.Domain.Entities.ExamAggregate;
using QuizzenApp.Domain.Entities.UserAggregate;
using QuizzerApp.Application.Common.Interfaces;
using QuizzerApp.Infrastructure.Contracts;
using QuizzerApp.Infrastructure.EFCore.Contexts;

namespace QuizzerApp.Infrastructure.Persistence;

public class UserRepository(QuizzerAppContext context) : RepositoryBase<User>(context), IUserRepository
{
    private readonly QuizzerAppContext _context = context;

    public IQueryable<User> GetQueriable() => Queriable();

    public async Task<Exam> GetUserExamAsync(Guid examId) => await _context.Exams.FirstOrDefaultAsync(e => e.Id == examId);

}
