using QuizzenApp.Domain.Entities.AnswerAggregate;

namespace QuizzerApp.Application.Common.Interfaces;

public interface IAnswerRepository
{
    Task<List<Answer>> GetAllAsync();
    Task<Answer> GetAsync(Guid id);
    Task CreateAsync(Answer answer);
    void UpdateAsync(Answer answer);
    void DeleteAsync(Answer answer);
}
