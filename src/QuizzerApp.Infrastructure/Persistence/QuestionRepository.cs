using Microsoft.EntityFrameworkCore;
using QuizzenApp.Domain.Entities.QuestionAggregate;
using QuizzerApp.Application.Common.Interfaces;
using QuizzerApp.Infrastructure.Contracts;
using QuizzerApp.Infrastructure.EFCore.Contexts;

namespace QuizzerApp.Infrastructure.Persistence;

public class QuestionRepository(QuizzerAppContext context) : RepositoryBase<Question>(context) , IQuestionRepository
{
    public async Task CreateAsync(Question question) => Create(question);
    public void DeleteAsync(Question question) => Delete(question);
    public void UpdateAsync(Question question) => Update(question);
    public async Task<List<Question>> GetAllAsync() => FindAll(false).OrderBy(b => b.Id).ToList();
    public async Task<Question> GetAsync(Guid id) => await FindByCondition(q => q.Id.Value == id, false).FirstOrDefaultAsync();
    public async Task SaveChangesAsync() => await Save();
}
